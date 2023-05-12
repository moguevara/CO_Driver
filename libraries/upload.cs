using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CO_Driver
{
    public class Upload
    {
        public enum Domain
        {
            ALL,
            CrossoutDB, 
            XOStat
        }

        public static Crossout.AspWeb.Models.API.v2.BuildEntry PopulateBuildEntry(FileTraceManagment.BuildRecord build)
        {
            Crossout.AspWeb.Models.API.v2.BuildEntry build_entry = new Crossout.AspWeb.Models.API.v2.BuildEntry { };

            build_entry.build_hash = build.BuildHash;
            build_entry.power_score = build.PowerScore;
            build_entry.parts = build.Parts;

            return build_entry;
        }

        public static Crossout.AspWeb.Models.API.v2.UploadEntry BuildNextBatchForUpload(Domain domain, LogFileManagment.SessionVariables session, List<FileTraceManagment.MatchRecord> match_history, 
                                                Dictionary<string, FileTraceManagment.BuildRecord> build_records, Dictionary<string, Dictionary<string, Translate.Translation>> translations,
                                                ref List<long> uploaded_matches, ref List<string> uploaded_builds)
        {
            Crossout.AspWeb.Models.API.v2.UploadEntry crossoutdb_upload_entry = new Crossout.AspWeb.Models.API.v2.UploadEntry { uploader_uid = session.LocalUserID, match_list = new List<Crossout.AspWeb.Models.API.v2.MatchEntry> { }, build_list = new List<Crossout.AspWeb.Models.API.v2.BuildEntry> { } };

            foreach (FileTraceManagment.MatchRecord match in match_history)
            {
                if (!ValidMatch(match, uploaded_matches))
                    continue;

                foreach (FileTraceManagment.RoundRecord round in match.MatchData.RoundRecords)
                {
                    foreach (FileTraceManagment.Player player in round.Players)
                    {
                        if (!build_records.ContainsKey(player.BuildHash))
                            continue;

                        if (build_records[player.BuildHash].Parts.Count == 0)
                            continue;

                        if (build_records[player.BuildHash].PowerScore == 0)
                            continue;

                        if (uploaded_builds.Contains(player.BuildHash))
                            continue;

                        uploaded_builds.Add(player.BuildHash);
                        crossoutdb_upload_entry.build_list.Add(Upload.PopulateBuildEntry(build_records[player.BuildHash]));
                    }
                }
                crossoutdb_upload_entry.match_list.Add(Upload.PopulateMatchEntry(match, translations));

                if (crossoutdb_upload_entry.match_list.Count >= GlobalData.UPLOAD_LIST_SIZE)
                    return crossoutdb_upload_entry;
            }

            return crossoutdb_upload_entry;
        }

        public static bool ValidMatch(FileTraceManagment.MatchRecord match, List<long> uploaded)
        {
            if (uploaded.Contains(match.MatchData.ServerGUID))
                return false;

            return ValidMatch(match);
        }

        public static bool ValidMatch(FileTraceManagment.MatchRecord match)
        {
            if (match.MatchData.ServerGUID == 0)
                return false;

            if (match.MatchData.LocalPlayer.UID == 0)
                return false;

            if (match.MatchData.PlayerRecords.Any(x => x.Value.UID == 0 && x.Value.Bot == 0))
                return false;

            if (!match.MatchData.MatchRewards.Any())
                return false;

            if (match.MatchData.WinningTeam == -1)
                return false;

            if (match.MatchData.MatchType == GlobalData.TEST_SERVER_MATCH)
                return false;

            if (match.MatchData.MatchType == GlobalData.CUSTOM_MATCH)
                return false;

            return true;
        }

        public static Crossout.AspWeb.Models.API.v2.MatchEntry PopulateMatchEntry(FileTraceManagment.MatchRecord match, Dictionary<string, Dictionary<string, Translate.Translation>> translations)
        {
            Crossout.AspWeb.Models.API.v2.MatchEntry match_entry = new Crossout.AspWeb.Models.API.v2.MatchEntry { };

            match_entry.match_id = match.MatchData.ServerGUID;
            match_entry.match_type = match.MatchData.MatchTypeDesc;
            match_entry.match_classification = match.MatchData.MatchClassification;
            match_entry.match_start = match.MatchData.MatchStart.ToUniversalTime();
            match_entry.match_end = match.MatchData.MatchEnd.ToUniversalTime();
            match_entry.map_name = match.MatchData.MapName;
            match_entry.map_display_name = Translate.TranslateStringEnglish(match.MatchData.MapDesc, translations);
            match_entry.winning_team = match.MatchData.WinningTeam;
            match_entry.win_conidtion = 1; /*TODO*/
            match_entry.co_driver_version = GlobalData.CURRENT_VERSION;
            if (match.MatchData.ClientVersion.Contains(" "))
                match_entry.client_version = match.MatchData.ClientVersion.Split(' ')[0];
            else
                match_entry.client_version = match.MatchData.ClientVersion;
            match_entry.host_name = match.MatchData.HostName;
            match_entry.rounds = PopulateRoundEntrys(match);
            match_entry.resources = new List<Crossout.AspWeb.Models.API.v2.ResourceEntry> { };

            foreach (KeyValuePair<string, int> reward in match.MatchData.MatchRewards.Where(x => x.Key != "score"))
                match_entry.resources.Add(new Crossout.AspWeb.Models.API.v2.ResourceEntry { resource = reward.Key, amount = reward.Value });

            return match_entry;
        }

        public static List<Crossout.AspWeb.Models.API.v2.RoundEntry> PopulateRoundEntrys(FileTraceManagment.MatchRecord match)
        {
            List<Crossout.AspWeb.Models.API.v2.RoundEntry> rounds = new List<Crossout.AspWeb.Models.API.v2.RoundEntry> { };
            Crossout.AspWeb.Models.API.v2.RoundEntry new_round;

            int i = 0;
            foreach (FileTraceManagment.RoundRecord round in match.MatchData.RoundRecords)
            {
                new_round = new Crossout.AspWeb.Models.API.v2.RoundEntry { };
                new_round.match_id = match.MatchData.ServerGUID;
                new_round.round_id = i;
                new_round.round_start = round.RoundStart.ToUniversalTime();
                new_round.round_end = round.RoundEnd.ToUniversalTime();
                new_round.winning_team = round.WinningTeam;
                new_round.players = new List<Crossout.AspWeb.Models.API.v2.MatchPlayerEntry> { };
                new_round.damage_records = new List<Crossout.AspWeb.Models.API.v2.RoundDamageEntry> { };

                foreach (FileTraceManagment.Player player in round.Players)
                {
                    Crossout.AspWeb.Models.API.v2.MatchPlayerEntry new_player = new Crossout.AspWeb.Models.API.v2.MatchPlayerEntry
                    {
                        match_id = match.MatchData.ServerGUID,
                        round_id = i,
                        uid = player.UID,
                        bot = player.Bot,
                        nickname = player.Nickname,
                        team = player.Team,
                        group_id = player.PartyID,
                        build_hash = player.BuildHash,
                        power_score = player.PowerScore,
                        kills = player.Stats.Kills,
                        assists = player.Stats.Assists,
                        drone_kills = player.Stats.DroneKills,
                        deaths = player.Stats.Deaths,
                        score = player.Stats.Score,
                        damage = Math.Round(player.Stats.Damage, 2),
                        //new_player.cabin_damage = Math.Round(player.Stats.CabinDamage, 2);
                        damage_taken = Math.Round(player.Stats.DamageTaken, 2),

                        scores = new List<Crossout.AspWeb.Models.API.v2.ScoreEntry> { },
                        medals = new List<Crossout.AspWeb.Models.API.v2.MedalEntry> { }
                    };

                    foreach (FileTraceManagment.Score score in player.Scores)
                        new_player.scores.Add(new Crossout.AspWeb.Models.API.v2.ScoreEntry { score_type = score.Description, points = score.Points });

                    foreach (string stripe in player.Stripes)
                    {
                        if (new_player.medals.Any(x => x.medal == stripe))
                            new_player.medals.First(x => x.medal == stripe).amount += 1;
                        else
                            new_player.medals.Add(new Crossout.AspWeb.Models.API.v2.MedalEntry { medal = stripe, amount = 1 });
                    }

                    new_round.players.Add(new_player);
                }

                foreach (FileTraceManagment.RoundDamageRecord damage_record in round.DamageRecords)
                {
                    if (!round.Players.Any(x => x.Nickname == damage_record.Attacker))
                        continue;

                    if (round.Players.Any(x => x.Nickname == damage_record.Attacker && x.UID == 0))
                        continue;

                    Crossout.AspWeb.Models.API.v2.RoundDamageEntry new_damage_record = new Crossout.AspWeb.Models.API.v2.RoundDamageEntry { };
                    new_damage_record.uid = round.Players.FirstOrDefault(x => x.Nickname == damage_record.Attacker).UID;
                    new_damage_record.weapon = damage_record.Weapon;
                    new_damage_record.damage = Math.Round(damage_record.Damage, 2);
                    new_round.damage_records.Add(new_damage_record);
                }

                rounds.Add(new_round);
                i++;
            }

            return rounds;
        }

        public static Crossout.AspWeb.Models.API.v2.UploadReturn GetPreviousUploads(int localUserID, Domain domain)
        {
            Crossout.AspWeb.Models.API.v2.UploadReturn upload_return = new Crossout.AspWeb.Models.API.v2.UploadReturn { uploaded_matches = new List<long> { }, uploaded_builds = 0 };

            string url = "";

            if (domain == Domain.CrossoutDB)
            {
#if DEBUG
                url = "https://beta.crossoutdb.com/api/v2/co_driver/upload_records/" + localUserID.ToString();
#else
                url = "https://beta.crossoutdb.com/api/v2/co_driver/upload_records/" + localUserID.ToString();
#endif
            }
            else if (domain == Domain.XOStat)
            {
#if DEBUG
                url = "http://localhost:3000/dev/player/" + localUserID.ToString();
#else
                url = "https://s0lfp19zc9.execute-api.us-east-2.amazonaws.com/dev/player/" + localUserID.ToString();
#endif
            }
            else
            {
                throw new Exception("Invalid Domain");
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = @"CO_Driver";
            request.Accept = "text/html";
            request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            request.Method = "GET";
            request.Timeout = 30000;

            try
            {
                using (WebResponse response = request.GetResponse())
                using (Stream webStream = response.GetResponseStream() ?? Stream.Null)
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
                MessageBox.Show("The following request:" + url + Environment.NewLine + Environment.NewLine + "Had the following problem occured when loading previous match list from crossoutdb.com/xostat.gg" + Environment.NewLine + Environment.NewLine + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following problem occured when loading previous match list from crossoutdb.com" + Environment.NewLine + Environment.NewLine + ex.Message);
            }

            return upload_return;
        }

        public static Crossout.AspWeb.Models.API.v2.UploadReturn UploadToDomain(Crossout.AspWeb.Models.API.v2.UploadEntry uploadEntry, Domain domain)
        {
            Crossout.AspWeb.Models.API.v2.UploadReturn upload_return = new Crossout.AspWeb.Models.API.v2.UploadReturn { uploaded_matches = new List<long> { }, uploaded_builds = 0 };
            string url = "";

            if (domain == Domain.CrossoutDB)
            {
#if DEBUG
                url = "https://localhost:5001/api/v2/co_driver/upload_match_and_build";
#else
                url = "https://beta.crossoutdb.com/api/v2/co_driver/upload_match_and_build";
#endif
            }
            else if (domain == Domain.XOStat)
            {
#if DEBUG
                url = "http://localhost:3000/dev/upload";
#else
                url = "https://s0lfp19zc9.execute-api.us-east-2.amazonaws.com/dev/upload";
#endif
            }
            else
            {
                throw new Exception("Invalid Domain");
            }

            string serialized_match_list = JsonConvert.SerializeObject(uploadEntry);
            File.WriteAllText("C:\\Users\\morgh\\Documents\\CO_Driver\\test.json", serialized_match_list);

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var content = new StringContent(serialized_match_list, Encoding.ASCII, "application/json");
                    HttpResponseMessage response = client.PostAsync(url, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<Crossout.AspWeb.Models.API.v2.UploadReturn>(response.Content.ReadAsStringAsync().Result);
                    }
                    else
                    {
                        MessageBox.Show($"Error message: {response.Content.ReadAsStringAsync().Result}");
                        throw new HttpRequestException($"Error: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The following problem occured when loading previous match list from xostat.gg" + Environment.NewLine + Environment.NewLine + ex.Message);
                }
            }

            return upload_return;
        }
    }
}
