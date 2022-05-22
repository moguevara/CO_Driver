using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class build_view : UserControl
    {
        private class BuildStats
        {
            public string build_hash;
            public int power_score;
            public file_trace_managment.Stats stats;
        }

        //public event EventHandler<string> load_selected_build;

        public file_trace_managment.MatchHistoryResponse match_history = new file_trace_managment.MatchHistoryResponse { };
        public Dictionary<string, file_trace_managment.BuildRecord> build_records = new Dictionary<string, file_trace_managment.BuildRecord> { };
        public Dictionary<string, Dictionary<string, translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        private Dictionary<string, BuildStats> build_stats = new Dictionary<string, BuildStats> { };
        public log_file_managment.session_variables session = new log_file_managment.session_variables { };
        public bool force_refresh = false;
        private Dictionary<string, int> weapon_usage = new Dictionary<string, int> { };
        private Dictionary<string, int> movement_usage = new Dictionary<string, int> { };
        private Dictionary<string, int> cabin_usage = new Dictionary<string, int> { };
        private Dictionary<string, int> module_usage = new Dictionary<string, int> { };
        private filter.FilterSelections filter_selections = filter.new_filter_selection();
        public Resize resize = new Resize { };
        private string new_selection = "";
        private string previous_selection = "";

        public build_view()
        {
            InitializeComponent();

        }

        private void populate_build_records()
        {


            build_stats = new Dictionary<string, BuildStats> { };



            foreach (file_trace_managment.MatchRecord match in match_history.match_history.ToList())
            {
                if (!filter.check_filters(filter_selections, match, build_records, session, translations))
                    continue;

                if (!build_stats.ContainsKey(match.match_data.local_player.build_hash))
                {
                    build_stats.Add(match.match_data.local_player.build_hash, new BuildStats { build_hash = match.match_data.local_player.build_hash, power_score = match.match_data.local_player.power_score, stats = match.match_data.local_player.stats });
                }
                else
                {
                    build_stats[match.match_data.local_player.build_hash].stats = file_trace_managment.sum_stats(build_stats[match.match_data.local_player.build_hash].stats, match.match_data.local_player.stats);
                }
            }

            filter.populate_filters(filter_selections, cb_game_modes, cb_grouped, cb_power_score, cb_versions, cb_weapons, cb_movement, cb_cabins, cb_modules);
        }

        public void populate_build_record_table()
        {
            if (!force_refresh)
            {
                new_selection = filter.filter_string(filter_selections);

                if (new_selection == previous_selection)
                    return;
            }

            force_refresh = false;
            previous_selection = new_selection;
            filter.reset_filters(filter_selections);

            populate_build_records();
            this.dg_build_view_grid.Rows.Clear();
            this.dg_build_view_grid.AllowUserToAddRows = true;
            int rows_populated = 0;

            this.lb_build_desc.Text = "";
            this.lb_cabin.Text = "";
            this.dg_module_list.Rows.Clear();
            this.dg_movement_list.Rows.Clear();
            this.dg_weapon_list.Rows.Clear();
            this.lb_game_count.Text = "";
            this.lb_win_rate.Text = "";
            this.lb_kills.Text = "";
            this.lb_assists.Text = "";
            this.lb_deaths.Text = "";
            this.lb_kda.Text = "";
            this.lb_damage.Text = "";
            this.lb_damage_rec.Text = "";
            this.lb_score.Text = "";
            this.lb_parts.Text = "";

            dg_build_view_grid.Columns[7].DefaultCellStyle.Format = "P0";

            foreach (KeyValuePair<string, BuildStats> build in build_stats)
            {
                DataGridViewRow row = (DataGridViewRow)this.dg_build_view_grid.Rows[0].Clone();
                row.Cells[0].Value = build.Key;
                row.Cells[1].Value = build.Value.power_score;
                row.Cells[2].Value = build.Value.stats.games;
                row.Cells[3].Value = build.Value.stats.kills;
                row.Cells[4].Value = Math.Round(build.Value.stats.deaths > 0 ? (double)build.Value.stats.kills / (double)build.Value.stats.deaths : Double.PositiveInfinity, 2);
                row.Cells[5].Value = Math.Round((double)build.Value.stats.damage / (double)build.Value.stats.rounds, 0);
                row.Cells[6].Value = Math.Round((double)build.Value.stats.damage_taken / (double)build.Value.stats.rounds, 0);
                row.Cells[7].Value = (double)build.Value.stats.wins / (double)build.Value.stats.games;

                this.dg_build_view_grid.Rows.Add(row);
                rows_populated++;
            }

            this.dg_build_view_grid.Sort(this.dg_build_view_grid.Columns[2], ListSortDirection.Descending);

            string build_hash = "";

            if (rows_populated > 0)
                build_hash = this.dg_build_view_grid.Rows[0].Cells[0].Value.ToString();

            if (rows_populated > 0 && build_records.ContainsKey(build_hash) && build_stats.ContainsKey(build_hash))
            {
                this.lb_build_desc.Text = build_records[build_hash].full_description;
                this.lb_cabin.Text = translate.translate_string(build_records[build_hash].cabin.name, session, translations);
                this.lb_game_count.Text = build_stats[build_hash].stats.games.ToString();
                this.lb_win_rate.Text = ((double)build_stats[build_hash].stats.wins / (double)build_stats[build_hash].stats.games).ToString("P1");
                this.lb_kills.Text = build_stats[build_hash].stats.kills.ToString();
                this.lb_assists.Text = build_stats[build_hash].stats.assists.ToString();
                this.lb_deaths.Text = build_stats[build_hash].stats.deaths.ToString();
                this.lb_kda.Text = (((double)build_stats[build_hash].stats.kills + (double)build_stats[build_hash].stats.assists) / (double)build_stats[build_hash].stats.games).ToString("N2");
                this.lb_damage.Text = (build_stats[build_hash].stats.damage / (double)build_stats[build_hash].stats.games).ToString("N1");
                this.lb_damage_rec.Text = (build_stats[build_hash].stats.damage_taken / (double)build_stats[build_hash].stats.games).ToString("N1");
                this.lb_score.Text = ((double)build_stats[build_hash].stats.score / (double)build_stats[build_hash].stats.games).ToString("N0");
                this.lb_parts.Text = string.Join(", ", build_records[build_hash].parts.Select(x => translate.translate_string(x, session, translations)));

                dg_movement_list.Rows.Clear();
                dg_movement_list.AllowUserToAddRows = true;

                foreach (string part in build_records[build_hash].movement.Select(x => translate.translate_string(x.name, session, translations)))
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_movement_list.Rows[0].Clone();
                    row.Cells[0].Value = part;
                    dg_movement_list.Rows.Add(row);
                }

                dg_movement_list.AllowUserToAddRows = false;
                dg_movement_list.ClearSelection();

                dg_weapon_list.Rows.Clear();
                dg_weapon_list.AllowUserToAddRows = true;

                foreach (string part in build_records[build_hash].weapons.Select(x => translate.translate_string(x.name, session, translations)))
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_weapon_list.Rows[0].Clone();
                    row.Cells[0].Value = part;
                    dg_weapon_list.Rows.Add(row);
                }

                dg_weapon_list.AllowUserToAddRows = false;
                dg_weapon_list.ClearSelection();

                dg_module_list.Rows.Clear();
                dg_module_list.AllowUserToAddRows = true;

                foreach (string part in build_records[build_hash].modules.Select(x => translate.translate_string(x.name, session, translations)).Append(translate.translate_string(build_records[build_hash].engine.name, session, translations)))
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_module_list.Rows[0].Clone();
                    row.Cells[0].Value = part;
                    dg_module_list.Rows.Add(row);
                }

                foreach (string part in build_records[build_hash].explosives.Select(x => translate.translate_string(x.name, session, translations)))
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_module_list.Rows[0].Clone();
                    row.Cells[0].Value = part;
                    dg_module_list.Rows.Add(row);
                }

                dg_module_list.AllowUserToAddRows = false;
                dg_module_list.ClearSelection();


            }

            this.dg_build_view_grid.AllowUserToAddRows = false;
            this.dg_build_view_grid.Sort(this.dg_build_view_grid.Columns[2], ListSortDirection.Descending);
            this.lb_build_desc.Focus();
            this.dg_build_view_grid.ClearSelection();
        }

        private void dg_build_view_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dg_build_view_grid.Rows.Count > 0 && e.RowIndex >= 0)
            {
                string build_hash = this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                load_build_hash(build_hash);


            }
        }

        public void load_build_hash(string build_hash)
        {
            if (build_records.ContainsKey(build_hash) && build_stats.ContainsKey(build_hash))
            {
                this.lb_build_desc.Text = build_records[build_hash].full_description;
                this.lb_cabin.Text = translate.translate_string(build_records[build_hash].cabin.name, session, translations);
                this.lb_game_count.Text = build_stats[build_hash].stats.games.ToString();
                this.lb_win_rate.Text = ((double)build_stats[build_hash].stats.wins / (double)build_stats[build_hash].stats.games).ToString("P1");
                this.lb_kills.Text = build_stats[build_hash].stats.kills.ToString();
                this.lb_assists.Text = build_stats[build_hash].stats.assists.ToString();
                this.lb_deaths.Text = build_stats[build_hash].stats.deaths.ToString();
                this.lb_kda.Text = (((double)build_stats[build_hash].stats.kills + (double)build_stats[build_hash].stats.assists) / (double)build_stats[build_hash].stats.games).ToString("N2");
                this.lb_damage.Text = (build_stats[build_hash].stats.damage / (double)build_stats[build_hash].stats.games).ToString("N1");
                this.lb_damage_rec.Text = (build_stats[build_hash].stats.damage_taken / (double)build_stats[build_hash].stats.games).ToString("N1");
                this.lb_score.Text = ((double)build_stats[build_hash].stats.score / (double)build_stats[build_hash].stats.games).ToString("N0");
                this.lb_parts.Text = string.Join(", ", build_records[build_hash].parts.Select(x => translate.translate_string(x, session, translations)));

                dg_movement_list.Rows.Clear();
                dg_movement_list.AllowUserToAddRows = true;

                foreach (string part in build_records[build_hash].movement.Select(x => translate.translate_string(x.name, session, translations)))
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_movement_list.Rows[0].Clone();
                    row.Cells[0].Value = part;
                    dg_movement_list.Rows.Add(row);
                }

                dg_movement_list.AllowUserToAddRows = false;
                dg_movement_list.ClearSelection();

                dg_weapon_list.Rows.Clear();
                dg_weapon_list.AllowUserToAddRows = true;

                foreach (string part in build_records[build_hash].weapons.Select(x => translate.translate_string(x.name, session, translations)))
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_weapon_list.Rows[0].Clone();
                    row.Cells[0].Value = part;
                    dg_weapon_list.Rows.Add(row);
                }

                dg_weapon_list.AllowUserToAddRows = false;
                dg_weapon_list.ClearSelection();

                dg_module_list.Rows.Clear();
                dg_module_list.AllowUserToAddRows = true;

                foreach (string part in build_records[build_hash].modules.Select(x => translate.translate_string(x.name, session, translations)).Append(translate.translate_string(build_records[build_hash].engine.name, session, translations)))
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_module_list.Rows[0].Clone();
                    row.Cells[0].Value = part;
                    dg_module_list.Rows.Add(row);
                }

                foreach (string part in build_records[build_hash].explosives.Select(x => translate.translate_string(x.name, session, translations)))
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_module_list.Rows[0].Clone();
                    row.Cells[0].Value = part;
                    dg_module_list.Rows.Add(row);
                }

                dg_module_list.AllowUserToAddRows = false;
                dg_module_list.ClearSelection();
            }
            else
            {
                this.lb_build_desc.Text = "";
                this.lb_cabin.Text = "";
                this.dg_module_list.Rows.Clear();
                this.dg_movement_list.Rows.Clear();
                this.dg_weapon_list.Rows.Clear();
                this.lb_game_count.Text = "";
                this.lb_win_rate.Text = "";
                this.lb_kills.Text = "";
                this.lb_assists.Text = "";
                this.lb_deaths.Text = "";
                this.lb_kda.Text = "";
                this.lb_damage.Text = "";
                this.lb_damage_rec.Text = "";
                this.lb_score.Text = "";
                this.lb_parts.Text = "";
            }
        }

        private void build_view_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            resize.record_initial_sizes(this);
        }

        private void dg_build_view_grid_SelectionChanged(object sender, EventArgs e)
        {
            this.dg_build_view_grid.Invalidate();
        }

        private void btn_save_user_settings_Click(object sender, EventArgs e)
        {
            filter.reset_filter_selections(filter_selections);

            dt_start_date.Value = DateTime.Now;
            dt_end_date.Value = DateTime.Now;

            populate_build_record_table();
        }

        private void cb_game_modes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.game_mode_filter == this.cb_game_modes.Text)
                return;

            if (this.cb_game_modes.SelectedIndex >= 0)
                filter_selections.game_mode_filter = this.cb_game_modes.Text;

            populate_build_record_table();
        }

        private void cb_grouped_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.group_filter == this.cb_grouped.Text)
                return;

            if (this.cb_grouped.SelectedIndex >= 0)
                filter_selections.group_filter = this.cb_grouped.Text;

            populate_build_record_table();
        }

        private void cb_power_score_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.power_score_filter == this.cb_power_score.Text)
                return;

            if (this.cb_power_score.SelectedIndex >= 0)
                filter_selections.power_score_filter = this.cb_power_score.Text;

            populate_build_record_table();
        }

        private void cb_versions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.client_versions_filter == this.cb_versions.Text)
                return;

            if (this.cb_versions.SelectedIndex >= 0)
                filter_selections.client_versions_filter = this.cb_versions.Text;

            populate_build_record_table();
        }

        private void cb_movement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.movement_filter == this.cb_movement.Text)
                return;

            if (this.cb_movement.SelectedIndex >= 0)
                filter_selections.movement_filter = this.cb_movement.Text;

            populate_build_record_table();
        }

        private void cb_modules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.module_filter == this.cb_modules.Text)
                return;

            if (this.cb_modules.SelectedIndex >= 0)
                filter_selections.module_filter = this.cb_modules.Text;

            populate_build_record_table();
        }

        private void cb_weapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.weapons_filter == this.cb_weapons.Text)
                return;

            if (this.cb_weapons.SelectedIndex >= 0)
                filter_selections.weapons_filter = this.cb_weapons.Text;

            populate_build_record_table();
        }

        private void cb_cabins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.cabin_filter == this.cb_cabins.Text)
                return;

            if (this.cb_cabins.SelectedIndex >= 0)
                filter_selections.cabin_filter = this.cb_cabins.Text;

            populate_build_record_table();
        }

        private void dt_end_date_ValueChanged(object sender, EventArgs e)
        {
            if (filter_selections.end_date == dt_end_date.Value)
                return;

            filter_selections.end_date = dt_end_date.Value;
            populate_build_record_table();
        }

        private void dt_start_date_ValueChanged(object sender, EventArgs e)
        {
            if (filter_selections.start_date == dt_start_date.Value)
                return;

            filter_selections.start_date = dt_start_date.Value;
            populate_build_record_table();
        }

        private void build_view_Resize(object sender, EventArgs e)
        {
            resize.resize(this);
        }
    }
}

