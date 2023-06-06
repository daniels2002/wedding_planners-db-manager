using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gala_darbs
{
    public partial class Reception_hierarchy : Form
    {
        public NpgsqlConnection conn;
        public NpgsqlDataAdapter receptAdapt;
        public DataTable reception;
        public NpgsqlDataAdapter reportsad;
        public DataTable reports1;
        public int cur_node;

        public Reception_hierarchy()
        {
            InitializeComponent();
            reception_treeView.LabelEdit = true;
            var connectionString = "Host=localhost;Username=postgres;Password=students;Database=wedding_planners_db2";
            conn = new NpgsqlConnection(connectionString);




            NpgsqlCommand scm1 = new NpgsqlCommand("SELECT * from reports ", conn);
            reportsad = new NpgsqlDataAdapter();
            reports1 = new DataTable();
            reportsad.SelectCommand = scm1;
            reportsad.Fill(reports1);

            NpgsqlCommand scm2 = new NpgsqlCommand("SELECT * from reception ", conn);
            receptAdapt = new NpgsqlDataAdapter();
            reception = new DataTable();
            receptAdapt.SelectCommand = scm2;
            receptAdapt.Fill(reception);


            reception_datagridview.DataSource = reception;
            reception_datagridview.Columns[4].Visible= false;
            reception_datagridview.Columns[0].Visible = false;
            SubLevel(0, null);
        }

        public void SubLevel(int parentid, TreeNode parentNode)
        {
            NpgsqlCommand sel3 = new NpgsqlCommand("SELECT id_report,name  FROM reports WHERE report_to = @parentid", conn);
            sel3.Parameters.Add("@parentid", NpgsqlTypes.NpgsqlDbType.Integer).Value = parentid;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sel3);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (parentid == 0)
            {
                CreateNodes(dt, reception_treeView.Nodes);
            }
            else
            {
                CreateNodes(dt, parentNode.Nodes);
            }

        }
        public void CreateNodes(DataTable dt, TreeNodeCollection nodes)
        {
            foreach (DataRow dr1 in dt.Rows)
            {
                var tn = new TreeNode
                {
                    Text = dr1["name"].ToString(),
                    Name = dr1["id_report"].ToString()
                };
                nodes.Add(tn);
                SubLevel(Convert.ToInt32(tn.Name), tn);
            }
        }
        private void reception_treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            int y = 0;
            if (e.Node.Name != "")
            {
                y = Convert.ToInt32(e.Node.Name);
            }
            dgv_select(y);
        }
        public void dgv_select(int e)
        {

            if (e.ToString() != "")
            {
                DataTable reception1 =new DataTable();
                NpgsqlDataAdapter recp_ad = new NpgsqlDataAdapter();
                NpgsqlCommand recpetion = new NpgsqlCommand($"Select * from reception where reports_to={e}", conn);
                recpetion.Parameters.Add("reports_to", NpgsqlTypes.NpgsqlDbType.Integer).Value = e;
                recp_ad.SelectCommand = recpetion;
                recp_ad.Fill(reception1); 
                reception_datagridview.DataSource = reception1;
            }
            
            NpgsqlCommand selecttype = new NpgsqlCommand("Select id_reception,receptionist_type from reception WHERE NOT (receptionist_type IS NULL)", conn);
                
            conn.Open();
            NpgsqlDataReader datareaderapraksts = selecttype.ExecuteReader();

            string s = "";
            while (datareaderapraksts.Read())
            {
                if (e.ToString() != "" && datareaderapraksts.GetInt32(0) == e)
                {
                    s = datareaderapraksts.GetString(1);
                }

            }
            conn.Close();
            description.Text = s;
            cur_node = e;
        }

        private void reception_datagridview_Click(object sender, EventArgs e)
        {
            int rc = reception_datagridview.Rows.Count - 1;
            if (rc > 0)
            {
                reception_datagridview.Rows[rc].Cells[3].Value = cur_node;
            }
            else
            {
                reception_datagridview.Rows[0].Cells[3].Value = cur_node;
            }
        }

        private void Save_changes_Click(object sender, EventArgs e)
        {
            //reception select
            NpgsqlCommand reception_select = new NpgsqlCommand("SELECT * FROM reception", conn);
            receptAdapt.SelectCommand = reception_select;
           
            //reception insert
            NpgsqlCommand reception_insert = new NpgsqlCommand("INSERT INTO reception (receptionist_type, working_time,buffet,id_planner,reports_to) VALUES (@receptionist_type, @working_time,@buffet,@id_planner,@reports_to)", conn);
            reception_insert.Parameters.Add("@receptionist_type", NpgsqlTypes.NpgsqlDbType.Varchar, 15, "receptionist_type");
            reception_insert.Parameters.Add("@working_time", NpgsqlTypes.NpgsqlDbType.Varchar, 11, "working_time");
            reception_insert.Parameters.Add("@buffet", NpgsqlTypes.NpgsqlDbType.Boolean, sizeof(bool), "buffet");
            reception_insert.Parameters.Add("@id_planner", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_planner");
            reception_insert.Parameters.Add("@reports_to", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "reports_to");
            receptAdapt.InsertCommand = reception_insert;
            //reception update
            NpgsqlCommand reception_update = new NpgsqlCommand("UPDATE reception SET receptionist_type = @receptionist_type, working_time = @working_time, buffet = @buffet, id_planner = @id_planner, reports_to = @reports_to WHERE id_reception = @id_reception", conn);
            reception_update.Parameters.Add("@receptionist_type", NpgsqlTypes.NpgsqlDbType.Varchar, 15, "receptionist_type");
            reception_update.Parameters.Add("@working_time", NpgsqlTypes.NpgsqlDbType.Varchar, 11, "working_time");
            reception_update.Parameters.Add("@buffet", NpgsqlTypes.NpgsqlDbType.Boolean, sizeof(bool), "buffet");
            reception_update.Parameters.Add("@id_planner", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_planner");
            reception_update.Parameters.Add("@reports_to", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "reports_to");
            reception_update.Parameters.Add("@id_reception", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_reception");
            receptAdapt.UpdateCommand = reception_update;
            //reception delete
            NpgsqlCommand reception_delete = new NpgsqlCommand("DELETE FROM reception WHERE id_reception = @id_reception", conn);
            reception_delete.Parameters.Add("@id_reception", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_reception");
            receptAdapt.DeleteCommand = reception_delete;

            receptAdapt.Update((DataTable)reception_datagridview.DataSource);
            MessageBox.Show("Changes saved");
        }

        private void reception_treeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                e.Node.Text = e.Label;
            }

            //report select
            NpgsqlCommand report_select = new NpgsqlCommand("SELECT * FROM reports", conn);
            reportsad.SelectCommand = report_select;
            //report insert
            NpgsqlCommand report_insert = new NpgsqlCommand("INSERT INTO reports (name,report_to) VALUES (@name, @report_to)", conn);
            report_insert.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Varchar, 25, "name");
            report_insert.Parameters.Add("@report_to", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "report_to");
            reportsad.InsertCommand = report_insert;
            //report update
            NpgsqlCommand report_update = new NpgsqlCommand("UPDATE reports SET name = @name, report_to = @report_to WHERE id_report = @id_report", conn);
            report_update.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Varchar, 25, "name");
            report_update.Parameters.Add("@report_to", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "report_to");
            report_update.Parameters.Add("@id_report", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_report");
            reportsad.UpdateCommand = report_update;
            //report delete
            NpgsqlCommand report_delete = new NpgsqlCommand("DELETE FROM reports WHERE id_report = @id_report", conn);
            report_delete.Parameters.Add("@id_report", NpgsqlTypes.NpgsqlDbType.Integer, sizeof(int), "id_report");
            reportsad.DeleteCommand = report_delete;

            receptAdapt.Fill(reports1);
            int i = 0;
            int t = -1;
            foreach (DataRow dr in reports1.Rows)
            {
                if (dr[0].ToString() == e.Node.Name)
                {
                    t = i;
                }
                i++;
            }
            if (t != -1)
            {
                reports1.Rows[t]["name"] = e.Node.Text.ToString();
               
            }
            else
            {
                DataRow dr1 = reports1.NewRow();
                dr1["id_report"] = 0;
                dr1["name"] = e.Node.Text.ToString();
                dr1["report_to"] = Convert.ToInt32(e.Node.Parent.Name);

                reports1.Rows.Add(dr1);
            }
            reportsad.Update(reports1);
          
        }

        private void reception_treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name != "")
            {
                var tn = new TreeNode
                {
                    Text = "new"
                };
                e.Node.Nodes.Add(tn);
            }
        }
    }
  
    



}
