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
    public partial class All_Items : Form
    {
        
        public All_Items()
        {
            InitializeComponent();
        }
        private void PopulateDataGridView()
        {
            try
            {
                
                using (OracleConnection connection = new OracleConnection(Class1.connectionString))
                {
                    
                    string query = "SELECT ITEMNAME,TYPE,WEIGHT,PRICE FROM ITEMS";
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

        private void All_Items_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }
    }
}
