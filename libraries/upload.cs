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
        //public static void upload_match_history(file_trace_managment.SessionStats Current_session, Dictionary<string, Dictionary<string, translate.Translation>> translations)
        //{
        //    Crossout.AspWeb.Models.API.v2.UploadReturn upload_return = get_previous_uploads(Current_session.local_user_uid);
        //    Crossout.AspWeb.Models.API.v2.UploadEntry upload_entry = new Crossout.AspWeb.Models.API.v2.UploadEntry { };
        //    upload_entry.uploader_uid = Current_session.local_user_uid;
        //    upload_entry.match_list = new List<Crossout.AspWeb.Models.API.v2.MatchEntry> { };

        //    foreach (file_trace_managment.MatchRecord match in Current_session.match_history)
        //    {
        //        if (upload_return.uploaded_matches.Contains(match.match_data.server_guid))
        //            continue;

        //        if (match.match_data.server_guid == 0)
        //            continue;

        //        if (match.match_data.local_player.uid == 0)
        //            continue;

        //        if (!match.match_data.match_rewards.Any())
        //            continue;

        //        if (match.match_data.winning_team == -1)
        //            continue;

        //        if (match.match_data.match_type == global_data.TEST_SERVER_MATCH)
        //            continue;

        //        if (match.match_data.match_type == global_data.CUSTOM_MATCH)
        //            continue;

        //        upload_entry.match_list.Add(populate_match_entry(match, translations));

        //        if (upload_entry.match_list.Count >= global_data.UPLOAD_LIST_SIZE)
        //        {
        //            upload_to_crossoutdb(upload_entry);
        //            upload_entry.match_list = new List<Crossout.AspWeb.Models.API.v2.MatchEntry> { };
        //        }
        //    }

        //    if (upload_entry.match_list.Any())
        //        upload_to_crossoutdb(upload_entry);
        //}

        public static Crossout.AspWeb.Models.API.v2.BuildEntry populate_build_entry(file_trace_managment.BuildRecord build)
        {
            Crossout.AspWeb.Models.API.v2.BuildEntry build_entry = new Crossout.AspWeb.Models.API.v2.BuildEntry { };

            build_entry.build_hash = build.build_hash;
            build_entry.power_score = build.power_score;
            build_entry.parts = build.parts;

            return build_entry;
        }

        public static Crossout.AspWeb.Models.API.v2.MatchEntry populate_match_entry(file_trace_managment.MatchRecord match, Dictionary<string, Dictionary<string, translate.Translation>> translations)
        {
            Crossout.AspWeb.Models.API.v2.MatchEntry match_entry = new Crossout.AspWeb.Models.API.v2.MatchEntry { };

            match_entry.match_id = match.match_data.server_guid;
            match_entry.match_type = match.match_data.match_type_desc;
            match_entry.match_classification = match.match_data.match_classification;
            match_entry.match_start = match.match_data.match_start.ToUniversalTime();
            match_entry.match_end = match.match_data.match_end.ToUniversalTime();
            match_entry.map_name = match.match_data.map_name;
            match_entry.map_display_name = translate.translate_string_english(match.match_data.map_desc, translations);
            match_entry.winning_team = match.match_data.winning_team;
            match_entry.win_conidtion = 1; /*TODO*/
            match_entry.co_driver_version = global_data.CURRENT_VERSION;
            if (match.match_data.client_version.Contains(" ")) 
                match_entry.client_version = match.match_data.client_version.Split(' ')[0];
            else
                match_entry.client_version = match.match_data.client_version;
            match_entry.host_name = match.match_data.host_name;
            match_entry.rounds = populate_round_entrys(match);
            match_entry.resources = new List<Crossout.AspWeb.Models.API.v2.ResourceEntry> { };

            foreach (KeyValuePair<string, int> reward in match.match_data.match_rewards.Where(x => x.Key != "score"))
                match_entry.resources.Add(new Crossout.AspWeb.Models.API.v2.ResourceEntry { resource = reward.Key, amount = reward.Value });

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
                new_round.damage_records = new List<Crossout.AspWeb.Models.API.v2.RoundDamageEntry> { };

                foreach (file_trace_managment.Player player in round.players)
                {
                    Crossout.AspWeb.Models.API.v2.MatchPlayerEntry new_player = new Crossout.AspWeb.Models.API.v2.MatchPlayerEntry { };
                    new_player.match_id = match.match_data.server_guid;
                    new_player.round_id = i;
                    new_player.uid = player.uid;
                    new_player.bot = player.bot;
                    new_player.nickname = player.nickname;
                    new_player.team = player.team;
                    new_player.group_id = player.party_id;
                    new_player.build_hash = player.build_hash;
                    new_player.power_score = player.power_score;
                    new_player.kills = player.stats.kills;
                    new_player.assists = player.stats.assists;
                    new_player.drone_kills = player.stats.drone_kills;
                    new_player.deaths = player.stats.deaths;
                    new_player.score = player.stats.score;
                    new_player.damage = player.stats.damage;
                    new_player.damage_taken = player.stats.damage_taken;
                    
                    new_player.scores = new List<Crossout.AspWeb.Models.API.v2.ScoreEntry> { };
                    new_player.medals = new List<Crossout.AspWeb.Models.API.v2.MedalEntry> { };

                    foreach (file_trace_managment.Score score in player.scores)
                        new_player.scores.Add(new Crossout.AspWeb.Models.API.v2.ScoreEntry { score_type = score.description, points = score.points });
                        
                    foreach (string stripe in player.stripes)
                    {
                        if (new_player.medals.Any(x => x.medal == stripe))
                            new_player.medals.First(x => x.medal == stripe).amount += 1;
                        else
                            new_player.medals.Add(new Crossout.AspWeb.Models.API.v2.MedalEntry { medal = stripe, amount = 1 });
                    }

                    new_round.players.Add(new_player);
                }

                foreach (file_trace_managment.RoundDamageRecord damage_record in round.damage_records)
                {
                    if (!round.players.Any(x => x.nickname == damage_record.attacker))
                        continue;

                    if (round.players.Any(x => x.nickname == damage_record.attacker && x.uid == 0))
                        continue;

                    Crossout.AspWeb.Models.API.v2.RoundDamageEntry new_damage_record = new Crossout.AspWeb.Models.API.v2.RoundDamageEntry { };
                    new_damage_record.uid = round.players.FirstOrDefault(x => x.nickname == damage_record.attacker).uid;
                    new_damage_record.weapon = damage_record.weapon;
                    new_damage_record.damage = damage_record.damage;
                    new_round.damage_records.Add(new_damage_record);
                }

                rounds.Add(new_round);
                i++;
            }

            return rounds;
        }

        public static Crossout.AspWeb.Models.API.v2.UploadReturn get_previous_uploads(int local_user_id)
        {
            Crossout.AspWeb.Models.API.v2.UploadReturn upload_return = new Crossout.AspWeb.Models.API.v2.UploadReturn { uploaded_matches = new List<long> { }, uploaded_builds = 0 };

#if DEBUG
            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:5001/api/v2/co_driver/upload_records/" + local_user_id.ToString());
#else
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://beta.crossoutdb.com/api/v2/co_driver/upload_records/" + local_user_id.ToString());
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
                    upload_return = JsonConvert.DeserializeObject<Crossout.AspWeb.Models.API.v2.UploadReturn>(crossoutdb_json);
                }
            }
            catch (WebException ex)
            {
                //if (ex.Status != WebExceptionStatus.Timeout)
                //{
                //    MessageBox.Show("The following web problem occured when loading data from crossoutdb.com" + Environment.NewLine + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following problem occured when loading previous match list from crossoutdb.com" + Environment.NewLine + Environment.NewLine + ex.Message);
            }

            return upload_return;
        }


        public static Crossout.AspWeb.Models.API.v2.UploadReturn upload_to_crossoutdb(Crossout.AspWeb.Models.API.v2.UploadEntry upload_entry)
        {
            Crossout.AspWeb.Models.API.v2.UploadReturn upload_return = new Crossout.AspWeb.Models.API.v2.UploadReturn { uploaded_matches = new List<long> { }, uploaded_builds = 0 };

            try
            {
                string serialized_match_list = JsonConvert.SerializeObject(upload_entry);

#if DEBUG
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:5001/api/v2/co_driver/upload_match_and_build");
#else
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://beta.crossoutdb.com/api/v2/co_driver/upload_match_and_build");
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
                    upload_return = JsonConvert.DeserializeObject<Crossout.AspWeb.Models.API.v2.UploadReturn>(crossoutdb_json);
                }
            }
            catch (WebException ex)
            {
                //if (ex.Status != WebExceptionStatus.Timeout)
                //{
                //    MessageBox.Show("The following web problem occured when loading data from crossoutdb.com" + Environment.NewLine + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "Defaults will be used.");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following problem occured when loading data from crossoutdb.com" + Environment.NewLine + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "Defaults will be used.");
            }

            return upload_return;
        }
    }
}
