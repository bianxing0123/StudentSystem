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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            label1.Text = label1.Text + Login.managename;
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

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string _number = textBox1.Text.Trim();
            string _name = textBox2.Text.Trim();
            string _sex = comboBox1.Text.Trim();
            string _age = textBox4.Text.Trim();
            string _colloge = textBox5.Text.Trim();
            string _class = textBox6.Text.Trim();
            string _phonenumber = textBox7.Text.Trim();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=StudentSystem;User ID=sa;Password=sa.123");
            string strsql = "insert into Student values ('" + _number + "','" + _name + "','" + _sex + "','" + _age + "','" + _colloge + "','" + _class + "','" + _phonenumber + "')";
            SqlCommand com2 = new SqlCommand(strsql, conn);
            conn.Open();
            int i = com2.ExecuteNonQuery();
            if (i > 0) System.Windows.Forms.MessageBox.Show("添加成功！", "成功！");
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string _number = textBox8.Text.Trim();
            string _changed = textBox3.Text.Trim();
            string _item = comboBox2.Text.Trim();
            string changeitem = "";
            if (_item == "学号") changeitem = "number";
            else if (_item == "姓名") changeitem = "name";
            else if (_item == "性别") changeitem = "sex";
            else if (_item == "年龄") changeitem = "age";
            else if (_item == "学院") changeitem = "collage";
            else if (_item == "班级") changeitem = "class";
            else if (_item == "手机号码") changeitem = "phonenumber";
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=StudentSystem;User ID=sa;Password=sa.123");
            string strsql = "update Student set " + changeitem + "='" + _changed + "' where number='" + _number + "'";
            SqlCommand com = new SqlCommand(strsql, conn);
            conn.Open();
            int i = com.ExecuteNonQuery();
            if (i > 0) System.Windows.Forms.MessageBox.Show("修改成功！", "成功！");
            else
            {
                System.Windows.Forms.MessageBox.Show("学号不存在！", "错误！");
            }
            conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string _number = textBox8.Text.Trim();
            string _item = comboBox2.Text.Trim();
            string changeitem = "";
            if (_item == "学号") changeitem = "number";
            else if (_item == "姓名") changeitem = "name";
            else if (_item == "性别") changeitem = "sex";
            else if (_item == "年龄") changeitem = "age";
            else if (_item == "学院") changeitem = "collage";
            else if (_item == "班级") changeitem = "class";
            else if (_item == "手机号码") changeitem = "phonenumber";
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=StudentSystem;User ID=sa;Password=sa.123");
            string strsql = "select " + changeitem + " from Student where number ='" + _number + "'";
            SqlCommand com = new SqlCommand(strsql, conn);
            conn.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (!reader.Read())
            {
                System.Windows.Forms.MessageBox.Show("学号不存在！", "错误！");
            }
            else
            {
                textBox9.Text = reader[changeitem].ToString();
            }
            reader.Close();
            conn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            comboBox3.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=StudentSystem;User ID=sa;Password=sa.123");
            string strsql = "select number,name from Student";
            SqlCommand com = new SqlCommand(strsql, conn);
            conn.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                comboBox3.Items.Add(reader["number"].ToString() + " " + reader["name"].ToString());
            }
            reader.Close();
            conn.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string _text = comboBox3.Text.Trim();
            string[] strarray = _text.Split(' ');
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=StudentSystem;User ID=sa;Password=sa.123");
            string strsql = "delete from Student where number ='" + strarray[0] + "'";
            SqlCommand com = new SqlCommand(strsql, conn);
            conn.Open();
            int i = com.ExecuteNonQuery();
            if (i > 0) System.Windows.Forms.MessageBox.Show("删除成功！", "成功！");
            else System.Windows.Forms.MessageBox.Show("学号不存在！", "错误！");
            conn.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=StudentSystem;User ID=sa;Password=sa.123");
            string strsql = "select number,name from Student";
            SqlCommand com = new SqlCommand(strsql, conn);
            conn.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                comboBox4.Items.Add(reader["number"].ToString() + " " + reader["name"].ToString());
            }
            reader.Close();

            strsql = "select coursenumber,coursename from Course";
            com = new SqlCommand(strsql, conn);
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                comboBox5.Items.Add(reader["coursenumber"].ToString() + " " + reader["coursename"].ToString());
            }
            reader.Close();
            conn.Close();
        }


        private void button16_Click(object sender, EventArgs e)
        {
            textBox11.Text = "";
            textBox12.Text = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string _coursenumber = textBox12.Text.Trim();
            string _coursename = textBox11.Text.Trim();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=StudentSystem;User ID=sa;Password=sa.123");
            string strsql = "insert into Course values ('" + _coursenumber + "','" + _coursename + "')";
            SqlCommand com2 = new SqlCommand(strsql, conn);
            conn.Open();
            int i = com2.ExecuteNonQuery();
            if (i > 0) System.Windows.Forms.MessageBox.Show("添加成功！", "成功！");
            conn.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string _text = comboBox4.Text.Trim();
            string _text1 = comboBox5.Text.Trim();
            string[] strarray = _text.Split(' ');
            string[] strarray_course = _text1.Split(' ');
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=StudentSystem;User ID=sa;Password=sa.123");
            string strsql = "select score from Score where studentnumber ='" + strarray[0] + "'" + " and coursenumber ='" + strarray_course[0] + "'";
            SqlCommand com = new SqlCommand(strsql, conn);
            conn.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (!reader.Read())
            {
                System.Windows.Forms.MessageBox.Show("成绩不存在！", "错误！");
            }
            else
            {
                textBox10.Text = reader["score"].ToString();
            }
            reader.Close();
            conn.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string _text = comboBox4.Text.Trim();
            string _text1 = comboBox5.Text.Trim();
            string score = textBox10.Text.Trim();
            string[] strarray = _text.Split(' ');
            string[] strarray_course = _text1.Split(' ');
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=StudentSystem;User ID=sa;Password=sa.123");
            string strsql = "select score from Score where studentnumber ='" + strarray[0] + "'" + " and coursenumber ='" + strarray_course[0] + "'";
            SqlCommand com = new SqlCommand(strsql, conn);
            conn.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (!reader.Read())
            {
                flag = 1;
            }
            else
            {
                flag = 2;
            }
            reader.Close();
            if (flag == 1)
            {
                string newstrsql = "insert Score values ('" + strarray[0] + "','" + strarray_course[0] + "','" + score + "')";
                SqlCommand com2 = new SqlCommand(newstrsql, conn);
                int i = com2.ExecuteNonQuery();
                if (i > 0) System.Windows.Forms.MessageBox.Show("添加成功！", "成功！");
            }
            else if (flag == 2)
            {
                string newstrsql = "update Score set score ='" + score + "' where studentnumber ='" + strarray[0] + "' and coursenumber ='" + strarray_course[0] + "'";
                SqlCommand com2 = new SqlCommand(newstrsql, conn);
                int i = com2.ExecuteNonQuery();
                if (i > 0) System.Windows.Forms.MessageBox.Show("修改成功！", "成功！");
            }
            conn.Close();
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            textBox11.Text = "";
            textBox12.Text = "";
        }
    }
}
