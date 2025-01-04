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
    public partial class Customers : Form
    {
        
        public Customers()
        {
            InitializeComponent();
        }
        private void search()
        {
            try
            {

                string searchTerm = textBox1.Text.Trim();
                using (OracleConnection con = new OracleConnection(Class1.connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM CUSTOMERS WHERE NAME LIKE '%' || :searchTerm || '%'";
                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {

                        cmd.Parameters.Add(":searchTerm", OracleDbType.Varchar2).Value = searchTerm;


                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {

                            DataTable dataTable = new DataTable();


                            adapter.Fill(dataTable);


                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Customers_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                using (OracleConnection connection = new OracleConnection(Class1.connectionString))
                {

                    string query = "SELECT * FROM CUSTOMERS";
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

        private void button1_Click(object sender, EventArgs e)
        {
            search();
        }
    }
}
