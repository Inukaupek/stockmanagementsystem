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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addstock addstock1 = new addstock();
            addstock1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addquantity addquantity = new addquantity();
            addquantity.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            viewlog viewall = new viewlog(); 
            viewall.Show();
            this.Hide();
        }
    }
}
