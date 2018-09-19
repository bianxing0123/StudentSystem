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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string doublepassword = textBox3.Text.Trim();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=StudentSystem;User ID=sa;Password=sa.123");
            string strsql = "select * from ManagerUser where username = '" + username + "'";
            conn.Open();
            SqlCommand com = new SqlCommand(strsql, conn);
            Object obj = com.ExecuteScalar();
            if (obj != null)
            {
                System.Windows.Forms.MessageBox.Show("用户已存在！", "错误！");
            }
            else
            {
                if (doublepassword != password)
                {
                    System.Windows.Forms.MessageBox.Show("两次密码输入不一致！", "错误！");
                }
                else
                {
                    strsql = "insert into ManagerUser values ('" + username + "','" + password + "')";
                    SqlCommand com1 = new SqlCommand(strsql, conn);
                    int i = com1.ExecuteNonQuery();
                    if (i > 0) System.Windows.Forms.MessageBox.Show("注册成功！", "成功！");
                    this.Close();
                }
            }
            conn.Close();
        }
    }
}
