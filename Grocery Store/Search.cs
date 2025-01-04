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
    public partial class Search : Form
    {
       
        public Search()
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

                    
                    string query = "SELECT itemname, price FROM items WHERE itemname LIKE '%' || :searchTerm || '%'";


                    
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

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            search();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
              
                string searchPriceStr = textBox2.Text.Trim();

               
                if (!decimal.TryParse(searchPriceStr, out decimal searchPrice))
                {
                    MessageBox.Show("Please enter a valid price.");
                    return;
                }

                
                using (OracleConnection con = new OracleConnection(Class1.connectionString))
                {
                  
                    con.Open();

                
                    string query = "SELECT itemname,price FROM items WHERE price = :searchPrice";

                    
                    using (OracleCommand cmd = new OracleCommand(query, con))
                    {
                
                        cmd.Parameters.Add(":searchPrice", OracleDbType.Decimal).Value = searchPrice;

                     
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
    }
}
