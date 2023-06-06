using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gala_darbs
{
  
    public partial class Guest_view : Form
    {

        BindingSource bs = new BindingSource();
        BindingSource bs1 = new BindingSource();
        BindingSource bs2 = new BindingSource();




        public Guest_view( DataSet ds,ToolStripComboBox  table_list)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            dataGridView3.DataSource = ds.Tables["Wedding"]; //bs
            dataGridView1.DataSource = ds.Tables["Wedding"];  //bs1
            dataGridView2.DataSource = ds.Tables["invintation"];// bs.2

             dataGridView3.DataMember = ds.Relations["guests_wedding_rel"].RelationName;

            DataGridViewComboBoxColumn cb1 = new DataGridViewComboBoxColumn();
            cb1.HeaderText = "wedding_name";
            cb1.Name = "id_wedding";
            cb1.DataSource = ds.Tables["wedding"];
            cb1.DisplayMember = "wedding_name";
            cb1.ValueMember = "id_wedding";
            cb1.DataPropertyName = "id_wedding";
            dataGridView3.Columns.Add(cb1);



            DataGridViewComboBoxColumn cb2 = new DataGridViewComboBoxColumn();
            cb2.HeaderText = "invintation";
            cb2.Name = "id_invintation";
            cb2.DataSource = ds.Tables["invintation"];
            cb2.DisplayMember = "invintation_text";
            cb2.ValueMember = "id_invintation";
            cb2.DataPropertyName = "id_invintation";
            dataGridView3.Columns.Add(cb2);

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;

            dataGridView2.Columns[0].Visible = false;

            dataGridView3.Columns[0].Visible = false;
            dataGridView3.Columns[4].Visible = false;
            dataGridView3.Columns[5].Visible = false;
            dataGridView3.Columns["id_wedding"].Visible = false;

            
           
        }

        
        private void Search_KeyDown(object sender, KeyEventArgs e)
        {

            bs.DataSource = dataGridView1.DataSource;
            bs1.DataSource = dataGridView2.DataSource;
            bs2.DataSource = dataGridView3.DataSource;

            if (e.KeyCode == Keys.Enter)
            {

                if (string.IsNullOrEmpty(Search.Text))
                {
                    bs.Filter = string.Empty;
                }
                else
                {

                    if (wedding_option.Checked==true)
                    {
                        Wedding_list.Visible = true;
                        bs.Filter = string.Format("{0}='{1}'", Wedding_list.Text, Search.Text);
                    }
                    else if (invintation_option.Checked == true)
                    {
                        bs1.Filter = string.Format("{0}='{1}'", invintation_list.Text, Search.Text);
                    }
                     
                    

                }
            }
        }

      
    }
}
