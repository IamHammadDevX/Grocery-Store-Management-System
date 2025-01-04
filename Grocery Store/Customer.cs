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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Weapon_Store
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            double contact = double.Parse(textBox2.Text);
            int age=int.Parse(textBox3.Text);
            double cnic=double.Parse(textBox4.Text);
            string gender=comboBox1.SelectedItem.ToString();


            try
            {
                using (OracleConnection connection = new OracleConnection(Class1.connectionString))
                {
                    connection.Open();
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO CUSTOMERS (CNIC, NAME, AGE, GENDER, CONTACT) VALUES (:cnic, :name, :age, :gender,:contact)";
                        command.Parameters.Add(":cnic", cnic);
                        command.Parameters.Add(":name", name);
                        command.Parameters.Add(":age", age);
                        command.Parameters.Add(":gender",gender);
                        command.Parameters.Add(":contact", contact);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Customer added successfully!");
                this.Hide();
                Invoice invoice = new Invoice();
                invoice.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Values Could not be Entered: " + ex.Message);
            }
            
        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }
    }
}
