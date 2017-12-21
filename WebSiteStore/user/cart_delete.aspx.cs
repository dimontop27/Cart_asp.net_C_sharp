using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class user_cart_delete : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ариорх\Documents\Visual Studio 2017\WebSites\WebSiteStore\App_Data\shopping.mdf;Integrated Security=True");
    string s, t;
    string[] array = new string[6];
    int id;
    string product_name, product_description, product_price, product_quantity, product_images;
    int count = 0;
    int product_id, quantity;

    protected void Page_Load(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.QueryString["id"].ToString());
        DataTable dt = new DataTable();
        dt.Rows.Clear();
        dt.Columns.AddRange(new DataColumn[7] { new DataColumn("product_name"), new DataColumn("product_description"), new DataColumn("product_price"),
            new DataColumn("product_quantity"), new DataColumn("product_images"),new DataColumn("id"),new DataColumn("product_id") });
        if (Request.Cookies["cobra"] != null)
        {
            s = Convert.ToString(Request.Cookies["cobra"].Value);
            string[] strArr = s.Split('|');
            for (int i = 0; i < strArr.Length; i++)
            {
                t = Convert.ToString(strArr[i].ToString());
                string[] strArr1 = t.Split(',');
                for (int j = 0; j < strArr1.Length; j++)
                {
                    array[j] = strArr1[j].ToString();
                }
                dt.Rows.Add(array[0].ToString(), array[1].ToString(), array[2].ToString(), array[3].ToString(), array[4].ToString(), i.ToString(), array[5].ToString());
            }
        }

        count = 0;
        foreach (DataRow dr in dt.Rows)
        {
            if (count == id)
            {
                product_id = Convert.ToInt32(dr["product_id"].ToString());
                quantity = Convert.ToInt32(dr["product_quantity"].ToString());
            }
            count++;
        }
        count = 0;

        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update product set product_quantity = product_quantity+" + quantity + " where id=" + product_id;
        cmd.ExecuteNonQuery();
        con.Close();



        dt.Rows.RemoveAt(id);


        Response.Cookies["cobra"].Expires = DateTime.Now.AddDays(-1);
        Response.Cookies["cobra"].Expires = DateTime.Now.AddDays(-1);

        foreach (DataRow dr in dt.Rows)
        {
            product_name = dr["product_name"].ToString();
            product_description = dr["product_description"].ToString();
            product_price = dr["product_price"].ToString();
            product_quantity = dr["product_quantity"].ToString();
            product_images = dr["product_images"].ToString();
            product_id = Convert.ToInt32(dr["product_id"].ToString());

            count++;

            if (count == 1)
            {
                Response.Cookies["cobra"].Value = product_name.ToString() + "," + product_description.ToString() + "," + product_price.ToString() + "," + product_quantity.ToString() + "," + product_images.ToString() + "," + product_id.ToString();
                Response.Cookies["cobra"].Expires = DateTime.Now.AddDays(1);
            }
            else
            {
                Response.Cookies["cobra"].Value = Request.Cookies["cobra"].Value + "|" + product_name.ToString() + "," + product_description.ToString() + "," + product_price.ToString() + "," + product_quantity.ToString() + "," + product_images.ToString() + "," + product_id.ToString(); 
                Response.Cookies["cobra"].Expires = DateTime.Now.AddDays(1);
            }
        }
        Response.Redirect("cart_view.aspx");
    }
}