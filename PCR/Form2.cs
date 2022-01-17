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
using System.Text.RegularExpressions;

namespace PCR
{
    public partial class Form2 : Form
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserRegistrtionDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Form2()
        {
            InitializeComponent();
        }


       public void button1_Click(object sender, EventArgs e)
        {
            string mailpattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox8.Text == "" || textBox6.Text == "" || textBox4.Text == "") MessageBox.Show("Please fill all fields");
            else if (!Regex.IsMatch(textBox3.Text, mailpattern)) MessageBox.Show("Enter a valid email adress");
            else if (textBox3.Text != textBox4.Text) MessageBox.Show("'Email' and 'Confirm Email adress' must match");
            else if (textBox5.Text != textBox6.Text) MessageBox.Show("'Password' and 'Confirm password' must match");
            else if (textBox8.Text.Length!=13) MessageBox.Show("CNP showld have 13 numbers");
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {

                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("UserAdd", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@FirstName", textBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", textBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@EmailAdress", textBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", textBox5.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@CNP", textBox8.Text.Trim());
                    string un;
                    un = textBox1.Text.Trim().Substring(0, 3) + textBox2.Text.Trim().Substring(0, 3)+ textBox8.Text.Trim().Substring(7, 6);
                   
                    sqlCmd.Parameters.AddWithValue("@UserName",un);
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfull Registration");
                    Clear();
                }
            }
            
        }
        void Clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text= textBox6.Text= textBox8.Text="";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

        

