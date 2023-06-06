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
    public partial class Wedding_info : Form
    {
        public NpgsqlConnection con;
        public Wedding_info(DataSet ds)
        {
            InitializeComponent();
            var connectionString = "Host=localhost;Username=postgres;Password=students;Database=wedding_planners_db2";
            con = new NpgsqlConnection(connectionString);
            field_clear();


        }

        
        public void field_clear()
        {
            if (Carries_tb.Text == "Only Names")
            {
                Carries_tb.Text = "";
            }
            else if (Brides_name.Text=="Name")
            {
                Brides_name.Text = "";
            }
            else if (Brides_surname.Text=="Surname")
            {
                Brides_surname.Text = "";
            }
            else if (Grooms_name.Text=="Name")
            {
                Grooms_name.Text = "";
            }
            else if (Grooms_surname.Text == "Surname")
            {
                Grooms_surname.Text = "";
            }


        }
        private void Carries_tb_Click(object sender, EventArgs e)
        {
           field_clear();
           
        }
        
        private void Brides_name_Click(object sender, EventArgs e)
        {
            field_clear();
        }

        private void Brides_surname_Click(object sender, EventArgs e)
        {
            field_clear();
        }

        private void Grooms_name_Click(object sender, EventArgs e)
        {
            field_clear();
          
        }

        private void Grooms_surname_Click(object sender, EventArgs e)
        {
            field_clear();

            if (Brides_name.Text != "" && Grooms_name.Text != "")
            {
                wedding_name.Text = Brides_name.Text + "&" + Grooms_name.Text;
            }
        }

        private void Insert_weddin_btn_Click(object sender, EventArgs e)
        {
            DateTime selectedDate_from = Date_from.Value;
            DateTime selectedDate_to = Date_to.Value;

            con.Open();

            // Insert into married_couple table
            NpgsqlCommand cmd1 = new NpgsqlCommand("INSERT INTO married_couple (bride_name, bride_surname, groom_name, groom_surname, wedding_carriers) VALUES (@bride_name, @bride_surname, @groom_name, @groom_surname, @wedding_carriers) returning id_married_couple", con);
            cmd1.Parameters.AddWithValue("@bride_name", Brides_name.Text);
            cmd1.Parameters.AddWithValue("@bride_surname", Brides_surname.Text);
            cmd1.Parameters.AddWithValue("@groom_name", Grooms_name.Text);
            cmd1.Parameters.AddWithValue("@groom_surname", Grooms_surname.Text);
            cmd1.Parameters.AddWithValue("@wedding_carriers", Carries_tb.Text);
            int id_married_couple = (int)cmd1.ExecuteScalar();

            // Insert into wedding table
            NpgsqlCommand cmd2 = new NpgsqlCommand("INSERT INTO wedding (date_from, date_to, id_planner, wedding_name) VALUES (@date_from, @date_to, @id_planner, @wedding_name) returning id_wedding", con);
            cmd2.Parameters.AddWithValue("@date_from", selectedDate_from);
            cmd2.Parameters.AddWithValue("@date_to", selectedDate_to);
            cmd2.Parameters.AddWithValue("@id_planner", 1);
            cmd2.Parameters.AddWithValue("@wedding_name", wedding_name.Text);
            int id_wedding = (int)cmd2.ExecuteScalar();

            // Insert into wedding_married_couple table
            NpgsqlCommand cmd3 = new NpgsqlCommand("INSERT INTO wedding_married_couple (id_wedding, id_married_couple) VALUES (@id_wedding, @id_married_couple)", con);
            cmd3.Parameters.AddWithValue("@id_wedding", id_wedding);
            cmd3.Parameters.AddWithValue("@id_married_couple", id_married_couple);
            cmd3.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Data Inserted Successfully");
            
        }
    }
}
