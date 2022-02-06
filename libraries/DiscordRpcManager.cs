using DiscordRPC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO_Driver
{
    public class DiscordRpcManager
    {
        public DiscordRpcClient client { get; set; }
        public bool Enabled { get; set; }

        public DiscordRpcManager(bool enabled)
        {
			client = new DiscordRpcClient("939795639120842762");

			//Subscribe to events
			client.OnReady += (sender, e) =>
			{
				Debug.WriteLine("Received Ready from user {0}", e.User.Username);
			};

			client.OnPresenceUpdate += (sender, e) =>
			{
				Debug.WriteLine("Received Update! {0}", e.Presence);
			};

			//Connect to the RPC
			client.Initialize();

            this.Enabled = enabled;
            if (!enabled) return;

			client.SetPresence(new RichPresence()
			{
				Details = "Playing Crossout"
			});
		}

		public void hangleEvent(file_trace_managment.SessionStats current_session, log_file_managment.session_variables session, Dictionary<string, Dictionary<string, translate.Translation>> translations)
        {
            if (!Enabled) return;
            RichPresence presence = new RichPresence();
            presence.Details = "Playing Crossout";
            presence.Assets = new Assets()
            {
                LargeImageKey = "xo_logo",
                SmallImageKey = "cod_logo"
            };

            if (current_session.in_garage)
            {
                presence.State = "In garage";
                presence.Timestamps = new Timestamps()
                {
                    Start = current_session.garage_data.garage_start.ToUniversalTime()
                };
            }
            else if(current_session.in_match)
            {
                presence.Details = "Playing Crossout";
                presence.State = translate.translate_string(current_session.current_match.gameplay_desc, session, translations);
                if (current_session.current_match.local_player.party_id != 0)
                {
                    presence.Party = new Party()
                    {
                        ID = current_session.current_match.local_player.party_id + "",
                        Max = 4,
                        Privacy = Party.PrivacySetting.Private,
                        Size = current_session.current_match.getPartyById(current_session.current_match.local_player.party_id).Count
                    };
                }

                if(current_session.current_match.match_start!=DateTime.MinValue)
                    presence.Timestamps = new Timestamps()
                    {
                        Start = current_session.current_match.match_start.ToUniversalTime()
                    };
            }
            else
            {
                if (current_session.queue_start_time != DateTime.MinValue)
                {
                    presence.State = "Waiting in queue";
                    presence.Timestamps = new Timestamps()
                    {
                        Start = current_session.queue_start_time.ToUniversalTime()
                    };
                }

                //not in match nor in garage
            }
            client.SetPresence(presence);
            /*
            switch (current_session.current_event)
            {
                case global_data.MATCH_START_EVENT:

                    break;
                case global_data.GAME_PLAY_START_EVENT:

                    break;
                case global_data.LOAD_PLAYER_EVENT:

                    break;
                case global_data.SPAWN_PLAYER_EVENT:

                    break;
                case global_data.DAMAGE_EVENT:

                    break;
                case global_data.STRIPE_EVENT:

                    break;
                case global_data.KILL_EVENT:

                    break;
                case global_data.ASSIST_EVENT:

                    break;
                case global_data.SCORE_EVENT:

                    break;
                case global_data.CW_ROUND_END_EVENT:

                    break;
                case global_data.MAIN_MENU_EVENT:

                    break;
                case global_data.TEST_DRIVE_EVENT:

                    break;
                case global_data.MATCH_END_EVENT:

                    break;
                case global_data.ADD_MOB_EVENT:

                    break;
            }*/
        }
    }
}
