using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class admin_adminlogin : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ариорх\Documents\Visual Studio 2017\WebSites\WebSiteStore\App_Data\shopping.mdf;Integrated Security=True");
    int i =0;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void b1_Click(object sender, EventArgs e)
    {
        connection.Open();
        SqlCommand cmd = connection.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from admin_login where username='"+t1.Text+"' and password='"+t2.Text+"'";
        cmd.ExecuteNonQuery();
        DataTable dataTable = new DataTable();
        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
        dataAdapter.Fill(dataTable);
        i =Convert.ToInt32(dataTable.Rows.Count.ToString());

        if (i == 1)
        {
            Session["admin"] = t1.Text;
            Response.Redirect("add_product.aspx");
        }
        else
        {
            l1.Text = "Неправильный логин или пароль";
        }
        Response.Write(i);

    }
}