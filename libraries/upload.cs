using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using Newtonsoft.Json;

namespace CO_Driver
{
    public class Upload
    {
        public static void upload_match_history(file_trace_managment.SessionStats Current_session)
        {
            List<long> previous_matchs = get_previously_uploaded_match_list(Current_session.local_user_uid);
            List<Crossout.AspWeb.Models.API.v2.MatchEntry> upload_list = new List<Crossout.AspWeb.Models.API.v2.MatchEntry> { };

            foreach (file_trace_managment.MatchRecord match in Current_session.match_history)
            {
                if (previous_matchs.Contains(match.match_data.server_guid))
                    continue;

                if (match.match_data.server_guid == 0)
                    continue;

                if (!match.match_data.match_rewards.Any())
                    continue;

                if (match.match_data.winning_team == -1)
                    continue;

                upload_list.Add(populate_match_entry(match));

                if (upload_list.Count >= 50)
                {
                    if (upload_match_list_to_crossoutdb(upload_list) == -1)
                        return;
                    upload_list = new List<Crossout.AspWeb.Models.API.v2.MatchEntry> { };
                }
            }

            if (upload_list.Any())
                upload_match_list_to_crossoutdb(upload_list);
        }

        public static Crossout.AspWeb.Models.API.v2.MatchEntry populate_match_entry(file_trace_managment.MatchRecord match)
        {
            Crossout.AspWeb.Models.API.v2.MatchEntry match_entry = new Crossout.AspWeb.Models.API.v2.MatchEntry { };

            match_entry.match_id = match.match_data.server_guid;
            match_entry.uploader_uid = match.match_data.local_player.uid;
            match_entry.match_type = match.match_data.match_type_desc;
            match_entry.match_start = match.match_data.match_start.ToUniversalTime();
            match_entry.match_end = match.match_data.match_end.ToUniversalTime();
            match_entry.map_name = match.match_data.map_name;
            match_entry.winning_team = match.match_data.winning_team;
            match_entry.win_conidtion = 1; /*TODO*/
            match_entry.co_driver_version = global_data.CURRENT_VERSION;
            if (match.match_data.client_version.Contains(" ")) 
                match_entry.client_version = match.match_data.client_version.Split(' ')[0];
            else
                match_entry.client_version = match.match_data.client_version;
            match_entry.game_server = match.match_data.server_ip;
            match_entry.rounds = populate_round_entrys(match);

            return match_entry;
        }

        public static List<Crossout.AspWeb.Models.API.v2.RoundEntry> populate_round_entrys(file_trace_managment.MatchRecord match)
        {
            List<Crossout.AspWeb.Models.API.v2.RoundEntry> rounds = new List<Crossout.AspWeb.Models.API.v2.RoundEntry> { };
            Crossout.AspWeb.Models.API.v2.RoundEntry new_round;

            int i = 0;
            foreach (file_trace_managment.RoundRecord round in match.match_data.round_records)
            {
                new_round = new Crossout.AspWeb.Models.API.v2.RoundEntry { };
                new_round.match_id = match.match_data.server_guid;
                new_round.round_id = i;
                new_round.round_start = round.round_start.ToUniversalTime();
                new_round.round_end = round.round_end.ToUniversalTime();
                new_round.winning_team = round.winning_team;
                new_round.players = new List<Crossout.AspWeb.Models.API.v2.MatchPlayerEntry> { };

                foreach (file_trace_managment.Player player in round.players)
                {
                    if (player.bot == 1)
                        continue;

                    Crossout.AspWeb.Models.API.v2.MatchPlayerEntry new_player = new Crossout.AspWeb.Models.API.v2.MatchPlayerEntry { };
                    new_player.match_id = match.match_data.server_guid;
                    new_player.round_id = i;
                    new_player.uid = player.uid;
                    new_player.nickname = player.nickname;
                    new_player.team = player.team;
                    new_player.build_hash = player.build_hash;
                    new_player.power_score = player.power_score;
                    new_player.kills = player.stats.kills;
                    new_player.assists = player.stats.assists;
                    new_player.drone_kills = player.stats.drone_kills;
                    new_player.score = player.stats.score;
                    new_player.damage = player.stats.damage;
                    new_player.damage_taken = player.stats.damage_taken;
                    new_round.players.Add(new_player);
                }
                rounds.Add(new_round);
                i++;
            }

            return rounds;
        }

        public static List<long> get_previously_uploaded_match_list(int local_user_id)
        {
            List<long> previous_matchs = new List<long> { };

#if DEBUG
            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:5001/api/v2/co_driver/upload_records/" + local_user_id.ToString());
#else
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://crossoutdb.com/api/v2/co_driver/upload_records/" + local_user_id.ToString());
#endif

            request.Method = "POST";
            request.ContentType = "application/json";
            request.Timeout = 30000;
            
            try
            {
                using (Stream webStream = request.GetRequestStream())
                using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                {
                    requestWriter.Write(@"{""object"":{""name"":""Name""}}");
                }

                WebResponse webResponse = request.GetResponse();

                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string crossoutdb_json = responseReader.ReadToEnd();
                    previous_matchs = JsonConvert.DeserializeObject<List<long>>(crossoutdb_json);
                }
            }
            catch (TimeoutException ex)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("The following problem occured when loading previous match list from crossoutdb.com" + Environment.NewLine + Environment.NewLine + ex.Message);
            }

            return previous_matchs;
        }

        public static int upload_match_list_to_crossoutdb(List<Crossout.AspWeb.Models.API.v2.MatchEntry> match_list)
        {
            int match_count = -1;

            try
            {
                string serialized_match_list = JsonConvert.SerializeObject(match_list);

#if DEBUG
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:5001/api/v2/co_driver/upload_matchs");
#else
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://crossoutdb.com/api/v2/co_driver/upload_matchs");
#endif
                request.Method = "POST";
                request.ContentType = "application/json; charset=UTF-8";
                request.Timeout = 100000;
                using (Stream webStream = request.GetRequestStream())
                using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                {
                    requestWriter.Write(serialized_match_list);
                }

                WebResponse webResponse = request.GetResponse();

                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string crossoutdb_json = responseReader.ReadToEnd();
                    match_count = JsonConvert.DeserializeObject<int>(crossoutdb_json);
                }
            }
            catch (TimeoutException ex)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("The following problem occured when loading data from crossoutdb.com" + Environment.NewLine + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "Defaults will be used.");
            }

            return match_count;
        }
    }
}
