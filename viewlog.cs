using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stockmanagementsystem
{
    public partial class viewlog : Form
    {
        public viewlog()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void viewlog_Load(object sender, EventArgs e)
        {
            addnewstock viewall = new addnewstock();
            List<addnewstock> viewstock = viewall.get_All_the_stocks();
            dataGridView1.DataSource = viewstock;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu mainmenu = new menu();
            mainmenu.Show();
            this.Hide();
        }
    }
}
