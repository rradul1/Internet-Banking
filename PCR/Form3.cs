using System;
using System.Collections.Generic;
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
    public partial class Form3 : Form
    {
        public static string a,b;
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserRegistrtionDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
      

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select Password from tblUser where UserName= @Username ", con);
                cmd.Parameters.AddWithValue("@Username", this.textBox1.Text);
                con.Open();

                var nId = cmd.ExecuteScalar();

                if (nId != null)
                {
                    if ((string)nId == this.textBox2.Text)
                    {
                        Form4 f4 = new Form4();
                        f4.Show();
                        a = textBox1.Text;
                        b = textBox2.Text;

                    }
                    else MessageBox.Show("parola gresita");
                }
                else MessageBox.Show("utilixator inexistent");
            }
        }

       
    }
}
