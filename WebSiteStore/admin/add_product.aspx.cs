using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admin_add_product : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ариорх\Documents\Visual Studio 2017\WebSites\WebSiteStore\App_Data\shopping.mdf;Integrated Security=True");
    string image_name, image_name_for_dataase;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null)
        {
            Response.Redirect("adminlogin.aspx");
        }

        if (IsPostBack) return;
        ddl.Items.Clear();


        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from product_category";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
       foreach(DataRow dr in dt.Rows)
        {
            ddl.Items.Add(dr["product_category"].ToString());
        }
        con.Close();

    }

    protected void b1_Click(object sender, EventArgs e)
    {
        image_name = Class1.GetRandomPassword(10).ToString();
        f1.SaveAs(Request.PhysicalApplicationPath + "./images/" + image_name + f1.FileName.ToString());
        image_name_for_dataase = "images/" + image_name + f1.FileName.ToString();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "Insert into product values('" + t1.Text + "','" + t2.Text + "'," + t3.Text + "," + t4.Text + "," + t5.Text + ",'" + image_name_for_dataase.ToString() + "','"+ddl.SelectedItem.ToString()+"')";
        cmd.ExecuteNonQuery();
        con.Close();
        t1.Text = "";
        t2.Text = "";
        t3.Text = "";
        t4.Text = "";
        t5.Text = "";
    }
}