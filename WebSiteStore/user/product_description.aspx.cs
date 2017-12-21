using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class user_product_description : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ариорх\Documents\Visual Studio 2017\WebSites\WebSiteStore\App_Data\shopping.mdf;Integrated Security=True");
    int id, quantity;

    string product_name, product_description, product_price, product_quantity, product_images;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("display_item.aspx");
        }
        else
        {
            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from product where id=" + id + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            d1.DataSource = dt;
            d1.DataBind();
            con.Close();
        }
        quantity = get_quantity(id);
        if (quantity == 0)
        {
            l2.Visible = false;
            t1.Visible = false;
            b1.Visible = false;
            l1.Text = "Товар временно отсутствует";
        }
    }

    protected void b1_Click(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from product where id=" + id + "";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            product_name = dr["product_name"].ToString();
            product_description = dr["product_description"].ToString();
            product_price = dr["product_price"].ToString();
            product_quantity = dr["product_quantity"].ToString();
            product_images = dr["product_images"].ToString();
        }

        if (Convert.ToInt32(t1.Text) > Convert.ToInt32(product_quantity))
        {
            l1.Text = "Введите меньшее количество";
        }
        else
        {
            l1.Text = "";

            if (Request.Cookies["cobra"] == null)
            {
                Response.Cookies["cobra"].Value = product_name.ToString() + "," + product_description.ToString() + "," + product_price.ToString() + "," + t1.Text.ToString() + "," + product_images.ToString() + "," + id.ToString();
                Response.Cookies["cobra"].Expires = DateTime.Now.AddDays(1);
            }
            else
            {
                Response.Cookies["cobra"].Value = Request.Cookies["cobra"].Value + "|" + product_name.ToString() + "," + product_description.ToString() + "," + product_price.ToString() + "," + t1.Text.ToString() + "," + product_images.ToString() + "," + id.ToString();
                Response.Cookies["cobra"].Expires = DateTime.Now.AddDays(1);
            }

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update product set product_quantity = product_quantity -" + t1.Text + "where id=" + id;
            cmd1.ExecuteNonQuery();
            Response.Redirect("product_description.aspx?id=" + id.ToString());

        }
    }

    public int get_quantity(int id)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from product where id=" + id + "";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            quantity = Convert.ToInt32(dr["product_quantity"].ToString());
        }
        return quantity;
    }
}