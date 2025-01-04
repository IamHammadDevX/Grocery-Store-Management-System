using Oracle.DataAccess.Client;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Weapon_Store
{
    public partial class Sign_up : Form
    {
        public Sign_up()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Collect user inputs
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string gmail = textBox3.Text.Trim();

            // Validate inputs
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(gmail))
            {
                MessageBox.Show("All fields are required. Please fill in all fields.");
                return;
            }

            if (!IsValidEmail(gmail))
            {
                MessageBox.Show("Please enter a valid Gmail address.");
                return;
            }

            try
            {
                // Insert data into the database
                using (OracleConnection connection = new OracleConnection(Class1.connectionString))
                {
                    connection.Open();
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO USERS (USERNAME, PASSWORD, GMAIL) VALUES (:userName, :password, :gmail)";
                        command.Parameters.Add(":userName", OracleDbType.Varchar2).Value = username;
                        command.Parameters.Add(":password", OracleDbType.Varchar2).Value = password;
                        command.Parameters.Add(":gmail", OracleDbType.Varchar2).Value = gmail;

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Account created successfully!");
                ClearFields();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        // Method to validate email using regex
        private bool IsValidEmail(string email)
        {
            var emailRegex = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            return Regex.IsMatch(email, emailRegex);
        }

        // Method to clear input fields
        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
