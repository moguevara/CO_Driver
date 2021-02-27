namespace CO_Driver
{
    partial class fusion_calculator
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lable1 = new System.Windows.Forms.Label();
            this.tb_fusion_data = new System.Windows.Forms.DataGridView();
            this.fusion_attempts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.success_percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.event_part_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.event_part_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.standard_part_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.standard_part_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.num_reliabilty_target = new System.Windows.Forms.NumericUpDown();
            this.num_power_target = new System.Windows.Forms.NumericUpDown();
            this.num_handling_target = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.num_reliability_max = new System.Windows.Forms.NumericUpDown();
            this.num_power_max = new System.Windows.Forms.NumericUpDown();
            this.num_handling_max = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.num_item_cost = new System.Windows.Forms.NumericUpDown();
            this.btn_reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tb_fusion_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_reliabilty_target)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_power_target)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_handling_target)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_reliability_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_power_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_handling_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_item_cost)).BeginInit();
            this.SuspendLayout();
            // 
            // lable1
            // 
            this.lable1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lable1.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable1.Location = new System.Drawing.Point(0, 0);
            this.lable1.Name = "lable1";
            this.lable1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lable1.Size = new System.Drawing.Size(1195, 65);
            this.lable1.TabIndex = 0;
            this.lable1.Text = "Fusion Calculator";
            this.lable1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tb_fusion_data
            // 
            this.tb_fusion_data.AllowUserToOrderColumns = true;
            this.tb_fusion_data.BackgroundColor = System.Drawing.Color.Black;
            this.tb_fusion_data.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_fusion_data.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tb_fusion_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tb_fusion_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_fusion_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fusion_attempts,
            this.success_percent,
            this.event_part_count,
            this.event_part_cost,
            this.standard_part_count,
            this.standard_part_cost});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tb_fusion_data.DefaultCellStyle = dataGridViewCellStyle2;
            this.tb_fusion_data.EnableHeadersVisualStyles = false;
            this.tb_fusion_data.GridColor = System.Drawing.Color.Lime;
            this.tb_fusion_data.Location = new System.Drawing.Point(504, 68);
            this.tb_fusion_data.Name = "tb_fusion_data";
            this.tb_fusion_data.ReadOnly = true;
            this.tb_fusion_data.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tb_fusion_data.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tb_fusion_data.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.tb_fusion_data.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.tb_fusion_data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_fusion_data.Size = new System.Drawing.Size(643, 515);
            this.tb_fusion_data.TabIndex = 1;
            this.tb_fusion_data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // fusion_attempts
            // 
            this.fusion_attempts.HeaderText = "Fusion Attempts";
            this.fusion_attempts.Name = "fusion_attempts";
            this.fusion_attempts.ReadOnly = true;
            // 
            // success_percent
            // 
            this.success_percent.HeaderText = "Success %";
            this.success_percent.Name = "success_percent";
            this.success_percent.ReadOnly = true;
            // 
            // event_part_count
            // 
            this.event_part_count.HeaderText = "Event Part Count";
            this.event_part_count.Name = "event_part_count";
            this.event_part_count.ReadOnly = true;
            // 
            // event_part_cost
            // 
            this.event_part_cost.HeaderText = "Cost";
            this.event_part_cost.Name = "event_part_cost";
            this.event_part_cost.ReadOnly = true;
            // 
            // standard_part_count
            // 
            this.standard_part_count.HeaderText = "Standard Part Count";
            this.standard_part_count.Name = "standard_part_count";
            this.standard_part_count.ReadOnly = true;
            // 
            // standard_part_cost
            // 
            this.standard_part_cost.HeaderText = "Cost";
            this.standard_part_cost.Name = "standard_part_cost";
            this.standard_part_cost.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Please enter targeted fusions in each category.";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Reliability";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Power";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 5;
            this.label5.Text = "Handling";
            // 
            // num_reliabilty_target
            // 
            this.num_reliabilty_target.BackColor = System.Drawing.Color.Black;
            this.num_reliabilty_target.ForeColor = System.Drawing.Color.Lime;
            this.num_reliabilty_target.Location = new System.Drawing.Point(58, 123);
            this.num_reliabilty_target.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.num_reliabilty_target.Name = "num_reliabilty_target";
            this.num_reliabilty_target.Size = new System.Drawing.Size(39, 22);
            this.num_reliabilty_target.TabIndex = 6;
            this.num_reliabilty_target.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_reliabilty_target.ValueChanged += new System.EventHandler(this.calculator_changed);
            // 
            // num_power_target
            // 
            this.num_power_target.BackColor = System.Drawing.Color.Black;
            this.num_power_target.ForeColor = System.Drawing.Color.Lime;
            this.num_power_target.Location = new System.Drawing.Point(58, 183);
            this.num_power_target.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.num_power_target.Name = "num_power_target";
            this.num_power_target.Size = new System.Drawing.Size(39, 22);
            this.num_power_target.TabIndex = 7;
            this.num_power_target.ValueChanged += new System.EventHandler(this.calculator_changed);
            // 
            // num_handling_target
            // 
            this.num_handling_target.BackColor = System.Drawing.Color.Black;
            this.num_handling_target.ForeColor = System.Drawing.Color.Lime;
            this.num_handling_target.Location = new System.Drawing.Point(58, 243);
            this.num_handling_target.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.num_handling_target.Name = "num_handling_target";
            this.num_handling_target.Size = new System.Drawing.Size(39, 22);
            this.num_handling_target.TabIndex = 8;
            this.num_handling_target.ValueChanged += new System.EventHandler(this.calculator_changed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(103, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 24);
            this.label6.TabIndex = 9;
            this.label6.Text = "/";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(103, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 24);
            this.label7.TabIndex = 10;
            this.label7.Text = "/";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(103, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 24);
            this.label8.TabIndex = 11;
            this.label8.Text = "/";
            // 
            // num_reliability_max
            // 
            this.num_reliability_max.BackColor = System.Drawing.Color.Black;
            this.num_reliability_max.ForeColor = System.Drawing.Color.Lime;
            this.num_reliability_max.Location = new System.Drawing.Point(131, 121);
            this.num_reliability_max.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.num_reliability_max.Name = "num_reliability_max";
            this.num_reliability_max.Size = new System.Drawing.Size(39, 22);
            this.num_reliability_max.TabIndex = 12;
            this.num_reliability_max.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.num_reliability_max.ValueChanged += new System.EventHandler(this.calculator_changed);
            // 
            // num_power_max
            // 
            this.num_power_max.BackColor = System.Drawing.Color.Black;
            this.num_power_max.ForeColor = System.Drawing.Color.Lime;
            this.num_power_max.Location = new System.Drawing.Point(131, 183);
            this.num_power_max.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.num_power_max.Name = "num_power_max";
            this.num_power_max.Size = new System.Drawing.Size(39, 22);
            this.num_power_max.TabIndex = 13;
            this.num_power_max.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.num_power_max.ValueChanged += new System.EventHandler(this.calculator_changed);
            // 
            // num_handling_max
            // 
            this.num_handling_max.BackColor = System.Drawing.Color.Black;
            this.num_handling_max.ForeColor = System.Drawing.Color.Lime;
            this.num_handling_max.Location = new System.Drawing.Point(131, 243);
            this.num_handling_max.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.num_handling_max.Name = "num_handling_max";
            this.num_handling_max.Size = new System.Drawing.Size(39, 22);
            this.num_handling_max.TabIndex = 14;
            this.num_handling_max.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.num_handling_max.ValueChanged += new System.EventHandler(this.calculator_changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Cost Per Item";
            // 
            // num_item_cost
            // 
            this.num_item_cost.BackColor = System.Drawing.Color.Black;
            this.num_item_cost.ForeColor = System.Drawing.Color.Lime;
            this.num_item_cost.Location = new System.Drawing.Point(58, 333);
            this.num_item_cost.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.num_item_cost.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_item_cost.Name = "num_item_cost";
            this.num_item_cost.Size = new System.Drawing.Size(112, 22);
            this.num_item_cost.TabIndex = 16;
            this.num_item_cost.ThousandsSeparator = true;
            this.num_item_cost.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.num_item_cost.ValueChanged += new System.EventHandler(this.calculator_changed);
            // 
            // btn_reset
            // 
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reset.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.Location = new System.Drawing.Point(58, 553);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(112, 30);
            this.btn_reset.TabIndex = 17;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // fusion_calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.num_item_cost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_handling_max);
            this.Controls.Add(this.num_power_max);
            this.Controls.Add(this.num_reliability_max);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.num_handling_target);
            this.Controls.Add(this.num_power_target);
            this.Controls.Add(this.num_reliabilty_target);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_fusion_data);
            this.Controls.Add(this.lable1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.Name = "fusion_calculator";
            this.Size = new System.Drawing.Size(1195, 601);
            this.Load += new System.EventHandler(this.fusion_calculator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_fusion_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_reliabilty_target)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_power_target)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_handling_target)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_reliability_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_power_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_handling_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_item_cost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.DataGridView tb_fusion_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn fusion_attempts;
        private System.Windows.Forms.DataGridViewTextBoxColumn success_percent;
        private System.Windows.Forms.DataGridViewTextBoxColumn event_part_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn event_part_cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn standard_part_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn standard_part_cost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown num_power_target;
        private System.Windows.Forms.NumericUpDown num_handling_target;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown num_reliability_max;
        private System.Windows.Forms.NumericUpDown num_power_max;
        private System.Windows.Forms.NumericUpDown num_handling_max;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_item_cost;
        private System.Windows.Forms.NumericUpDown num_reliabilty_target;
        private System.Windows.Forms.Button btn_reset;
    }
}
