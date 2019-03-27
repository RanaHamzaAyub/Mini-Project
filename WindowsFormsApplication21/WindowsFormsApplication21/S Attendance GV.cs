using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication21
{
    public partial class S_Attendance_GV : Form
    {
        public S_Attendance_GV()
        {
            InitializeComponent();
        }
        public void loadgrid()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand("Select FirstName,LastName,RegistrationNumber,AttendanceStatus from Student INNER JOIN StudentAttendance On Student.Id = StudentAttendance.StudentId", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            foreach (DataGridViewColumn column in this.dataGridView1.Columns)
            {
                column.ValueType = typeof(string);
            }
            dataGridView1.Columns.Add("newColumnName", "Attendance Status");
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                
                if (row.Cells[3].Value != null)
                {
                    if (row.Cells[3].Value.ToString() == "1")
                    {                        row.Cells[4].Value = "Present";
                    }else if(row.Cells[3].Value.ToString() == "2")
                    {
                        row.Cells[4].Value = "Absent";
                    }
                    else if (row.Cells[3].Value.ToString() == "3")
                    {
                        row.Cells[4].Value = "Leave";
                    }
                    else if (row.Cells[3].Value.ToString() == "4")
                    {
                        row.Cells[4].Value = "Late";
                    }
                }
            }
        }

        private void S_Attendance_GV_Load(object sender, EventArgs e)
        {
            loadgrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Attendance h = new Attendance();
            h.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DGVClo h = new DGVClo();
            this.Hide();
            h.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            RubricsGV h = new RubricsGV();
            this.Hide();
            h.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RubricLevelGV h = new RubricLevelGV();
            this.Hide();
            h.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Assessment_GV h = new Assessment_GV();
            this.Hide();
            h.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 h = new Form2();
            this.Hide();
            h.Show();
        }
    }
}
