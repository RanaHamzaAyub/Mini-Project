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
    public partial class Assessment : Form
    {
        string connectionString = "Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True;";
        public object Response { get; private set; }
        string StdId;
        public Assessment()
        {
            InitializeComponent();
        }
        public Assessment(string Title, string TotalMarks, string TotalWeightage, string Id)
        {
            InitializeComponent();
            textBox1.Text = Title;
            textBox2.Text = TotalMarks;
            textBox3.Text = TotalWeightage;
            StdId = Id;
            button3.Text = "Update Assessment";

        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" )
            {
                if (button3.Text == "Add Assessment")
                {
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True");
                    conn.Open();
                    string Query = "insert into Assessment(Title,TotalMarks,TotalWeightage,DateCreated) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + DateTime.Now + "')";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Assessment Successfully Added");
                }
                else
                {
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OQV6IBM;Initial Catalog=ProjectB;Integrated Security=True");
                    conn.Open();
                    string Query = "update Assessment set Title='" + this.textBox1.Text + "',TotalMarks='" + this.textBox2.Text + "',TotalWeightage='" + this.textBox3.Text + "' where Id = '" + StdId + "'";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Assessment Updated Successfuly");

                }
                Assessment_GV f = new Assessment_GV();
                this.Hide();
                f.Show();
            }
            else
            {
                MessageBox.Show("Please fill all the fields ");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Assessment_GV h = new Assessment_GV();
            h.Show();
            this.Hide();
        }
    }
}
