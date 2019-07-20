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
            this.label4 = new System.Windows.Forms.Label();
            this.Dimension = new System.Windows.Forms.ComboBox();
            this.lblLoading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ServerName
            // 
            this.ServerName.Location = new System.Drawing.Point(150, 15);
            this.ServerName.Name = "ServerName";
            this.ServerName.Size = new System.Drawing.Size(140, 20);
            this.ServerName.TabIndex = 0;
            this.ServerName.Text = "CHOGMILOADDEV01";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter AS Server Name:";
            // 
            // Go
            // 
            this.Go.AutoSize = true;
            this.Go.Location = new System.Drawing.Point(296, 15);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(75, 23);
            this.Go.TabIndex = 2;
            this.Go.Text = "GO";
            this.Go.Click += new System.EventHandler(this.go_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName});
            this.dataGridView1.Location = new System.Drawing.Point(27, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(503, 360);
            this.dataGridView1.TabIndex = 3;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.HeaderText = "Attributes List";
            this.ColumnName.Name = "ColumnName";
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
            this.label2.TabIndex = 5;
            this.label2.Text = "Analysis Database :";
            // 
            // Cube
            // 
            this.Cube.FormattingEnabled = true;
            this.Cube.Location = new System.Drawing.Point(374, 52);
            this.Cube.Name = "Cube";
            this.Cube.Size = new System.Drawing.Size(156, 21);
            this.Cube.Sorted = true;
            this.Cube.TabIndex = 6;
            this.Cube.SelectedIndexChanged += new System.EventHandler(this.Cube_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cube : ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(551, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dimension : ";
            // 
            // Dimension
            // 
            this.Dimension.FormattingEnabled = true;
            this.Dimension.Location = new System.Drawing.Point(622, 49);
            this.Dimension.Name = "Dimension";
            this.Dimension.Size = new System.Drawing.Size(167, 21);
            this.Dimension.Sorted = true;
            this.Dimension.TabIndex = 9;
            this.Dimension.SelectedIndexChanged += new System.EventHandler(this.Dimension_SelectedIndexChanged);
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Location = new System.Drawing.Point(391, 16);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(54, 13);
            this.lblLoading.TabIndex = 10;
            this.lblLoading.Text = "Loading...";
            this.lblLoading.Visible = false;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(902, 538);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.Dimension);
            this.Controls.Add(this.label4);
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
        private Label label4;
        private ComboBox Dimension;
        private Label lblLoading;


    }
}

