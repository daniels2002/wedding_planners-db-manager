using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gala_darbs
{
    public partial class Form1 : Form
    {
        NpgsqlDataAdapter budget_ad = new NpgsqlDataAdapter();
        NpgsqlDataAdapter contacts_ad= new NpgsqlDataAdapter();
        NpgsqlDataAdapter guests_ad = new NpgsqlDataAdapter();
        NpgsqlDataAdapter invitation_ad = new NpgsqlDataAdapter();
        NpgsqlDataAdapter married_couple_ad = new NpgsqlDataAdapter();
        NpgsqlDataAdapter pastor_ad = new NpgsqlDataAdapter();
        NpgsqlDataAdapter reception_ad = new NpgsqlDataAdapter();
        NpgsqlDataAdapter venue_ad = new NpgsqlDataAdapter();
        NpgsqlDataAdapter wedding_ad = new NpgsqlDataAdapter();
        NpgsqlDataAdapter wedding_budget_ad = new NpgsqlDataAdapter();
        NpgsqlDataAdapter wedding_guests_ad = new NpgsqlDataAdapter();
        NpgsqlDataAdapter wedding_reception_ad = new NpgsqlDataAdapter();
        NpgsqlDataAdapter wedding_married_couple_ad = new NpgsqlDataAdapter();
        NpgsqlDataAdapter wedding_invintatinos_ad = new NpgsqlDataAdapter();
        NpgsqlDataAdapter wedding_pastor_ad = new NpgsqlDataAdapter();
        NpgsqlDataAdapter wedding_venue_ad = new NpgsqlDataAdapter();

        //Data set izveidošana//
        DataSet ds = new DataSet();
        //Public contection
        public NpgsqlConnection con;

        public int rowIndex;
        public int cur_node;
        public Form1()
        {
            InitializeComponent();
            var connectionString = "Host=localhost;Username=postgres;Password=students;Database=wedding_planners_db2";
            con = new NpgsqlConnection(connectionString);
            WindowState = FormWindowState.Maximized;

            //budget select
            NpgsqlCommand budget_select = new NpgsqlCommand("SELECT * FROM budget", con);
            budget_ad.SelectCommand = budget_select;
            budget_ad.Fill(ds, "budget");

            
            //budget insert
            NpgsqlCommand budget_insert = new NpgsqlCommand("INSERT INTO budget (food_costs, reception_cost, venue_rent,musician_costs,total_costs) VALUES (@food_costs, @reception_cost, @venue_rent,@musician_costs,@total_costs)", con);
            budget_insert.Parameters.Add("@food_costs", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "food_costs");
            budget_insert.Parameters.Add("@reception_cost", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "reception_cost");
            budget_insert.Parameters.Add("@venue_rent", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "venue_rent");
            budget_insert.Parameters.Add("@musician_costs", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "musician_costs");
            budget_insert.Parameters.Add("@total_costs", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "total_costs");
            budget_ad.InsertCommand = budget_insert;

            //budget update
            NpgsqlCommand budget_update = new NpgsqlCommand("UPDATE budget SET food_costs = @food_costs, reception_cost = @reception_cost, venue_rent = @venue_rent, musician_costs = @musician_costs, total_costs = @total_costs WHERE id_budget = @id_budget", con);
            budget_update.Parameters.Add("@food_costs", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "food_costs");
            budget_update.Parameters.Add("@reception_cost", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "reception_cost");
            budget_update.Parameters.Add("@venue_rent", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "venue_rent");
            budget_update.Parameters.Add("@musician_costs", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "musician_costs");
            budget_update.Parameters.Add("@total_costs", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "total_costs");
            budget_update.Parameters.Add("@id_budget", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_budget");
            budget_ad.UpdateCommand = budget_update;

            //budget delete
            NpgsqlCommand budget_delete = new NpgsqlCommand("DELETE FROM budget WHERE id_budget = @id_budget", con);
            budget_delete.Parameters.Add("@id_budget", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_budget");
            budget_ad.DeleteCommand = budget_delete;

            //contacts select 
            NpgsqlCommand contacts_select = new NpgsqlCommand("SELECT * FROM contacts", con);
            contacts_ad.SelectCommand = contacts_select;
            contacts_ad.Fill(ds, "contacts");

            //contacts insert
            NpgsqlCommand contacts_insert = new NpgsqlCommand("INSERT INTO contacts (telephone, email, adress, website) VALUES (@telephone, @email, @adress, @website)",con);
            contacts_insert.Parameters.Add("@telephone", NpgsqlTypes.NpgsqlDbType.Varchar, 9, "telephone");
            contacts_insert.Parameters.Add("@email", NpgsqlTypes.NpgsqlDbType.Varchar,255, "email");
            contacts_insert.Parameters.Add("@adress", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "adress");
            contacts_insert.Parameters.Add("@website", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "website");
            contacts_ad.InsertCommand = contacts_insert;

            //contacts update
            NpgsqlCommand contacts_update = new NpgsqlCommand("UPDATE contacts SET telephone = @telephone, email = @email, adress = @adress,website=@website WHERE id_contacts = @id_contacts",con);
            contacts_update.Parameters.Add("@telephone", NpgsqlTypes.NpgsqlDbType.Varchar, 9, "telephone");
            contacts_update.Parameters.Add("@email", NpgsqlTypes.NpgsqlDbType.Varchar, 255);
            contacts_update.Parameters.Add("@adress", NpgsqlTypes.NpgsqlDbType.Varchar, 255);
            contacts_update.Parameters.Add("@website", NpgsqlTypes.NpgsqlDbType.Varchar, 255);
            contacts_update.Parameters.Add("@id_contacts", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_contacts");
            contacts_ad.UpdateCommand = contacts_update;

            //contacts delete
            NpgsqlCommand contacts_delete = new NpgsqlCommand("DELETE FROM contacts WHERE id_contacts = @id_contacts", con);
            contacts_delete.Parameters.Add("@id_contacts", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_contacts");
            contacts_ad.DeleteCommand = contacts_delete;

            //guests select
            NpgsqlCommand guests_select = new NpgsqlCommand("SELECT * FROM guests", con);
            guests_ad.SelectCommand = guests_select;
            guests_ad.Fill(ds, "guests");
            //guests insert
            NpgsqlCommand guests_insert = new NpgsqlCommand("INSERT INTO guests (name, surname, invintation_sent,id_wedding,id_invintation) VALUES (@name, @surname, @invintation_sent,@id_wedding,@id_invintation)", con);
            guests_insert.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "name");
            guests_insert.Parameters.Add("@surname", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "surname");
            guests_insert.Parameters.Add("@invintation_sent", NpgsqlTypes.NpgsqlDbType.Boolean,sizeof(bool), "invintation_sent");
            guests_insert.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");
            guests_insert.Parameters.Add("@id_invintation", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_invintation");
            guests_ad.InsertCommand= guests_insert;
            //guests update
            NpgsqlCommand guests_update = new NpgsqlCommand("UPDATE guests SET name = @name, surname = @surname, invintation_sent = @invintation_sent,id_wedding = @id_wedding ,id_invintation = @id_invintation  WHERE id_guest = @id_guest", con);
            guests_update.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "name");
            guests_update.Parameters.Add("@surname", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "surname");
            guests_update.Parameters.Add("@invintation_sent", NpgsqlTypes.NpgsqlDbType.Boolean, sizeof(bool), "invintation_sent");
            guests_update.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");
            guests_update.Parameters.Add("@id_invintation", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_invintation");
            guests_update.Parameters.Add("@id_guest", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_guest");
            guests_ad.UpdateCommand= guests_update;
            //guests delete
            NpgsqlCommand guests_delete = new NpgsqlCommand("DELETE FROM guests WHERE id_guest = @id_guest", con);
            guests_delete.Parameters.Add("@id_guest", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_guest");
            guests_ad.DeleteCommand= guests_delete;
            //invintation select
            NpgsqlCommand invintation_select = new NpgsqlCommand("SELECT * FROM invintation", con);
            invitation_ad.SelectCommand= invintation_select;
            invitation_ad.Fill(ds, "invintation");
            //invintation insert
            NpgsqlCommand invintation_insert = new NpgsqlCommand("INSERT INTO invintation (invintation_text, invintation_type,recipient) VALUES (@invintation_text, @invintation_type,@recipient)", con);
            invintation_insert.Parameters.Add("@invintation_text", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "invintation_text");
            invintation_insert.Parameters.Add("@invintation_type", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "invintation_type");
            invintation_insert.Parameters.Add("@recipient", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "recipient");
            invitation_ad.InsertCommand= invintation_insert;
            //invintation update
            NpgsqlCommand invintation_update = new NpgsqlCommand("UPDATE invintation SET invintation_text = @invintation_text, invintation_type = @invintation_type, recipient = @recipient WHERE id_invintation = @id_invintation", con);
            invintation_update.Parameters.Add("@invintation_text", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "invintation_text");
            invintation_update.Parameters.Add("@invintation_type", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "invintation_type");
            invintation_update.Parameters.Add("@recipient", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "recipient");
            invintation_update.Parameters.Add("@id_invintation", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_invintation");
            invitation_ad.UpdateCommand= invintation_update;
            //invintation delete
            NpgsqlCommand invintation_delete = new NpgsqlCommand("DELETE FROM invintation WHERE id_invintation = @id_invintation", con);
            invintation_delete.Parameters.Add("@id_invintation", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_invintation");
            invitation_ad.DeleteCommand= invintation_delete;

            //married_couple select
            NpgsqlCommand married_couple_select = new NpgsqlCommand("SELECT * FROM married_couple", con);
            married_couple_ad.SelectCommand= married_couple_select;
            married_couple_ad.Fill(ds, "married_couple");
            //married_couple insert
            NpgsqlCommand married_couple_insert = new NpgsqlCommand("INSERT INTO married_couple (bride_name, bride_surname,groom_name,groom_surname,wedding_carriers) VALUES (@bride_name, @bride_surname,@groom_name,@groom_surname,@wedding_carriers)", con);
            married_couple_insert.Parameters.Add("@bride_name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "bride_name");
            married_couple_insert.Parameters.Add("@bride_surname", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "bride_surname");
            married_couple_insert.Parameters.Add("@groom_name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "groom_name");
            married_couple_insert.Parameters.Add("@groom_surname", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "groom_surname");
            married_couple_insert.Parameters.Add("@wedding_carriers", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "wedding_carriers");
            married_couple_ad.InsertCommand= married_couple_insert;
            //married_couple update
            NpgsqlCommand married_couple_update = new NpgsqlCommand("UPDATE married_couple SET bride_name = @bride_name, bride_surname = @bride_surname, groom_name = @groom_name, groom_surname = @groom_surname, wedding_carriers = @wedding_carriers WHERE id_married_couple = @id_married_couple", con);
            married_couple_update.Parameters.Add("@bride_name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "bride_name");
            married_couple_update.Parameters.Add("@bride_surname", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "bride_surname");
            married_couple_update.Parameters.Add("@groom_name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "groom_name");
            married_couple_update.Parameters.Add("@groom_surname", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "groom_surname");
            married_couple_update.Parameters.Add("@wedding_carriers", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "wedding_carriers");
            married_couple_update.Parameters.Add("@id_married_couple", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_married_couple");
            married_couple_ad.UpdateCommand= married_couple_update;
            //married_couple delete
            NpgsqlCommand married_couple_delete = new NpgsqlCommand("DELETE FROM married_couple WHERE id_married_couple = @id_married_couple", con);
            married_couple_delete.Parameters.Add("@id_married_couple", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_married_couple");
            married_couple_ad.DeleteCommand= married_couple_delete;
            //pastor select
            NpgsqlCommand pastor_select = new NpgsqlCommand("SELECT * FROM pastor", con);
            pastor_ad.SelectCommand= pastor_select;
            pastor_ad.Fill(ds, "pastor");
            //pastor insert
            NpgsqlCommand pastor_insert = new NpgsqlCommand("INSERT INTO pastor (name, surname,price_per_ceremony,church) VALUES (@name, @surname,@price_per_ceremony,@church)", con);
            pastor_insert.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "name");
            pastor_insert.Parameters.Add("@surname", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "surname");
            pastor_insert.Parameters.Add("@price_per_ceremony", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "price_per_ceremony");
            pastor_insert.Parameters.Add("@church", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "church");
            pastor_ad.InsertCommand= pastor_insert;
            //pastor update
            NpgsqlCommand pastor_update = new NpgsqlCommand("UPDATE pastor SET name = @name, surname = @surname, price_per_ceremony = @price_per_ceremony, church = @church WHERE id_pastor = @id_pastor", con);
            pastor_update.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "name");
            pastor_update.Parameters.Add("@surname", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "surname");
            pastor_update.Parameters.Add("@price_per_ceremony", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "price_per_ceremony");
            pastor_update.Parameters.Add("@church", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "church");
            pastor_update.Parameters.Add("@id_pastor", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_pastor");
            pastor_ad.UpdateCommand= pastor_update;
            //pastor delete
            NpgsqlCommand pastor_delete = new NpgsqlCommand("DELETE FROM pastor WHERE id_pastor = @id_pastor", con);
            pastor_delete.Parameters.Add("@id_pastor", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_pastor");
            pastor_ad.DeleteCommand = pastor_delete;

            //reception select
            NpgsqlCommand reception_select = new NpgsqlCommand("SELECT * FROM reception", con);
            reception_ad.SelectCommand= reception_select;
            reception_ad.Fill(ds, "reception");
            //reception insert
            NpgsqlCommand reception_insert = new NpgsqlCommand("INSERT INTO reception (receptionist_type, working_time,buffet,id_planner,reports_to) VALUES (@receptionist_type, @working_time,@buffet,@id_planner,@reports_to)", con);
            reception_insert.Parameters.Add("@receptionist_type", NpgsqlTypes.NpgsqlDbType.Varchar, 15, "receptionist_type");
            reception_insert.Parameters.Add("@working_time", NpgsqlTypes.NpgsqlDbType.Varchar, 11, "working_time");
            reception_insert.Parameters.Add("@buffet", NpgsqlTypes.NpgsqlDbType.Boolean, sizeof(bool), "buffet");
            reception_insert.Parameters.Add("@id_planner", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_planner");
            reception_insert.Parameters.Add("@reports_to", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "reports_to");
            reception_ad.InsertCommand= reception_insert;
            //reception update
            NpgsqlCommand reception_update = new NpgsqlCommand("UPDATE reception SET receptionist_type = @receptionist_type, working_time = @working_time, buffet = @buffet, id_planner = @id_planner, reports_to = @reports_to WHERE id_reception = @id_reception", con);
            reception_update.Parameters.Add("@receptionist_type", NpgsqlTypes.NpgsqlDbType.Varchar, 15, "receptionist_type");
            reception_update.Parameters.Add("@working_time", NpgsqlTypes.NpgsqlDbType.Varchar, 11, "working_time");
            reception_update.Parameters.Add("@buffet", NpgsqlTypes.NpgsqlDbType.Boolean, sizeof(bool), "buffet");
            reception_update.Parameters.Add("@id_planner", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_planner");
            reception_update.Parameters.Add("@reports_to", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "reports_to");
            reception_update.Parameters.Add("@id_reception", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_reception");
            reception_ad.UpdateCommand= reception_update;
            //reception delete
            NpgsqlCommand reception_delete = new NpgsqlCommand("DELETE FROM reception WHERE id_reception = @id_reception", con);
            reception_delete.Parameters.Add("@id_reception", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_reception");
            reception_ad.DeleteCommand= reception_delete;

            //venue select
            NpgsqlCommand venue_select = new NpgsqlCommand("SELECT * FROM venue", con);
            venue_ad.SelectCommand= venue_select;
            venue_ad.Fill(ds, "venue");
            //venue insert
            NpgsqlCommand venue_insert = new NpgsqlCommand("INSERT INTO venue (venue_name , price_per_day, description) VALUES (@venue_name, @price_per_day, @description)", con);
            venue_insert.Parameters.Add("@venue_name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "venue_name");
            venue_insert.Parameters.Add("@price_per_day", NpgsqlTypes.NpgsqlDbType.Numeric, sizeof(int), "price_per_day");
            venue_insert.Parameters.Add("@description", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "description");
            venue_ad.InsertCommand= venue_insert;
            //venue update
            NpgsqlCommand venue_update = new NpgsqlCommand("UPDATE venue SET venue_name = @venue_name, price_per_day = @price_per_day, description = @description WHERE id_venue = @id_venue", con);
            venue_update.Parameters.Add("@venue_name", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "venue_name");
            venue_update.Parameters.Add("@price_per_day", NpgsqlTypes.NpgsqlDbType.Numeric, sizeof(int), "price_per_day");
            venue_update.Parameters.Add("@description", NpgsqlTypes.NpgsqlDbType.Varchar, 255, "description");
            venue_update.Parameters.Add("@id_venue", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_venue");
            venue_ad.UpdateCommand= venue_update;
            //venue delete
            NpgsqlCommand venue_delete = new NpgsqlCommand("DELETE FROM venue WHERE id_venue = @id_venue", con);
            venue_delete.Parameters.Add("@id_venue", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_venue");
            venue_ad.DeleteCommand= venue_delete;

            //wedding select
            NpgsqlCommand wedding_select = new NpgsqlCommand("SELECT * FROM wedding", con);
            wedding_ad.SelectCommand= wedding_select;
            wedding_ad.Fill(ds, "wedding");
            //wedding insert
            NpgsqlCommand wedding_insert = new NpgsqlCommand("INSERT INTO wedding (date_from, date_to, id_planner,wedding_name) VALUES (@date_from, @date_to, @id_planner,@wedding_name)", con);
            wedding_insert.Parameters.Add("@date_from", NpgsqlTypes.NpgsqlDbType.Date, 255, "date_from");
            wedding_insert.Parameters.Add("@date_to", NpgsqlTypes.NpgsqlDbType.Date, 255, "date_to");
            wedding_insert.Parameters.Add("@wedding_name", NpgsqlTypes.NpgsqlDbType.Varchar, 50, "wedding_name");
            wedding_insert.Parameters.Add("@id_planner", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_planner");
            wedding_ad.InsertCommand= wedding_insert;
            //wedding update
            NpgsqlCommand wedding_update = new NpgsqlCommand("UPDATE wedding SET date_from = @date_from, date_to = @date_to, id_planner = @id_planner,wedding_name=@wedding_name WHERE id_wedding = @id_wedding", con);
            wedding_update.Parameters.Add("@date_from", NpgsqlTypes.NpgsqlDbType.Date, 255, "date_from");
            wedding_update.Parameters.Add("@date_to", NpgsqlTypes.NpgsqlDbType.Date, 255, "date_to");
            wedding_update.Parameters.Add("@id_planner", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_planner");
            wedding_update.Parameters.Add("@wedding_name", NpgsqlTypes.NpgsqlDbType.Varchar, 50, "wedding_name");
            wedding_update.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");
            wedding_ad.UpdateCommand= wedding_update;
            //wedding delete
            NpgsqlCommand wedding_delete = new NpgsqlCommand("DELETE FROM wedding WHERE id_wedding = @id_wedding", con);
            wedding_delete.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");  
            wedding_ad.DeleteCommand= wedding_delete;

                                                     /*---------------------   Index tables ---------------------    */
            //select wedding_budget
            NpgsqlCommand wedding_budget_select = new NpgsqlCommand("SELECT * FROM wedding_budget", con);
            wedding_budget_ad.SelectCommand= wedding_budget_select;
            wedding_budget_ad.Fill(ds, "wedding_budget");
            //insert wedding_budget
            NpgsqlCommand wedding_budget_insert = new NpgsqlCommand("INSERT INTO wedding_budget (id_wedding, id_budget) VALUES (@id_wedding, @id_budget)", con);
            wedding_budget_insert.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");
            wedding_budget_insert.Parameters.Add("@id_budget", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_budget");
            wedding_budget_ad.InsertCommand= wedding_budget_insert;
            //update wedding_budget
            NpgsqlCommand wedding_budget_update = new NpgsqlCommand("UPDATE wedding_budget SET id_wedding = @id_wedding, id_budget = @id_budget WHERE id_wedding_budget = @id_wedding_budget", con);
            wedding_budget_update.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");
            wedding_budget_update.Parameters.Add("@id_budget", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_budget");
            wedding_budget_update.Parameters.Add("@id_wedding_budget", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding_budget");
            wedding_budget_ad.UpdateCommand= wedding_budget_update;
            //delete wedding_budget
            NpgsqlCommand wedding_budget_delete = new NpgsqlCommand("DELETE  FROM wedding_budget WHERE id_wedding_budget = @id_wedding_budget", con);
            wedding_budget_delete.Parameters.Add("@id_wedding_budget", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding_budget");
            wedding_budget_ad.DeleteCommand= wedding_budget_delete;

            //select wedding_guests
            NpgsqlCommand wedding_guests_select = new NpgsqlCommand("SELECT * FROM wedding_guests", con);
            wedding_guests_ad.SelectCommand = wedding_guests_select;
            wedding_guests_ad.Fill(ds, "wedding_guests");

            //Insert into wedding_guests
            NpgsqlCommand wedding_guests_insert = new NpgsqlCommand("INSERT INTO wedding_guests (id_guest, id_wedding) VALUES (@id_guest, @id_wedding)", con);
            wedding_guests_insert.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");
            wedding_guests_insert.Parameters.Add("@id_guest", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_guest");
            wedding_guests_ad.InsertCommand = wedding_guests_insert;
            //Update wedding_guests
            NpgsqlCommand wedding_guests_update = new NpgsqlCommand("UPDATE wedding_guests SET id_guest = @id_guest, id_wedding = @id_wedding WHERE id_wedding_guest = @id_wedding_guest", con);
            wedding_guests_update.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");
            wedding_guests_update.Parameters.Add("@id_guest", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_guest");
            wedding_guests_update.Parameters.Add("@id_wedding_guest", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding_guest");
            wedding_guests_ad.UpdateCommand = wedding_guests_update;
            //delete wedding_guests
            NpgsqlCommand wedding_guests_delete = new NpgsqlCommand("DELETE  FROM wedding_guests WHERE id_wedding_guest = @id_wedding_guest", con);
            wedding_guests_delete.Parameters.Add("@id_wedding_guest", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding_guest");
            wedding_guests_ad.DeleteCommand = wedding_guests_delete;

            //select wedding_reception
            NpgsqlCommand wedding_reception_select = new NpgsqlCommand("SELECT * FROM wedding_reception", con);
            wedding_reception_ad.SelectCommand = wedding_reception_select;
            wedding_reception_ad.Fill(ds, "wedding_reception");
            //insert wedding_reception
            NpgsqlCommand wedding_reception_insert = new NpgsqlCommand("INSERT INTO wedding_reception (id_wedding, id_reception) VALUES (@id_wedding, @id_reception)", con);
            wedding_reception_insert.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");
            wedding_reception_insert.Parameters.Add("@id_reception", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_reception");
            wedding_reception_ad.InsertCommand = wedding_reception_insert;
            //update wedding_reception
            NpgsqlCommand wedding_reception_update = new NpgsqlCommand("UPDATE wedding_reception SET id_wedding = @id_wedding, id_reception = @id_reception WHERE id_wedding_reception = @id_wedding_reception", con);
            wedding_reception_update.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");
            wedding_reception_update.Parameters.Add("@id_reception", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_reception");
            wedding_reception_update.Parameters.Add("@id_wedding_reception", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding_reception");
            wedding_reception_ad.UpdateCommand = wedding_reception_update;
            //delete wedding_reception
            NpgsqlCommand wedding_reception_delete = new NpgsqlCommand("DELETE  FROM wedding_reception WHERE id_wedding_reception = @id_wedding_reception", con);
            wedding_reception_delete.Parameters.Add("@id_wedding_reception", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding_reception");
            wedding_reception_ad.DeleteCommand = wedding_reception_delete;
             //select wedding_married_couple
             NpgsqlCommand wedding_married_couple_select = new NpgsqlCommand("SELECT * FROM wedding_married_couple", con);
             wedding_married_couple_ad.SelectCommand = wedding_married_couple_select;
            wedding_married_couple_ad.Fill(ds, "wedding_married_couple");
            //insert wedding_married_couple
            NpgsqlCommand wedding_married_couple_insert = new NpgsqlCommand("INSERT INTO wedding_married_couple (id_wedding, id_married_couple) VALUES (@id_wedding, @id_married_couple)", con);
            wedding_married_couple_insert.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");
            wedding_married_couple_insert.Parameters.Add("@id_married_couple", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_married_couple");
            wedding_married_couple_ad.InsertCommand = wedding_married_couple_insert;
            //update wedding_married_couple
            NpgsqlCommand wedding_married_couple_update = new NpgsqlCommand("UPDATE wedding_married_couple SET id_wedding = @id_wedding, id_married_couple = @id_married_couple WHERE id_wedding_married_couple = @id_wedding_married_couple", con);
            wedding_married_couple_update.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");
            wedding_married_couple_update.Parameters.Add("@id_married_couple", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_married_couple");
            wedding_married_couple_update.Parameters.Add("@id_wedding_married_couple", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding_married_couple");
            wedding_married_couple_ad.UpdateCommand = wedding_married_couple_update;
            //delete wedding_married_couple
            NpgsqlCommand wedding_married_couple_delete = new NpgsqlCommand("DELETE  FROM wedding_married_couple WHERE id_wedding_married_couple = @id_wedding_married_couple", con);
            wedding_married_couple_delete.Parameters.Add("@id_wedding_married_couple", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding_married_couple");
            wedding_married_couple_ad.DeleteCommand = wedding_married_couple_delete;
            
            //select wedding_invintatinos
            NpgsqlCommand wedding_invintatinos_select = new NpgsqlCommand("SELECT * FROM wedding_invintations", con);
            wedding_invintatinos_ad.SelectCommand = wedding_invintatinos_select;
            wedding_invintatinos_ad.Fill(ds, "wedding_invintations");
            //insert wedding_invintatinos
            NpgsqlCommand wedding_invintatinos_insert = new NpgsqlCommand("INSERT INTO wedding_invintations (id_invintation, id_wedding) VALUES (@id_invintation, @id_wedding)", con);
            wedding_invintatinos_insert.Parameters.Add("@id_invintation", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_invintation");
            wedding_invintatinos_insert.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");
            wedding_invintatinos_ad.InsertCommand = wedding_invintatinos_insert;
            //update wedding_invintatinos
            NpgsqlCommand wedding_invintatinos_update = new NpgsqlCommand("UPDATE wedding_invintatinos SET id_invintation = @id_invintation, id_wedding = @id_wedding WHERE id_wedding_invintation = @id_wedding_invintation", con);
            wedding_invintatinos_update.Parameters.Add("@id_invintation", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_invintation");
            wedding_invintatinos_update.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");
            wedding_invintatinos_update.Parameters.Add("@id_wedding_invintation", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding_invintation");
            wedding_invintatinos_ad.UpdateCommand = wedding_invintatinos_update;
            //delete wedding_invintatinos
            NpgsqlCommand wedding_invintatinos_delete = new NpgsqlCommand("DELETE  FROM wedding_invintations WHERE id_wedding_invintation = @id_wedding_invintation", con);
            wedding_invintatinos_delete.Parameters.Add("@id_wedding_invintation", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding_invintation");
            wedding_invintatinos_ad.DeleteCommand = wedding_invintatinos_delete;
            //select wedding_pastor
            NpgsqlCommand wedding_pastor_select = new NpgsqlCommand("SELECT * FROM wedding_pastor", con);
            wedding_pastor_ad.SelectCommand = wedding_pastor_select;
            wedding_pastor_ad.Fill(ds, "wedding_pastor");
            //insert wedding_pastor
            NpgsqlCommand wedding_pastor_insert = new NpgsqlCommand("INSERT INTO wedding_pastor (id_wedding,id_pastor) VALUES (@id_wedding,@id_pastor)", con);
            wedding_pastor_insert.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");
            wedding_pastor_insert.Parameters.Add("@id_pastor", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_pastor");
            wedding_pastor_ad.InsertCommand = wedding_pastor_insert;
            //update wedding_pastor
            NpgsqlCommand wedding_pastor_update = new NpgsqlCommand("UPDATE wedding_pastor SET id_wedding = @id_wedding, id_pastor = @id_pastor WHERE id_wedding_pastor = @id_wedding_pastor", con);
            wedding_pastor_update.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");
            wedding_pastor_update.Parameters.Add("@id_pastor", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_pastor");
            wedding_pastor_update.Parameters.Add("@id_wedding_pastor", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding_pastor");
            wedding_pastor_ad.UpdateCommand = wedding_pastor_update;
            //delete wedding_pastor
            NpgsqlCommand wedding_pastor_delete = new NpgsqlCommand("DELETE  FROM wedding_pastor WHERE id_wedding_pastor = @id_wedding_pastor", con);
            wedding_pastor_delete.Parameters.Add("@id_wedding_pastor", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding_pastor");
            wedding_pastor_ad.DeleteCommand = wedding_pastor_delete;
            //select wedding_venue
            NpgsqlCommand wedding_venue_select = new NpgsqlCommand("SELECT * FROM wedding_venue", con);
            wedding_venue_ad.SelectCommand = wedding_venue_select;
            wedding_venue_ad.Fill(ds, "wedding_venue");
            //insert wedding_venue
            NpgsqlCommand wedding_venue_insert = new NpgsqlCommand("INSERT INTO wedding_venue (id_wedding,id_venue) VALUES (@id_wedding,@id_venue)", con);
            wedding_venue_insert.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");
            wedding_venue_insert.Parameters.Add("@id_venue", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_venue");
            wedding_venue_ad.InsertCommand = wedding_venue_insert;
            //update wedding_venue
            NpgsqlCommand wedding_venue_update = new NpgsqlCommand("UPDATE wedding_venue SET id_wedding = @id_wedding, id_venue = @id_venue WHERE id_wedding_venue = @id_wedding_venue", con);
            wedding_venue_update.Parameters.Add("@id_wedding", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding");
            wedding_venue_update.Parameters.Add("@id_venue", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_venue");
            wedding_venue_update.Parameters.Add("@id_wedding_venue", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding_venue");
            wedding_venue_ad.UpdateCommand = wedding_venue_update;
            //delete wedding_venue
            NpgsqlCommand wedding_venue_delete = new NpgsqlCommand("DELETE  FROM wedding_venue WHERE id_wedding_venue = @id_wedding_venue", con);
            wedding_venue_delete.Parameters.Add("@id_wedding_venue", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_wedding_venue");
            wedding_venue_ad.DeleteCommand = wedding_venue_delete;


            //Relacija starp tabulu guests un wedding

            ds.Relations.Add(new DataRelation("guests_wedding_rel", ds.Tables["wedding"].Columns["id_wedding"], ds.Tables["guests"].Columns["id_wedding"], true));

            //Relacija starp tabulu guests un invintation

            ds.Relations.Add(new DataRelation("guests_invintation_rel", ds.Tables["invintation"].Columns["id_invintation"], ds.Tables["guests"].Columns["id_invintation"], true));




        }
        private void main_table_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Message.ReferenceEquals(main_table_view, sender);
        }
        public void toolStripButton1_Click(object sender, EventArgs e)
        {
            budget_ad.Update(ds.Tables["budget"]);
            contacts_ad.Update(ds.Tables["contacts"]);
            guests_ad.Update(ds.Tables["guests"]);
            invitation_ad.Update(ds.Tables["invintation"]);
            married_couple_ad.Update(ds.Tables["married_couple"]);
            pastor_ad.Update(ds.Tables["pastor"]);
            reception_ad.Update(ds.Tables["reception"]);
            venue_ad.Update(ds.Tables["venue"]);
            wedding_ad.Update(ds.Tables["wedding"]);
            //index tables
            wedding_budget_ad.Update(ds.Tables["wedding_budget"]);
            wedding_guests_ad.Update(ds.Tables["wedding_guests"]);
            wedding_reception_ad.Update(ds.Tables["wedding_reception"]);
            wedding_married_couple_ad.Update(ds.Tables["wedding_married_couple"]);
            wedding_invintatinos_ad.Update(ds.Tables["wedding_invintations"]);
            wedding_pastor_ad.Update(ds.Tables["wedding_pastor"]);
            wedding_venue_ad.Update(ds.Tables["wedding_venue"]);
        }

        public void countrows()
        {
            int count = 0;
            while (count < main_table_view.Rows.Count)
            {
                main_table_view.Rows[count].Cells[0].Value = count + 1;
                count = count + 1;
            }
            total_records.Text = (count-1).ToString();

        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (table_list.Text == "budget")
            {
                main_table_view.DataSource = ds.Tables["budget"];
                index_table_view.DataSource = ds.Tables["wedding_budget"];
                budget_comboBox.Visible = true;
                guests_comboBox.Visible = false;
                invintation_comboBox.Visible = false;
                married_couple_comboBox.Visible = false;
                pastor_comboBox.Visible = false;
                reception_comboBox.Visible = false;
                venue_comboBox.Visible = false;

                countrows();
            }
            else if (table_list.Text == "married_couple")
            {
                main_table_view.DataSource = ds.Tables["married_couple"];
                index_table_view.DataSource = ds.Tables["wedding_married_couple"];

                index_table_view.Columns[0].Visible = false;

                budget_comboBox.Visible = false;
                guests_comboBox.Visible = false;
                invintation_comboBox.Visible = false;
                married_couple_comboBox.Visible = true;
                pastor_comboBox.Visible = false;
                reception_comboBox.Visible = false;
                venue_comboBox.Visible = false;

                countrows();

            }
            else if (table_list.Text == "pastor")
            {
                main_table_view.DataSource = ds.Tables["pastor"];
                index_table_view.DataSource = ds.Tables["wedding_pastor"];

                budget_comboBox.Visible = false;
                guests_comboBox.Visible = false;
                invintation_comboBox.Visible = false;
                married_couple_comboBox.Visible = false;
                pastor_comboBox.Visible = true;
                reception_comboBox.Visible = false;
                venue_comboBox.Visible = false;

                // combobox for pastor table in index table
                DataGridViewComboBoxColumn wedding_pastor_id_pastor = new DataGridViewComboBoxColumn();
                wedding_pastor_id_pastor.DataSource = ds.Tables["pastor"];
                wedding_pastor_id_pastor.DisplayMember = "id_pastor";
                wedding_pastor_id_pastor.ValueMember = "id_pastor";
                wedding_pastor_id_pastor.DataPropertyName = "id_pastor";
                wedding_pastor_id_pastor.HeaderText = "Pastor";
                index_table_view.Columns.RemoveAt(1);
                index_table_view.Columns.Insert(1, wedding_pastor_id_pastor);

                // combobox for wedding table in index table
                DataGridViewComboBoxColumn wedding_pastor_id_wedding = new DataGridViewComboBoxColumn();
                wedding_pastor_id_wedding.DataSource = ds.Tables["wedding"];
                wedding_pastor_id_wedding.DisplayMember = "id_wedding";
                wedding_pastor_id_wedding.ValueMember = "id_wedding";
                wedding_pastor_id_wedding.DataPropertyName = "id_wedding";
                wedding_pastor_id_wedding.HeaderText = "Wedding";
                index_table_view.Columns.RemoveAt(2);
                index_table_view.Columns.Insert(2, wedding_pastor_id_wedding);
                countrows();

            }
            
            else if (table_list.Text == "venue")
            {
                main_table_view.DataSource = ds.Tables["venue"];
                index_table_view.DataSource = ds.Tables["wedding_venue"];

                budget_comboBox.Visible = false;
                guests_comboBox.Visible = false;
                invintation_comboBox.Visible = false;
                married_couple_comboBox.Visible = false;
                pastor_comboBox.Visible = false;
                reception_comboBox.Visible = false;
                venue_comboBox.Visible = true;


                // combobox for venue table in index table
                DataGridViewComboBoxColumn wedding_venue_id_venue = new DataGridViewComboBoxColumn();
                wedding_venue_id_venue.DataSource = ds.Tables["venue"];
                wedding_venue_id_venue.DisplayMember = "id_venue";
                wedding_venue_id_venue.ValueMember = "id_venue";
                wedding_venue_id_venue.DataPropertyName = "id_venue";
                wedding_venue_id_venue.HeaderText = "Venue";
                index_table_view.Columns.RemoveAt(1);
                index_table_view.Columns.Insert(1, wedding_venue_id_venue);

                // combobox for wedding table in index table
                DataGridViewComboBoxColumn wedding_venue_id_wedding = new DataGridViewComboBoxColumn();
                wedding_venue_id_wedding.DataSource = ds.Tables["wedding"];
                wedding_venue_id_wedding.DisplayMember = "id_wedding";
                wedding_venue_id_wedding.ValueMember = "id_wedding";
                wedding_venue_id_wedding.DataPropertyName = "id_wedding";
                wedding_venue_id_wedding.HeaderText = "Wedding";
                index_table_view.Columns.RemoveAt(2);
                index_table_view.Columns.Insert(2, wedding_venue_id_wedding);

                countrows();
            }
            main_table_view.Columns[0].Visible = false;
            index_table_view.Columns[0].Visible = false;

            wedding_table_view.DataSource = ds.Tables["wedding"];
            wedding_table_view.Columns[0].Visible = false;
            wedding_table_view.Columns[3].Visible = false;
        }
        private void Contacts_Click(object sender, EventArgs e)
        {
            Contacts form2 = new Contacts(ds);
            form2.Show();
        }
        private void Insert_budget_click(object sender, EventArgs e)
        {
            Budget_insert form3 = new Budget_insert(ds,con);
            main_table_view.DataSource = ds.Tables["budget"];
            index_table_view.DataSource = ds.Tables["wedding_budget"];
            index_table_view.Columns[0].Visible = false;
            form3.Show();
        }
        private void Reception_hierarchy(object sender, EventArgs e)
        {
            Reception_hierarchy form4 = new Reception_hierarchy();
            form4.Show();
        }
        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = main_table_view.DataSource;
            if (e.KeyCode == Keys.Enter)
            {

                if (string.IsNullOrEmpty(Search.Text))
                {
                    bs.Filter = string.Empty;
                }
                else
                {
                    if (table_list.Text == "budget")
                    {
                        bs.Filter = string.Format("{0}='{1}'", budget_comboBox.Text, Search.Text);
                        countrows();
                    }
                    else if (table_list.Text == "guests")
                    {
                        bs.Filter = string.Format("{0}='{1}'", guests_comboBox.Text, Search.Text);
                        countrows();
                    }
                    else if (table_list.Text == "invintation")
                    {
                        bs.Filter = string.Format("{0}='{1}'", invintation_comboBox.Text, Search.Text);
                        countrows();
                    }
                    else if (table_list.Text == "married_couple")
                    {
                        bs.Filter = string.Format("{0}='{1}'", married_couple_comboBox.Text, Search.Text);
                        countrows();

                    }
                    else if (table_list.Text == "pastor")
                    {

                        bs.Filter = string.Format("{0}='{1}'", pastor_comboBox.Text, Search.Text);
                        countrows();
                    }
                    else if (table_list.Text == "married_couple")
                    {
                        bs.Filter = string.Format("{0}='{1}'", married_couple_comboBox.Text, Search.Text);
                        countrows();

                    }
                    else if (table_list.Text == "reception")
                    {
                        bs.Filter = string.Format("{0}='{1}'", reception_comboBox.Text, Search.Text);
                        countrows();
                    }
                    else if (table_list.Text == "venue")
                    {
                        bs.Filter = string.Format("{0}='{1}'", venue_comboBox.Text, Search.Text);
                        countrows();
                    }  
                }

            }
        }

        private void Create_wedding_Click(object sender, EventArgs e)
        {
            main_table_view.DataSource = ds.Tables["married_couple"];
            index_table_view.DataSource = ds.Tables["wedding_married_couple"];
            Wedding_info wedding_Info = new Wedding_info(ds);
            wedding_Info.Show();
            

        }

        private void View_guests_Click(object sender, EventArgs e)
        {
            Guest_view guest_view = new Guest_view(ds,table_list);
            guest_view.Show();
        }
    }
}
