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
    public partial class Contacts : Form
    {
        NpgsqlDataAdapter contacts_ad=new NpgsqlDataAdapter();
        NpgsqlConnection con;
        public Contacts(DataSet ds)
        {
            InitializeComponent();

            var connectionString = "Host=localhost;Username=postgres;Password=students;Database=wedding_planners_db2";
            con = new NpgsqlConnection(connectionString);
            dataGridView1.DataSource = ds.Tables["Contacts"];

            //contacts update

            NpgsqlCommand contacts_update = new NpgsqlCommand("UPDATE contacts SET telephone=@telephone, email=@email, adress=@adress, website=@website WHERE id_contacts = @id_contacts",con);
            contacts_update.Parameters.Add("@telephone", NpgsqlTypes.NpgsqlDbType.Varchar, sizeof(int), "telephone");
            contacts_update.Parameters.Add("@email", NpgsqlTypes.NpgsqlDbType.Varchar, sizeof(int), "email");
            contacts_update.Parameters.Add("@adress", NpgsqlTypes.NpgsqlDbType.Varchar, sizeof(int), "adress");
            contacts_update.Parameters.Add("@website", NpgsqlTypes.NpgsqlDbType.Varchar, sizeof(int), "website");
            contacts_update.Parameters.Add("@id_contacts", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_contacts");
            contacts_ad.UpdateCommand = contacts_update;




        }

        private void Contacts_Load(object sender, EventArgs e)
        {
            Filter.SelectedIndex = 0;
        }

        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            if (e.KeyCode == Keys.Enter)
            {
                
                if(string.IsNullOrEmpty(Search.Text)) 
                { 
                    bs.Filter=string.Empty; 
                }else
                {
                    bs.Filter=string.Format("{0}='{1}'",Filter.Text,Search.Text); 
                }

            }
        }

        private void Contacts_save_Click(object sender, EventArgs e)
        {
           // contacts_ad.Update((DataTable)dataGridView1.DataSource);
           con.Open();
            contacts_ad.Update((DataTable)dataGridView1.DataSource);
            con.Close();
            MessageBox.Show("Changes saved");

            
        }
    }
}
