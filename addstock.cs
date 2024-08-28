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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace stockmanagementsystem
{
    public partial class addstock : Form
    {
        public addstock()
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
            con.Open();
            SqlCommand commandCheck2 = new SqlCommand("select itemname from AddStock_table where itemname='" + itemname.Text + "'", con);
            string Sname = (string)commandCheck2.ExecuteScalar();
            con.Close();

            if(Sid == stockid.Text)
            {
                MessageBox.Show("stock id is already existing");
            }
            else
            {
                if(Sname == itemname.Text)
                {
                    MessageBox.Show("item name is already existing");
                }
                else
                {
                    addnewstock newadd1 = new addnewstock();
                    newadd1.addstock(int.Parse(stockid.Text), itemname.Text, int.Parse(quantity.Text), DateTime.Parse(dateadded.Text));
                    MessageBox.Show("Item Added");
                }
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
