using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace fpt
{
    public partial class ado_demo : System.Web.UI.Page
    {
        string conStr = "SERVER=.\\TEW_SQLEXPRESS,1433;User=sa;Password=123"; // TRANQUANGKHAI26\TEW_SQLEXPRESS
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);
            string queryStr = "SELECT * FROM products";
            SqlDataAdapter adapter = new SqlDataAdapter(queryStr, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "products");
            //GridView1.DataSource = ds.Tables["products"].DefaultView;
            //GridView1.DataBind();
        }
    }
}