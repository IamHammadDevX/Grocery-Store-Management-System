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
    public partial class Purchase : Form
    {
        
        public Purchase()
        {
            InitializeComponent();
            Loadddataintolist();
        }
        private void Loadddataintolist()
        {
        
            string query = "SELECT ITEMNAME FROM ITEMS";

            using (OracleConnection connection = new OracleConnection(Class1.connectionString))
            {
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                
                                listBox1.Items.Add(reader["ITEMNAME"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(Class1.connectionString))
                {
                    connection.Open();

                    // Check if dataGridView1 and its Rows collection are not null
                    if (dataGridView1 != null && dataGridView1.Rows != null)
                    {
                        // Iterate through each row in the DataGridView
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            // Check if the row is not a new row and contains cells
                            if (!row.IsNewRow && row.Cells != null)
                            {
                                // Check if the cells at the specified indexes are not null
                                // Extract data from DataGridView cells
                                    string name = row.Cells[0].Value.ToString(); // Accessing the first column
                                    int price = int.Parse(row.Cells[3].Value.ToString()); // Accessing the fourth column

                                    // Insert data into another table
                                    string insertQuery = "INSERT INTO Sale (NAME, PRICE) VALUES (:name, :price)";
                                    using (OracleCommand Command = new OracleCommand(insertQuery, connection))
                                    {
                                        Command.Parameters.Add(":name", OracleDbType.Varchar2).Value = name;
                                        Command.Parameters.Add(":price", OracleDbType.Int64).Value = price;

                                        Command.ExecuteNonQuery();
                                    }
                                
                            }
                        }
                    }
                }

                MessageBox.Show("Proceeding!!!!!");
                this.Hide();
                Customer contact = new Customer();
                contact.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding data to AnotherTable: " + ex.Message);
            }



        }

        private void Purchase_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Initialize button click count
        private List<string> selectedItems = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Add selected item to the list
                foreach (var selectedItem in listBox1.SelectedItems)
                {
                    string itemName = selectedItem.ToString();
                    selectedItems.Add(itemName);
                }

                // Update DataGridView with all selected items
                UpdateDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void UpdateDataGridView()
        {
            // Clear existing rows in the DataGridView
            dataGridView1.Rows.Clear();

            // Add all selected items to the DataGridView
            foreach (string itemName in selectedItems)
            {
                string query = "SELECT * FROM ITEMS WHERE ITEMNAME = :itemName";

                using (OracleConnection connection = new OracleConnection(Class1.connectionString))
                {
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(":itemName", OracleDbType.Varchar2).Value = itemName;

                        connection.Open();
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            // Read the item details
                            while (reader.Read())
                            {
                                // Add the item details to the DataGridView
                                dataGridView1.Rows.Add(reader["ITEMNAME"], reader["TYPE"], reader["WEIGHT"], reader["PRICE"]);
                            }
                        }
                    }
                }
            }
        }

    }
}

