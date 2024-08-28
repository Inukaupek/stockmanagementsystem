using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockmanagementsystem
{
    internal class addiquantity
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-1JH6M0G\\SQLEXPRESS;Initial Catalog=stockainsert;Integrated Security=True");

        public DateTime updateddate { get; set; }

        public int quantityadded { get; set; }

        public void addquantity(int stockid, int quantityadded, DateTime updatedate)
        {
            con.Open();

            string selectQuery = "SELECT quantity FROM AddStock_table WHERE stockid = @stockid";
            SqlCommand selectCmd = new SqlCommand(selectQuery, con);
            selectCmd.Parameters.AddWithValue("@stockid", stockid);

            int currentQuantity = 0;
            using (SqlDataReader reader = selectCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    currentQuantity = (int)reader["quantity"];
                }
            }


            int newQuantity = currentQuantity + quantityadded;

           
            string insertQuantityQuery = "INSERT INTO addquantity_table(stockid, quantityadded, updateddate) VALUES (@stockid, @quantityadded, @updatedate)";
            SqlCommand insertQuantityCmd = new SqlCommand(insertQuantityQuery, con);
            insertQuantityCmd.Parameters.AddWithValue("@stockid", stockid);
            insertQuantityCmd.Parameters.AddWithValue("@quantityadded", quantityadded);
            insertQuantityCmd.Parameters.AddWithValue("@updatedate", updatedate);
            
           

            string updateStockQuery = "UPDATE AddStock_table SET quantity = @newQuantity, dateupdated = @dateupdated WHERE stockid = @stockid";
            SqlCommand updateStockCmd = new SqlCommand(updateStockQuery, con);
            updateStockCmd.Parameters.AddWithValue("@newQuantity", newQuantity);
            updateStockCmd.Parameters.AddWithValue("@stockid", stockid);
            updateStockCmd.Parameters.AddWithValue("@dateupdated", updatedate);
            updateStockCmd.ExecuteNonQuery();
            con.Close();
        }
       

    }
}
