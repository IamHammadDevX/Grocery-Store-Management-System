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
    public partial class invoice_history : Form
    {
        public invoice_history()
        {
            InitializeComponent();
        }

        private void invoice_history_Load(object sender, EventArgs e)
        {
            try
            {

                using (OracleConnection connection = new OracleConnection(Class1.connectionString))
                {

                    string query = "SELECT INVOICE_ID, CUS_NAME,CONTACT,TOTALITEMS,TOTALPRICE FROM INVOICE";
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
    }
}
