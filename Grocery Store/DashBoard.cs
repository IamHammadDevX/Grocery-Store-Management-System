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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            invoice_history inv =new invoice_history();
            inv.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Add_Items add_Items = new Add_Items();
            add_Items.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            All_Items all_Items = new All_Items();
            all_Items.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Purchase purchase = new Purchase();
            purchase.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers.ShowDialog();
        }
    }
}
