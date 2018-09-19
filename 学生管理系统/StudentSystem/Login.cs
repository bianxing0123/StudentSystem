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
    public partial class Login : Form
    {
        static public string managename;
        static public Login lo;
        public Login()
        {
            InitializeComponent();
            lo = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=StudentSystem;User ID=sa;Password=sa.123");
            string strsql = "select password from ManagerUser where username = '" + username + "'";
            conn.Open();
            SqlCommand com = new SqlCommand(strsql, conn);
            SqlDataReader da = com.ExecuteReader();
            string getpassword = "";
            while (da.Read())
            {
                flag = 1;
                getpassword = da["password"].ToString();
            }
            if (flag == 0)
            {
                System.Windows.Forms.MessageBox.Show("用户名不存在！", "错误！");
            }
            else if (flag == 1 && getpassword != password)
            {
                System.Windows.Forms.MessageBox.Show("用户名或密码错误!", "错误！");
            }
            else
            {
                if (radioButton1.Checked == true && username == "admin")
                {
                    System.Windows.Forms.MessageBox.Show("教师登录成功！", "成功！");
                    managename = username;
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else if (radioButton1.Checked == true && username != "admin")
                {
                    System.Windows.Forms.MessageBox.Show("非教师用户！", "错误！");
                }
                else if (radioButton2.Checked == true)
                {
                    System.Windows.Forms.MessageBox.Show("学生登录成功！", "成功！");
                    managename = username;
                    StudentForm studentForm = new StudentForm();
                    studentForm.Show();
                    this.Hide();
                }
            }
            da.Close();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }
    }
}
