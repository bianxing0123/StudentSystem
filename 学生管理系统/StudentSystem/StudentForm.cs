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

namespace StudentSystem
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
            label1.Text = label1.Text + Login.managename + "同学";
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=StudentSystem;User ID=sa;Password=sa.123");
            conn.Open();
            string strsql = "select * from Student where number ='" + Login.managename + "'";
            SqlDataAdapter custDA = new SqlDataAdapter(strsql, conn);
            DataSet dataSet = new DataSet();
            custDA.Fill(dataSet, "Student");
            dataGridView1.DataSource = dataSet;
            dataGridView1.DataMember = "Student";

            string strsql1 = "select coursename,score from Course,Score where (studentnumber = '" + Login.managename + "' and Score.coursenumber=Course.coursenumber)";
            SqlCommand com = new SqlCommand(strsql1, conn);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                listView1.Items.Add(reader["coursename"].ToString() + ":" + reader["score"].ToString());
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login.lo.Visible = true;
            this.Close();
        }
    }
}
