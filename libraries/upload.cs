using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace CO_Driver
{
    public class Upload
    {
        public static Crossout.AspWeb.Models.API.v2.BuildEntry PopulateBuildEntry(FileTraceManagment.BuildRecord build)
        {
            Crossout.AspWeb.Models.API.v2.BuildEntry build_entry = new Crossout.AspWeb.Models.API.v2.BuildEntry { };

            build_entry.build_hash = build.BuildHash;
            build_entry.power_score = build.PowerScore;
            build_entry.parts = build.Parts;

            return build_entry;
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
                    Crossout.AspWeb.Models.API.v2.MatchPlayerEntry new_player = new Crossout.AspWeb.Models.API.v2.MatchPlayerEntry { };
                    new_player.match_id = match.MatchData.ServerGUID;
                    new_player.round_id = i;
                    new_player.uid = player.UID;
                    new_player.bot = player.Bot;
                    new_player.nickname = player.Nickname;
                    new_player.team = player.Team;
                    new_player.group_id = player.PartyID;
                    new_player.build_hash = player.BuildHash;
                    new_player.power_score = player.PowerScore;
                    new_player.kills = player.Stats.Kills;
                    new_player.assists = player.Stats.Assists;
                    new_player.drone_kills = player.Stats.DroneKills;
                    new_player.deaths = player.Stats.Deaths;
                    new_player.score = player.Stats.Score;
                    new_player.damage = player.Stats.Damage;
                    new_player.damage_taken = player.Stats.DamageTaken;

                    new_player.scores = new List<Crossout.AspWeb.Models.API.v2.ScoreEntry> { };
                    new_player.medals = new List<Crossout.AspWeb.Models.API.v2.MedalEntry> { };

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
                    new_damage_record.damage = damage_record.Damage;
                    new_round.damage_records.Add(new_damage_record);
                }

                rounds.Add(new_round);
                i++;
            }

            return rounds;
        }

        public static Crossout.AspWeb.Models.API.v2.UploadReturn GetPreviousUploads(int localUserID)
        {
            Crossout.AspWeb.Models.API.v2.UploadReturn upload_return = new Crossout.AspWeb.Models.API.v2.UploadReturn { uploaded_matches = new List<long> { }, uploaded_builds = 0 };

            var httpClient = new HttpClient();
#if DEBUG
            httpClient.BaseAddress = new Uri("https://beta.crossoutdb.com");
#else
            httpClient.BaseAddress = new Uri("https://beta.crossoutdb.com");
#endif

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(@"{""object"":{""name"":""Name""}}", Encoding.ASCII, "application/json");

            try
            {
                var response = httpClient.PostAsync($"/api/v2/co_driver/upload_records/{localUserID}", content).Result;

                response.EnsureSuccessStatusCode();

                string crossoutdb_json = response.Content.ReadAsStringAsync().Result;
                upload_return = JsonConvert.DeserializeObject<Crossout.AspWeb.Models.API.v2.UploadReturn>(crossoutdb_json);
            }
            catch (WebException)
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

        public static Crossout.AspWeb.Models.API.v2.UploadReturn UploadToCrossoutDB(Crossout.AspWeb.Models.API.v2.UploadEntry uploadEntry)
        {
            Crossout.AspWeb.Models.API.v2.UploadReturn upload_return = new Crossout.AspWeb.Models.API.v2.UploadReturn { uploaded_matches = new List<long> { }, uploaded_builds = 0 };

            try
            {
                string serialized_match_list = JsonConvert.SerializeObject(uploadEntry);

                var httpClient = new HttpClient();
#if DEBUG
                httpClient.BaseAddress = new Uri("https://beta.crossoutdb.com");
#else
                httpClient.BaseAddress = new Uri("https://beta.crossoutdb.com");
#endif

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(serialized_match_list, Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync("/api/v2/co_driver/upload_match_and_build", content).Result;

                response.EnsureSuccessStatusCode();

                string crossoutdb_json = response.Content.ReadAsStringAsync().Result;
                upload_return = JsonConvert.DeserializeObject<Crossout.AspWeb.Models.API.v2.UploadReturn>(crossoutdb_json);
            }
            catch (WebException)
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
