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
    public partial class Add_Items : Form
    {
        

        public Add_Items()
        {
            InitializeComponent();
           
            comboBox1.Items.Add("Fruit");
            comboBox1.Items.Add("Drink");
            comboBox1.Items.Add("Medicine");
            comboBox1.Items.Add("Household Item");
            comboBox1.Items.Add("Vegetable");
            comboBox1.Items.Add("Baked Item");
            comboBox1.Items.Add("Meat");
            comboBox1.Items.Add("Packed Item");
            comboBox1.Items.Add("Dairy Product");
            comboBox1.Items.Add("Health Care Item");
            
        }

        private void Add_Items_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string itemName = textBox1.Text;
            string itemType = comboBox1.SelectedItem.ToString();
            decimal weight = numericUpDown1.Value;
            int price = int.Parse(textBox2.Text);

           
            try
            {
                using (OracleConnection connection = new OracleConnection(Class1.connectionString))
                {
                    connection.Open();
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO ITEMS (ITEMNAME, TYPE, WEIGHT, PRICE) VALUES (:itemName, :itemType, :weight, :price)";
                        command.Parameters.Add(":itemName", itemName);
                        command.Parameters.Add(":itemType", itemType);
                        command.Parameters.Add(":weight", weight);
                        command.Parameters.Add(":price", price);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Item added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Values Could not be Entered: "+ex.Message);
            }
            
        }
    }
}