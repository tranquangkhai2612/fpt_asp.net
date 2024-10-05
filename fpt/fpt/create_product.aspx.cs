using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace fpt
{
    public partial class create_product : System.Web.UI.Page
    {
        string conStr = "SERVER=.\\TEW_SQLEXPRESS,1433;User=sa;Password=123";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void onCreate(object sender, EventArgs e) { 
            string name = txtName.Text.trim();
            string priceStr = txtPrice.Text.trim();
            int price = Convert.ToInt32(priceStr);

            SqlConnection con = new SqlConnection(conStr);
            string query = "INSERT INTO products (name,price) VALUES (@name,@price)";
            SqlCommand com = new SqlCommand(query,con);
            con.Open();
            com.Parameters.Add(new SqlParameter("name",name));
            com.Parameters.Add(new SqlParameter("price",price));
            int result = com.ExecuteNonQuery();
            if (result > 0) {
                Response.Redirect("home.aspx");
            }
            con.Close();
        }
    }
}