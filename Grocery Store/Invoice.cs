using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Weapon_Store
{
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();
        }

        private void Invoice_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(Class1.connectionString))
                {
                    connection.Open();

                    // Fetch data from SALE and CUSTOMERS tables using JOIN and aggregation
                    string query = "SELECT latest_customer.Name,   latest_customer.Contact,    sale_totals.TotalItems,  sale_totals.TotalPrice FROM (    SELECT Name, Contact FROM Customers    ORDER BY C_ID DESC) latest_customer CROSS JOIN (   SELECT     COUNT(Sale_id) AS TotalItems,    SUM(price) AS TotalPrice    FROM SALE) sale_totals WHERE ROWNUM = 1";

                    DataTable dataTable = new DataTable();

                    // Fetch data into DataTable
                    using (OracleDataAdapter adapter = new OracleDataAdapter(query, connection))
                    {
                        adapter.Fill(dataTable);
                    }

                    // Insert data into INVOICE table
                    string insertQuery = "INSERT INTO INVOICE (CUS_NAME, CONTACT, TOTALITEMS, TOTALPRICE) VALUES (:cusName, :contact, :totalItems, :totalPrice)";

                    foreach (DataRow row in dataTable.Rows)
                    {
                        using (OracleCommand command = new OracleCommand(insertQuery, connection))
                        {
                            command.Parameters.Add(":cusName", OracleDbType.Varchar2).Value = row["Name"].ToString();
                            command.Parameters.Add(":contact", OracleDbType.Varchar2).Value = row["Contact"].ToString();
                            command.Parameters.Add(":totalItems", OracleDbType.Int32).Value = Convert.ToInt32(row["TotalItems"]);
                            command.Parameters.Add(":totalPrice", OracleDbType.Decimal).Value = Convert.ToDecimal(row["TotalPrice"]);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Data inserted into INVOICE table successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            try
            {

                using (OracleConnection connection = new OracleConnection(Class1.connectionString))
                {

                    string query = "SELECT  CUS_NAME,CONTACT,TOTALITEMS,TOTALPRICE FROM (  SELECT  CUS_NAME,CONTACT,TOTALITEMS,TOTALPRICE FROM INVOICE    ORDER BY INVOICE_ID DESC) WHERE ROWNUM = 1";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        OracleDataAdapter adapter = new OracleDataAdapter(command);
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }







        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                using (OracleConnection connection = new OracleConnection(Class1.connectionString))
                {
                    connection.Open();

                    string Tquery = "TRUNCATE TABLE SALE";

                    using (OracleCommand command = new OracleCommand(Tquery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data is cleared!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
           dataGridView1.ClearSelection();
        }
    }
}
