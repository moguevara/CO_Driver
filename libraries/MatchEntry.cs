using System;
using System.Collections.Generic;
using System.Text;

namespace Crossout.AspWeb.Models.API.v2
{
    public class UploadEntry
    {
        public int uploader_uid { get; set; }
        public List<MatchEntry> match_list { get; set; }
    }

    public class MatchEntry
    {
        public long match_id { get; set; }
        public string match_type { get; set; }
        public DateTime match_start { get; set; }
        public DateTime match_end { get; set; }
        public string map_name { get; set; }
        public string map_display_name { get; set; }
        public int winning_team { get; set; }
        public int win_conidtion { get; set; }
        public string client_version { get; set; }
        public string co_driver_version { get; set; }
        public string game_server { get; set; }
        public List<RoundEntry> rounds { get; set; }
        public List<ResourceEntry> resources { get; set; }
    }

    public class RoundEntry
    {
        public long match_id { get; set; }
        public int round_id { get; set; }
        public DateTime round_start { get; set; }
        public DateTime round_end { get; set; }
        public int winning_team { get; set; }
        public List<MatchPlayerEntry> players { get; set; }
        public List<RoundDamageEntry> damage_records { get; set; }
    }

    public class MatchPlayerEntry
    {
        public long match_id { get; set; }
        public int round_id { get; set; }
        public int uid { get; set; }
        public string nickname { get; set; }
        public int team { get; set; }
        public int group_id { get; set; }
        public string build_hash { get; set; }
        public int power_score { get; set; }
        public int kills { get; set; }
        public int assists { get; set; }
        public int drone_kills { get; set; }
        public int score { get; set; }
        public double damage { get; set; }
        public double damage_taken { get; set; }
        public List<ScoreEntry> scores { get; set; }
        public List<MedalEntry> medals { get; set; }
    }
    public class RoundDamageEntry
    {
        public int uid { get; set; }
        public string weapon { get; set; }
        public double damage { get; set; }
    }

    public class ResourceEntry
    {
        public string resource { get; set; }
        public int amount { get; set; }
    }

    public class ScoreEntry
    {
        public string score_type { get; set; }
        public int points { get; set; }
    }
    public class MedalEntry
    {
        public string medal { get; set; }
        public int amount { get; set; }
    }
}
