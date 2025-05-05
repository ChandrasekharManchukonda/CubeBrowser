using System.Drawing;
using System.Windows.Forms;
using Microsoft.AnalysisServices;

namespace AS_WindowsFormsApplication
{
    partial class ServerForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ServerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Go = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASDatabase = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Cube = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Dimension = new System.Windows.Forms.ComboBox();
            this.lblLoading = new System.Windows.Forms.Label();
            this.rbDimension = new System.Windows.Forms.RadioButton();
            this.rbMeasureGroups = new System.Windows.Forms.RadioButton();
            this.rbCalculatedMembers = new System.Windows.Forms.RadioButton();
            this.PartitionsGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartitionsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ServerName
            // 
            this.ServerName.Location = new System.Drawing.Point(150, 15);
            this.ServerName.Name = "ServerName";
            this.ServerName.Size = new System.Drawing.Size(140, 20);
            this.ServerName.TabIndex = 1;
            //this.ServerName.Text = "CHOGMILOADDEV01";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter AS Server Name:";
            // 
            // Go
            // 
            this.Go.AutoSize = true;
            this.Go.Location = new System.Drawing.Point(296, 15);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(75, 23);
            this.Go.TabIndex = 3;
            this.Go.Text = "GO";
            this.Go.Click += new System.EventHandler(this.go_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName});
            this.dataGridView1.Location = new System.Drawing.Point(27, 166);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(503, 360);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.HeaderText = "Details Grid";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Visible = false;
            // 
            // ASDatabase
            // 
            this.ASDatabase.FormattingEnabled = true;
            this.ASDatabase.Location = new System.Drawing.Point(150, 54);
            this.ASDatabase.Name = "ASDatabase";
            this.ASDatabase.Size = new System.Drawing.Size(173, 21);
            this.ASDatabase.Sorted = true;
            this.ASDatabase.TabIndex = 4;
            this.ASDatabase.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Analysis Database :";
            // 
            // Cube
            // 
            this.Cube.FormattingEnabled = true;
            this.Cube.Location = new System.Drawing.Point(374, 52);
            this.Cube.Name = "Cube";
            this.Cube.Size = new System.Drawing.Size(156, 21);
            this.Cube.Sorted = true;
            this.Cube.TabIndex = 5;
            this.Cube.SelectedIndexChanged += new System.EventHandler(this.Cube_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cube : ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Dimension
            // 
            this.Dimension.FormattingEnabled = true;
            this.Dimension.Location = new System.Drawing.Point(258, 102);
            this.Dimension.Name = "Dimension";
            this.Dimension.Size = new System.Drawing.Size(167, 21);
            this.Dimension.Sorted = true;
            this.Dimension.TabIndex = 8;
            this.Dimension.Visible = false;
            this.Dimension.SelectedIndexChanged += new System.EventHandler(this.Dimension_SelectedIndexChanged);
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Location = new System.Drawing.Point(391, 16);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(54, 13);
            this.lblLoading.TabIndex = 0;
            this.lblLoading.Text = "Loading...";
            this.lblLoading.Visible = false;
            // 
            // rbDimension
            // 
            this.rbDimension.AutoSize = true;
            this.rbDimension.Location = new System.Drawing.Point(53, 106);
            this.rbDimension.Name = "rbDimension";
            this.rbDimension.Size = new System.Drawing.Size(79, 17);
            this.rbDimension.TabIndex = 6;
            this.rbDimension.TabStop = true;
            this.rbDimension.Text = "Dimensions";
            this.rbDimension.UseVisualStyleBackColor = true;
            this.rbDimension.CheckedChanged += new System.EventHandler(this.rbDimension_CheckedChanged);
            // 
            // rbMeasureGroups
            // 
            this.rbMeasureGroups.AutoSize = true;
            this.rbMeasureGroups.Location = new System.Drawing.Point(138, 106);
            this.rbMeasureGroups.Name = "rbMeasureGroups";
            this.rbMeasureGroups.Size = new System.Drawing.Size(103, 17);
            this.rbMeasureGroups.TabIndex = 7;
            this.rbMeasureGroups.TabStop = true;
            this.rbMeasureGroups.Text = "Measure Groups";
            this.rbMeasureGroups.UseVisualStyleBackColor = true;
            this.rbMeasureGroups.CheckedChanged += new System.EventHandler(this.rbMeasureGroups_CheckedChanged);
            // 
            // rbCalculatedMembers
            // 
            this.rbCalculatedMembers.AutoSize = true;
            this.rbCalculatedMembers.Location = new System.Drawing.Point(248, 110);
            this.rbCalculatedMembers.Name = "rbCalculatedMembers";
            this.rbCalculatedMembers.Size = new System.Drawing.Size(121, 17);
            this.rbCalculatedMembers.TabIndex = 15;
            this.rbCalculatedMembers.TabStop = true;
            this.rbCalculatedMembers.Text = "Calculated Members";
            this.rbCalculatedMembers.UseVisualStyleBackColor = true;
            this.rbCalculatedMembers.CheckedChanged += new System.EventHandler(this.bdCalculatedMembers_CheckedChanged);
            // 
            // PartitionsGrid
            // 
            this.PartitionsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PartitionsGrid.Location = new System.Drawing.Point(555, 166);
            this.PartitionsGrid.Name = "PartitionsGrid";
            this.PartitionsGrid.RowHeadersVisible = false;
            this.PartitionsGrid.Size = new System.Drawing.Size(335, 360);
            this.PartitionsGrid.TabIndex = 10;
            this.PartitionsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PartitionsGrid_CellContentClick);
            this.PartitionsGrid.Visible = false;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(902, 538);
            this.Controls.Add(this.PartitionsGrid);
            this.Controls.Add(this.rbMeasureGroups);
            this.Controls.Add(this.rbDimension);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.Dimension);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Cube);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ASDatabase);
            this.Controls.Add(this.ServerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Go);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ServerForm";
            this.Text = "AS Form";
            this.Load += new System.EventHandler(this.ServerForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartitionsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //private void go_Click(object sender, ButtonEventArgs e)
        //{
        //    using (Server S = new Server())
        //    {
        //        S.Connect(e.connectionString);
        //        // SetDataGridView_ASDatabases(S);
        //        SetCombobox_ASDatabases(S);
        //    }
        //}


        #endregion

        private TextBox ServerName;
        private Label label1;
        private Button Go;
        public DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColumnName;
        private ComboBox ASDatabase;
        private Label label2;
        private ComboBox Cube;
        private Label label3;
        private ComboBox Dimension;
        private Label lblLoading;
        private RadioButton rbDimension;
        private RadioButton rbMeasureGroups;
        private RadioButton rbCalculatedMembers;
        public DataGridView PartitionsGrid;


    }
}

