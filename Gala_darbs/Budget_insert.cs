using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gala_darbs
{
    public partial class Budget_insert : Form
    {
        BindingSource bs;
        BindingSource bs2;
        public NpgsqlConnection Connection;
        public NpgsqlDataAdapter wedding_ad ;
        public int total;
        public Budget_insert( DataSet ds, NpgsqlConnection con)
        {
            InitializeComponent();

            bs=new BindingSource();
            bs.DataSource = ds.Tables["budget"];
            bs.AddNew();
            food_cost_texbox.DataBindings.Add("Text", bs, "food_costs");
            receptoin_cost_textbox.DataBindings.Add("Text", bs, "reception_cost");
            venue_rent_textbox.DataBindings.Add("Text", bs, "venue_rent");
            muzicians_cost_texbox.DataBindings.Add("Text", bs, "musician_costs");
            total_cost_tb.DataBindings.Add("Text", bs, "total_costs");

            bs2 = new BindingSource();
            bs2.DataSource = ds.Tables["wedding"];
            bs2.AddNew();
            date_from_tb.DataBindings.Add("Text", bs2, "date_from");
            date_to_tb.DataBindings.Add("Text", bs2, "date_to");
            wedding_name_texbox.DataBindings.Add("Text", bs2, "wedding_name");

            

            Connection = con;
          
        }
        public NpgsqlConnection con;
        private void Insert_Click(object sender, EventArgs e)
        {
            con = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=students;Database=wedding_planners_db2");
            con.Open();
            //budget insert
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO budget (food_costs, reception_cost, venue_rent, musician_costs, total_costs) VALUES (@food_costs, @reception_cost, @venue_rent, @musician_costs, @total_costs) returning id_budget ", con);
            cmd.Parameters.AddWithValue("@food_costs", Convert.ToInt32(food_cost_texbox.Text));
            cmd.Parameters.AddWithValue("@reception_cost", Convert.ToInt32(receptoin_cost_textbox.Text));
            cmd.Parameters.AddWithValue("@venue_rent", Convert.ToInt32(venue_rent_textbox.Text));
            cmd.Parameters.AddWithValue("@musician_costs", Convert.ToInt32(muzicians_cost_texbox.Text));
            cmd.Parameters.AddWithValue("@total_costs", Convert.ToInt32(total_cost_tb.Text));
            int id_budget = (int)cmd.ExecuteScalar();

            //wedding insert
            NpgsqlCommand cmd2 = new NpgsqlCommand("INSERT INTO wedding (date_from, date_to, id_planner, wedding_name) VALUES (@date_from, @date_to, @id_planner, @wedding_name) returning id_wedding", con);
            cmd2.Parameters.AddWithValue("@date_from", Convert.ToDateTime(date_from_tb.Text));
            cmd2.Parameters.AddWithValue("@date_to", Convert.ToDateTime(date_to_tb.Text));
            cmd2.Parameters.AddWithValue("@id_planner", 1);
            cmd2.Parameters.AddWithValue("@wedding_name", wedding_name_texbox.Text);
            int id_wedding = (int)cmd2.ExecuteScalar();


            //wedding budget insert
            NpgsqlCommand cmd3 = new NpgsqlCommand("INSERT INTO wedding_budget (id_wedding, id_budget) VALUES (@id_wedding, @id_budget)", con);
            cmd3.Parameters.AddWithValue("@id_wedding", id_wedding);
            cmd3.Parameters.AddWithValue("@id_budget", id_budget);
            cmd3.ExecuteNonQuery();


            con.Close();
            MessageBox.Show("Inserted Successfully");








        }
        
        private void Calculate_button_Click(object sender, EventArgs e)
        {

            total = Convert.ToInt32(food_cost_texbox.Text) + Convert.ToInt32(receptoin_cost_textbox.Text) + Convert.ToInt32(venue_rent_textbox.Text) + Convert.ToInt32(muzicians_cost_texbox.Text);
            total_cost_tb.Text = total.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
