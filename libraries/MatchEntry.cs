using System;
using System.Collections.Generic;
using System.Text;

namespace Crossout.AspWeb.Models.API.v2
{
    public class MatchEntry
    {
        public long match_id { get; set; }
        public string status { get; set; }
        public int uploader_uid { get; set; }
        public int validation_count { get; set; }
        public int match_type { get; set; }
        public DateTime match_start { get; set; }
        public DateTime match_end { get; set; }
        public string map_name { get; set; }
        public int winning_team { get; set; }
        public int win_conidtion { get; set; }
        public string client_version { get; set; }
        public string co_driver_version { get; set; }
        public string game_server { get; set; }
        public List<RoundEntry> rounds { get; set; }
    }

    public class RoundEntry
    {
        public long match_id { get; set; }
        public int round_id { get; set; }
        public DateTime round_start { get; set; }
        public DateTime round_end { get; set; }
        public int winning_team { get; set; }
        public List<MatchPlayerEntry> players { get; set; }
    }

    public class MatchPlayerEntry
    {
        public long match_id { get; set; }
        public int round_id { get; set; }
        public int uid { get; set; }
        public int team { get; set; }
        public string build_hash { get; set; }
        public int kills { get; set; }
        public int assists { get; set; }
        public int drone_kills { get; set; }
        public int score { get; set; }
        public double damage { get; set; }
        public double damage_taken { get; set; }
    }
}
