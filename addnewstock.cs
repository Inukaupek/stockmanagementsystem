using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace stockmanagementsystem
{
    internal class addnewstock:addiquantity
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-1JH6M0G\\SQLEXPRESS;Initial Catalog=stockainsert;Integrated Security=True");
        public int stockid { get; set; }
        public string itemname { get; set; }
        public int quantity { get; set; }
        public DateTime dateadded { get; set; }

       

        
        public void addstock(int stockid, string itemname, int quantity, DateTime dateadded)
        {
            

            string sql = "insert into AddStock_Table(stockid,itemname,quantity,dateadded)values('" + stockid + "','" + itemname + "','" + quantity + "','" + dateadded + "')";
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
           

        }



        public List<addnewstock> get_All_the_stocks()
        {
            List<addnewstock> the_stocks = new List<addnewstock>();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-1JH6M0G\\SQLEXPRESS;Initial Catalog=stockainsert;Integrated Security=True");
            string sql = "select * from AddStock_table";
            string sql2 = "select dateupdated from addquantity_table";



            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader view = cmd.ExecuteReader();
            while (view.Read())
            {
                addnewstock the_stock = new addnewstock();
                the_stock.stockid = (int)view["stockid"];
                the_stock.itemname = view["itemname"].ToString();
                the_stock.quantity = (int)view["quantity"];
                the_stock.dateadded = (DateTime)view["dateadded"];
                the_stock.updateddate = (DateTime)view["dateupdated"];




                the_stocks.Add(the_stock);

            }

            return the_stocks;

        }

    }
}
