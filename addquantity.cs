using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stockmanagementsystem
{
    public partial class addquantity : Form
    {
        public addquantity()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1JH6M0G\\SQLEXPRESS;Initial Catalog=stockainsert;Integrated Security=True");
            con.Open();
            SqlCommand commandCheck = new SqlCommand("select convert(varchar(50),stockid) from Addstock_table where convert(varchar(50),stockid)='" + stockid.Text + "'", con);
            string Sid = (string)commandCheck.ExecuteScalar();
            con.Close();
            if (Sid == stockid.Text)
            {
                addnewstock newadd2 = new addnewstock();
                newadd2.addquantity(int.Parse(stockid.Text), int.Parse(newquantity.Text), DateTime.Parse(dateupdated.Text));

                MessageBox.Show("Quantity Added to the item");
            }
            else
            {
                MessageBox.Show("The item does not exist in the stock");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu mainmenu = new menu();
            mainmenu.Show();
            this.Hide();


        }
    }
}
