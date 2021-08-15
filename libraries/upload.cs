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

namespace CO_Driver.libraries
{
    public class upload
    {
        public static void upload_match_history(file_trace_managment.SessionStats Current_session)
        {
            foreach (file_trace_managment.MatchRecord match in Current_session.match_history)
            {
                if (match.match_data.server_guid == 0)
                    continue;


            }
        }

        public static Crossout.AspWeb.Models.API.v2.MatchEntry populate_match_entry(file_trace_managment.MatchRecord match)
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
            match_entry.rounds = populate_round_entry(match);

            return match_entry;
        }

        public static List<Crossout.AspWeb.Models.API.v2.RoundEntry> populate_round_entry(file_trace_managment.MatchRecord match)
        {
            List<Crossout.AspWeb.Models.API.v2.RoundEntry> rounds = new List<Crossout.AspWeb.Models.API.v2.RoundEntry> { };
            Crossout.AspWeb.Models.API.v2.RoundEntry new_round;
            //new_round.players = match.match_data.player_records;


            //foreach (file_trace_managment.RoundData round in match.match_data.rounds)
            //{
            //    new_round = new Crossout.AspWeb.Models.API.v2.RoundEntry { };
            //    new_round.match_id = match.match_data.server_guid;
            //    new_round.round_id = 0;
            //    new_round.round_start = round.round_start.ToUniversalTime();
            //    new_round.round_end = round.round_end.ToUniversalTime();
            //    new_round.winning_team = round.winning_team;
            //    new_round.players = new List<Crossout.AspWeb.Models.API.v2.PlayerEntry> { };
            //    new_round.damage_records = new List<Crossout.AspWeb.Models.API.v2.DamageEntry> { };
            //    rounds.Add(new_round);
            //}

            return rounds;
        }
    }
}
