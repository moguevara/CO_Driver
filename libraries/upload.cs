﻿using System;
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
            List<long> previous_matchs = get_previously_uploaded_match_list(Current_session);

            foreach (file_trace_managment.MatchRecord match in Current_session.match_history)
            {
                if (match.match_data.server_guid == 0)
                    continue;

                if (previous_matchs.Contains(match.match_data.server_guid))
                    continue;

                Crossout.AspWeb.Models.API.v2.MatchEntry match_upload = populate_match_entry(match);
            }
        }

        private static Crossout.AspWeb.Models.API.v2.MatchEntry populate_match_entry(file_trace_managment.MatchRecord match)
        {
            Crossout.AspWeb.Models.API.v2.MatchEntry match_entry = new Crossout.AspWeb.Models.API.v2.MatchEntry { };

            match_entry.match_id = match.match_data.server_guid;
            match_entry.status = "I";
            match_entry.uploader_uid = match.match_data.local_player.uid;
            match_entry.validation_count = 1;
            match_entry.match_type = match.match_data.match_type;
            match_entry.match_start = match.match_data.match_start.ToUniversalTime();
            match_entry.match_end = match.match_data.match_end.ToUniversalTime();
            match_entry.map_name = match.match_data.map_name;
            match_entry.winning_team = match.match_data.winning_team;
            match_entry.win_conidtion = 1; /*TODO*/
            match_entry.client_version = match.match_data.client_version;
            match_entry.game_server = match.match_data.server_ip;
            match_entry.rounds = populate_round_entrys(match);

            return match_entry;
        }

        private static List<Crossout.AspWeb.Models.API.v2.RoundEntry> populate_round_entrys(file_trace_managment.MatchRecord match)
        {
            List<Crossout.AspWeb.Models.API.v2.RoundEntry> rounds = new List<Crossout.AspWeb.Models.API.v2.RoundEntry> { };
            Crossout.AspWeb.Models.API.v2.RoundEntry new_round;
            //new_round.players = match.match_data.player_records;

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
                    Crossout.AspWeb.Models.API.v2.MatchPlayerEntry new_player = new Crossout.AspWeb.Models.API.v2.MatchPlayerEntry { };
                    new_player.match_id = match.match_data.server_guid;
                    new_player.round_id = i;
                    new_player.uid = player.uid;
                    new_player.team = player.team;
                    new_player.build_hash = player.build_hash;
                    new_player.kills = player.stats.kills;
                    new_player.assists = player.stats.assists;
                    new_player.drone_kills = player.stats.drone_kills;
                    new_player.score = player.stats.drone_kills;
                    new_player.damage = player.stats.damage;
                    new_player.damage_taken = player.stats.damage_taken;
                }
                rounds.Add(new_round);
                i++;
            }

            return rounds;
        }

        private static List<long> get_previously_uploaded_match_list(file_trace_managment.SessionStats Current_session)
        {
            List<long> previous_matchs = new List<long> { };


#if DEBUG
            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:5001/api/v2/co_driver/upload_records/" + Current_session.local_user_uid.ToString());
#else
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://crossoutdb.com/api/v2/co_driver/upload_records/" + Current_session.local_user_uid.ToString());
#endif

            MessageBox.Show("https://localhost:5001/api/v2/co_driver/upload_records/" + Current_session.local_user_uid.ToString());

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
                    MessageBox.Show(crossoutdb_json);
                    List<string> previous_match_string = JsonConvert.DeserializeObject<List<string>>(crossoutdb_json);
                    foreach (string match in previous_match_string)
                        previous_matchs.Add(Convert.ToInt64(match));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following problem occured when loading previous match list from crossoutdb.com" + Environment.NewLine + Environment.NewLine + ex.Message);
            }

            return previous_matchs;
        }

        private static void upload_match_to_crossoutdb(Crossout.AspWeb.Models.API.v2.MatchEntry match)
        {

#if DEBUG
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:5001/api/v2/GetCodUploadRecords?uid=");
#else
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://crossoutdb.com/api/v2/GetCodUploadRecords?uid=" + Current_session.local_user_uid.ToString());
#endif
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Timeout = 30000;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(@"{""object"":{""name"":""Name""}}");
            }

            try
            {
                WebResponse webResponse = request.GetResponse();

                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string crossoutdb_json = responseReader.ReadToEnd();
                    //market_items = JsonConvert.DeserializeObject<List<market_item>>(crossoutdb_json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following problem occured when loading data from crossoutdb.com" + Environment.NewLine + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "Defaults will be used.");
            }
        }
    }
}