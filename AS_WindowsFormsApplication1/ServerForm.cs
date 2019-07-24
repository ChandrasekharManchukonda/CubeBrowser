using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AnalysisServices;

namespace AS_WindowsFormsApplication
{
    public partial class ServerForm : Form
    {
        string connectionString;

        public ServerForm()
        {
            InitializeComponent();
            connectionString = "DataSource=" + ServerName.Text;
        }


        public void ServerForm_Load(object sender, EventArgs e)
        {

        }

        public void label1_Click(object sender, EventArgs e)
        {
            Label L = (Label)sender;
            L.Text = "Test";
        }

        public void go_Click(object sender, EventArgs e)
        {
            lblLoading.Visible = true;
            this.Refresh();

             using (Server S = new Server())
            {
                S.Connect(connectionString);
                // SetDataGridView_ASDatabases(S);
                SetCombobox_ASDatabases(S);
           
            }

             lblLoading.Visible = false;

        }
      
        btnTextChange bc = new btnTextChange(text_change);

        public static void text_change(string s, Button B)
        {
            B.Text = s;
        }

        public static void btntext_change(string s, Button B)
        {
            B.Text = s;
        }

        private void ServerForm_Load_1(object sender, EventArgs e)
        {
            //MessageBox.Show("In Form Load");
        }

        public void SetDataGridView_ASDatabases(Server S)
        {
            DatabaseCollection DC = S.Databases;
            foreach (Database D in DC)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = D.Name;

            }  
        }

        public void SetCombobox_ASDatabases(Server S)
        {
            ASDatabase.DataSource = S.Databases ;
            ASDatabase.DisplayMember = "name";
            ASDatabase.ValueMember = "id";
            ASDatabase.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //getASDataBaseList(ServerName.Text);
        }


        public void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox C = (ComboBox)sender;
            
