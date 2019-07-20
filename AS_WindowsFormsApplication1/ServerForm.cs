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
        public ServerForm()
        {
            InitializeComponent();
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
                string connectionString;
                connectionString = "DataSource=" + ServerName.Text;
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
                string connectionString;
                connectionString = "DataSource=" + ServerName.Text;
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
            ComboBox C = (ComboBox)sender;

            
            using (Server S = new Server())
            {
                string connectionString;
                connectionString = "DataSource=" + ServerName.Text;
                S.Connect(connectionString);

              
                Cube cube = S.Databases.GetByName(ASDatabase.SelectedItem.ToString()).Cubes.GetByName(Cube.SelectedItem.ToString());



                Dimension.DataSource = cube.Dimensions;
                Dimension.DisplayMember = "name";
                Dimension.ValueMember = "id";
                Dimension.DropDownStyle = ComboBoxStyle.DropDownList;

            }

        }

        private void Dimension_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (Server S = new Server())
            {
                string connectionString;
                connectionString = "DataSource=" + ServerName.Text;
                S.Connect(connectionString);

                CubeDimension CD = S.Databases.GetByName(ASDatabase.SelectedItem.ToString()).Cubes.GetByName(Cube.SelectedItem.ToString()).Dimensions.GetByName(Dimension.SelectedItem.ToString());
                Dimension D = CD.Dimension;

                
                DataTable AT = GetAttributesByDimension(D);
                //dataGridView1.Columns.Remove("Attributes List");
                dataGridView1.DataSource = AT;
                //dataGridView1.DataBind();
            }
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

        //private static DataAggregationMode GetDataSourceViewDefinitionByTableID(System.Data.DataTable DT)
        //{

        //    if (DT.ExtendedProperties["TableType"].ToString() == "Table")
        //        Console.Write(DT.ExtendedProperties["FriendlyName"] + " | " + DT.ExtendedProperties["TableType"] + " | " + DT.ExtendedProperties["DbTableName"] + "\n");
        //    else
        //        Console.Write(DT.ExtendedProperties["FriendlyName"] + " | " + DT.ExtendedProperties["TableType"] + " | " + DT.ExtendedProperties["QueryDefinition"] + "\n");
        //}

    }
}
