using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weapon_Store
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public void connection()
        {
           
            String username = textBox1.Text; //get username from the form field
            String password = textBox2.Text; //get password from form field
            try
            {

                OracleConnection con = new OracleConnection(Class1.connectionString);
                con.Open();
                //create query
                OracleCommand cmd = new OracleCommand("SELECT * FROM users WHERE username = '" + username + "' AND password = '" + password + "'", con);
                //execute query and read results
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read(); //read row from database
                                   //you can access that row using attribute name like this
                    MessageBox.Show(reader["username"].ToString() + " Logged in Successfully");
                    this.Hide();
                    DashBoard dash = new DashBoard();
                    dash.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect");
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error occurred" + e.ToString());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sign_up sign_Up = new Sign_up();
            sign_Up.ShowDialog();
        }
    }
}
