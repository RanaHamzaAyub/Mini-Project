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
    public partial class Attendance : Form
    {
        string connectionString = "Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True;";
       
        public Attendance()
        {
            InitializeComponent();
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True");
            conn.Open();
            string query = "Insert into ClassAttendance (AttendanceDate) OUTPUT INSERTED.Id values('" + DateTime.Now + "')";
            SqlCommand command = new SqlCommand(query, conn);
            int attendence_id = (int)command.ExecuteScalar();

            if (comboBox1.Text != "" && comboBox2.Text!="")
            {
                if (button3.Text == "AddAttendance")
                {
                    
                    int status = 1;
                    if (comboBox2.Text == "Absent")
                    {
                        status = 2;
                    }
                    else if(comboBox2.Text == "Late")
                    {
                        status = 4;
                    }else if(comboBox2.Text == "Leave")
                    {
                        status = 3;
                    }
                    string STDID = (comboBox1.SelectedItem as ComboboxItem).Value.ToString();
                    string Query = "insert into StudentAttendance(StudentId, AttendanceStatus, AttendanceId) values('" + STDID + "','" + status + "','" + attendence_id + "')";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attendance Successfully Added");
                    S_Attendance_GV f = new S_Attendance_GV();
                    f.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please fill all the fields ");
            }

        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True");
            conn.Open();
            string query1 = "Select * from Student";
            SqlCommand command = new SqlCommand(query1, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = Convert.ToString(reader["RegistrationNumber"]);
                    item.Value = Convert.ToString(reader["Id"]);

                    comboBox1.Items.Add(item);

                }
            }
        }
    }
}