            using (Server S = new Server())
            {
                S.Connect(connectionString);

                Database D = S.Databases.GetByName(C.SelectedItem.ToString());
                //MessageBox.Show("DB Name Combo SelectedItem: " + C.SelectedItem.ToString());
                //MessageBox.Show("DB Name C: " + C.Text);


                Cube.DataSource = D.Cubes;
                Cube.DisplayMember = "name";
                Cube.ValueMember = "id";
                Cube.DropDownStyle = ComboBoxStyle.DropDownList;

            }
            //SetCubesDropdown(S);
        }

        public void Cube_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //ComboBox C = (ComboBox)sender;

            rbDimension.Checked = false;
            rbMeasureGroups.Checked = false;
            rbCalculatedMembers.Checked = false;
            Dimension.Visible = false;
            
            dataGridView1.DataSource = null;
            PartitionsGrid.DataSource = null;
            //using (Server S = new Server())
            //{
            //    string connectionString;
            //    connectionString = "DataSource=" + ServerName.Text;
            //    S.Connect(connectionString);

              
            //    Cube cube = S.Databases.GetByName(ASDatabase.SelectedItem.ToString()).Cubes.GetByName(Cube.SelectedItem.ToString());



            //    Dimension.DataSource = cube.Dimensions;
            //    Dimension.DisplayMember = "name";
            //    Dimension.ValueMember = "id";
            //    Dimension.DropDownStyle = ComboBoxStyle.DropDownList;

            //}

        }

        private void Dimension_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ASDatabase.SelectedIndex > -1 && Cube.SelectedIndex > -1 && Dimension.SelectedIndex > -1)
            {

                using (Server S = new Server())
                {
                    S.Connect(connectionString);
                    if (rbDimension.Checked == true)
                    {
                        CubeDimension CD = S.Databases.GetByName(ASDatabase.SelectedItem.ToString()).Cubes.GetByName(Cube.SelectedItem.ToString()).Dimensions.GetByName(Dimension.SelectedItem.ToString());
                        Dimension D = CD.Dimension;


                        DataTable AT = GetAttributesByDimension(D);
                        //dataGridView1.Columns.Remove("Attributes List");
                        dataGridView1.DataSource = AT;
                        //dataGridView1.DataBind();
                    }

                    if (rbMeasureGroups.Checked == true)
                    {
                            MeasureGroup MG = S.Databases.GetByName(ASDatabase.SelectedItem.ToString()).Cubes.GetByName(Cube.SelectedItem.ToString()).MeasureGroups.GetByName(Dimension.SelectedItem.ToString());
                            MeasureCollection MC = MG.Measures;

                            DataTable MA = getMeasureAttributes(MC);
                            dataGridView1.DataSource = MA;

                            DataTable PT = getMeasureGroupPartitions(MG);
                            PartitionsGrid.DataSource = PT;
                            
                     }
                }
            }
        }

        private DataTable getMeasureGroupPartitions(MeasureGroup MG)
        {
            DataTable PT = new DataTable();
            PT.Columns.Add("Partition Name");
            PT.Columns.Add("Source");
            PT.Columns.Add("Estimated Size in Bytes");
            PT.Columns.Add("Estimated Rows");
            PT.Columns.Add("Status");


            //PT.Columns.Add("DataSource");
            //PT.Columns.Add("DataSourceView");
            //PT.Columns.Add("DirectQueryUsage");
            //PT.Columns.Add("ID");
            //PT.Columns.Add("IsLoaded");
            //PT.Columns.Add("LastProcessed");
            //PT.Columns.Add("LastSchemaUpdate");
            //PT.Columns.Add("Parent");
            //PT.Columns.Add("Slice");
            //PT.Columns.Add("Type");


            PartitionCollection PC = MG.Partitions;
            foreach (Partition P in PC)
            {
                
                if (P.Source.ToString() == "Microsoft.AnalysisServices.QueryBinding")
                {

                    PT.Rows.Add(P.Name, ((QueryBinding)P.Source).QueryDefinition.ToString(), P.EstimatedSize, P.EstimatedRows, P.State
                        //, P.DataSource, P.DataSourceView, P.DirectQueryUsage
                        //, P.ID
                        //, P.IsLoaded, P.LastProcessed
                        //, P.LastSchemaUpdate, P.Parent, P.Slice, P.Type
                        );
                }
                else
                {
                    //MessageBox.Show("Test");

                    //MeasureGroupBinding MGB = MG.Source;
                    DsvTableBinding DVB = (DsvTableBinding)P.Source; //(DsvTableBinding)MGB.Clone();

                    //MessageBox.Show(DVB.TableID.ToString());
                    //MessageBox.Show(P.DataSourceView.Schema.Tables[DVB.TableID].ToString());

                    PT.Rows.Add(P.Name, P.DataSourceView.Schema.Tables[DVB.TableID].ToString(), P.EstimatedSize, P.EstimatedRows, P.State
                        //, P.DataSource, P.DataSourceView, P.DirectQueryUsage
                        //, P.ID
                        //, P.IsLoaded, P.LastProcessed
                        //, P.LastSchemaUpdate, P.Parent, P.Slice, P.Type
                        );

                }


            }

            return PT;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        public DataTable GetAttributesByDimension(Dimension D)
        {

            DimensionAttributeCollection DAC = D.Attributes;
                DataTable DT = new DataTable();
                DT.Columns.Add("Attribue Name");
                DT.Columns.Add("Table/View/Query");
                DT.Columns.Add("Source Key Column");
                DT.Columns.Add("Source Name Column");
                DT.Columns.Add("Usage");
                DT.Columns.Add("FriendlyName");
                DT.Columns.Add("TableType");

                DataSourceView DS = D.DataSourceView;
                DataSet d = new DataSet();
                d = DS.Schema;
                
            try
            {

            foreach (DimensionAttribute DA in DAC)
            {
                //Console.Write(DA.Name + "\t|\t " + DA.Usage + " | ");
                DataItemCollection DIC = DA.KeyColumns;
                //DA.AttributeHierarchyEnabled;
                //DA.DerivedFromTableId;
                //DA.IsAggregatable;
                
                foreach (DataItem DI in DIC)
                {
                    ColumnBinding CB = (ColumnBinding)DI.Source;

                    string source = DI.Source.ToString();
                    string NameColumn = DA.NameColumn.ToString();

                    DataTable VT = d.Tables[CB.TableID];

                    if (VT.ExtendedProperties["QueryDefinition"] != null)
                    {
                        DT.Rows.Add(DA.Name
                         , VT.ExtendedProperties["QueryDefinition"].ToString()
                         , source.Substring(source.IndexOf(".") + 1)
                         , NameColumn.Substring(NameColumn.IndexOf(".") + 1)
                         , DA.Usage
                         , VT.ExtendedProperties["FriendlyName"]
                        , "NamedQuery"
                        );
                    }
                    else
                    {
                        DT.Rows.Add(DA.Name
                         , VT.ExtendedProperties["DbTableName"]
                         , source.Substring(source.IndexOf(".") + 1)
                         , NameColumn.Substring(NameColumn.IndexOf(".") + 1)
                         , DA.Usage
                         , VT.ExtendedProperties["FriendlyName"]
                        , VT.ExtendedProperties["TableType"]
                        );
                    }

                    //Console.Write(DI.DataType + " | " + DI.Source + " | ");

                    
                    //GetDataSourceViewDefinitionByTableID(VT);
                }
            }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
            return(DT);
        }

        private void rbDimension_CheckedChanged(object sender, EventArgs e)
        {

            if (rbDimension.Checked == true && ASDatabase.SelectedIndex > -1 && Cube.SelectedIndex > -1 )
            {

                Dimension.Visible = true;
                PartitionsGrid.Visible = false;
                PartitionsGrid.DataSource = null;
                
                using (Server S = new Server())
                {
                    S.Connect(connectionString);
                    Cube cube = S.Databases.GetByName(ASDatabase.SelectedItem.ToString()).Cubes.GetByName(Cube.SelectedItem.ToString());
                    
                    Dimension.DataSource = cube.Dimensions;
                    Dimension.DisplayMember = "name";
                    Dimension.ValueMember = "id";
                    Dimension.DropDownStyle = ComboBoxStyle.DropDownList;

                }
            }
        }

        private void lblMeasures_Click(object sender, EventArgs e)
        {

        }

        private void rbMeasureGroups_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMeasureGroups.Checked == true && ASDatabase.SelectedIndex > -1 && Cube.SelectedIndex > -1 )
            {

                Dimension.Visible = true;
                using (Server S = new Server())
                {
                    S.Connect(connectionString);
                    Cube cube = S.Databases.GetByName(ASDatabase.SelectedItem.ToString()).Cubes.GetByName(Cube.SelectedItem.ToString());

                    Dimension.DataSource = cube.MeasureGroups;
                    Dimension.DisplayMember = "name";
                    Dimension.ValueMember = "id";
                    Dimension.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
        }

        //private void comboBoxMeasureGroups_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (Dimension.SelectedIndex > -1)
        //    {
        //        using (Server S = new Server())
        //        {
        //            string connectionString;
        //            connectionString = "DataSource=" + ServerName.Text;
        //            S.Connect(connectionString);


        //            MeasureGroup MG = S.Databases.GetByName(ASDatabase.SelectedItem.ToString()).Cubes.GetByName(Cube.SelectedItem.ToString()).MeasureGroups.GetByName(Dimension.SelectedItem.ToString());
        //            MeasureCollection MC = MG.Measures;

        //            DataTable MA = getMeasureAttributes(MC);
        //            dataGridView1.DataSource = MA;
        //        }
        //    }
        //}

        public DataTable getMeasureAttributes(MeasureCollection MC)
        {

            DataTable MA = new DataTable();
            MA.Columns.Add("Measure Name");
            MA.Columns.Add("Source Table");
            MA.Columns.Add("Source Column");
            MA.Columns.Add("Aggregate User");

            foreach (Measure M in MC)
            {

                DataSourceView DS = M.ParentCube.DataSourceView;
                DataSet d = new DataSet();
                d = DS.Schema;

                DataItem DI = M.Source;
                DataTable DT ;
                string MeasureName = M.Name;
                string Aggregate = M.AggregateFunction.ToString();
                string MeasureSourceColumn;

                if (M.Visible == true)
                {
                    if (DI.Source.GetType().ToString() == "Microsoft.AnalysisServices.ColumnBinding")
                    {
                        ColumnBinding CB = (ColumnBinding)DI.Source;
                        DT = d.Tables[CB.TableID];
                        MeasureSourceColumn = CB.ColumnID;

                    }
                    else
                    {
                        RowBinding RB = (RowBinding)DI.Source;
                        DT = d.Tables[RB.TableID];
                        MeasureSourceColumn = "Rows";
                    }

                    string MeasureSourceTable = DT.ExtendedProperties["DbTableName"].ToString();

                    //MessageBox.Show(MeasureSourceTable);
                    //MessageBox.Show(MeasureSourceColumn);
                    //MessageBox.Show(Aggregate);

                    MA.Rows.Add(MeasureName, MeasureSourceTable, MeasureSourceColumn, Aggregate);
                }
               
            }

            return MA;
        }

        private void bdCalculatedMembers_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCalculatedMembers.Checked == true && ASDatabase.SelectedIndex > -1 && Cube.SelectedIndex > -1)
            {
                Dimension.Visible = true;
                MessageBox.Show("In method");
                Dimension.DataSource = null;
                using (Server S = new Server())
                {
                    S.Connect(connectionString);
                    Cube cube = S.Databases.GetByName(ASDatabase.SelectedItem.ToString()).Cubes.GetByName(Cube.SelectedItem.ToString());

                    MdxScript M = cube.MdxScripts[0];
                    foreach (CalculationProperty CP in M.CalculationProperties)
                    {
                        MessageBox.Show(CP.CalculationType.ToString());
                        if (CP.CalculationType == CalculationType.Member)
                        {
                            MessageBox.Show(CP.CalculationReference);
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PartitionsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        //private static DataAggregationMode GetDataSourceViewDefinitionByTableID(System.Data.DataTable DT)
        //{

        //    if (DT.ExtendedProperties["TableType"].ToString() == "Table")
        //        Console.Write(DT.ExtendedProperties["FriendlyName"] + " | " + DT.ExtendedProperties["TableType"] + " | " + DT.ExtendedProperties["DbTableName"] + "\n");
        //    else
        //        Console.Write(DT.ExtendedProperties["FriendlyName"] + " | " + DT.ExtendedProperties["TableType"] + " | " + DT.ExtendedProperties["QueryDefinition"] + "\n");
        //}

    }
}
