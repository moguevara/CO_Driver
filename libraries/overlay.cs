using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO_Driver
{
    public class overlay
    {
        public const int MATCH_END_CONDITION = 1;
        public const int MAIN_MENU_CONDITION = 2;
        public const int GARAGE_START_CONDITION = 3;
        public const int PLAYER_LOAD_CONDITION = 4;
        public const int DAMAGE_CONDITION = 5;

        public const int STAT_CARD_OVERLAY = 1;
        public const int TEAM_PREVIEW_OVERLAY = 2;
        public const int DAMAGE_REC_OVERLAY = 3;
        public const int MATCH_RECAP_OVERLAY = 4;

        public class overlay_action
        {
            public int overlay { get; set; }
            public List<int> draw_conditions { get; set; }
            public List<int> clear_conditions { get; set; }
        }

        public static string default_overlay_setup()
        {
            return JsonConvert.SerializeObject(new List<overlay_action> { new overlay_action { overlay = STAT_CARD_OVERLAY, draw_conditions = new List<int> { MATCH_END_CONDITION }, clear_conditions = new List<int> { MAIN_MENU_CONDITION } },
                                                                          new overlay_action { overlay = TEAM_PREVIEW_OVERLAY, draw_conditions = new List<int> { PLAYER_LOAD_CONDITION }, clear_conditions = new List<int> { MAIN_MENU_CONDITION } },
                                                                          new overlay_action { overlay = DAMAGE_REC_OVERLAY, draw_conditions = new List<int> { GARAGE_START_CONDITION, DAMAGE_CONDITION }, clear_conditions = new List<int> { MAIN_MENU_CONDITION } },
                                                                          new overlay_action { overlay = MATCH_RECAP_OVERLAY, draw_conditions = new List<int> { GARAGE_START_CONDITION }, clear_conditions = new List<int> { MAIN_MENU_CONDITION } }});
        }

        public void resolve_overlay_action(file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session, int condition)
        {
            if (session.twitch_mode != true)
                return;

            foreach (overlay_action action in JsonConvert.DeserializeObject<List<overlay.overlay_action>>(session.action_configuration))
            {
                if (action.draw_conditions.Contains(condition))
                {
                    switch (condition)
                    {
                        case STAT_CARD_OVERLAY:
                            draw_stat_card(Current_session, session, true);
                            break;
                        case TEAM_PREVIEW_OVERLAY:
                            draw_team_preview_card(Current_session, session, true);
                            break;
                        case DAMAGE_REC_OVERLAY:
                            draw_damage_record_card(Current_session, session, true);
                            break;
                        case MATCH_RECAP_OVERLAY:
                            draw_match_recap_card(Current_session, session, true);
                            break;
                        default:
                            break;
                    }
                }

                if (action.clear_conditions.Contains(condition))
                {
                    switch (condition)
                    {
                        case STAT_CARD_OVERLAY:
                            draw_stat_card(Current_session, session, false);
                            break;
                        case TEAM_PREVIEW_OVERLAY:
                            draw_team_preview_card(Current_session, session, false);
                            break;
                        case DAMAGE_REC_OVERLAY:
                            draw_damage_record_card(Current_session, session, false);
                            break;
                        case MATCH_RECAP_OVERLAY:
                            draw_match_recap_card(Current_session, session, false);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void draw_stat_card(file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session, bool draw)
        {
            List<String> lines = new List<String> { };

            if (draw)
            {

            }

            File.WriteAllLines(Current_session.file_data.stream_overlay_output_location + @"\gamemode_statistics_card.txt", lines);
        }

        public void draw_team_preview_card(file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session, bool draw)
        {
            List<String> lines = new List<String> { };

            if (draw)
            {

            }

            File.WriteAllLines(Current_session.file_data.stream_overlay_output_location + @"\current_teams_in_game.txt", lines);
        }

        public void draw_damage_record_card(file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session, bool draw)
        {
            List<String> lines = new List<String> { };

            if (draw)
            {

            }

            File.WriteAllLines(Current_session.file_data.stream_overlay_output_location + @"\gamemode_statistics_card.txt", lines);
        }

        public void draw_match_recap_card(file_trace_managment.SessionStats Current_session, log_file_managment.session_variables session, bool draw)
        {
            List<String> lines = new List<String> { };

            if (draw)
            {

            }

            File.WriteAllLines(Current_session.file_data.stream_overlay_output_location + @"\last_match_recap.txt", lines);
        }

    }
}
