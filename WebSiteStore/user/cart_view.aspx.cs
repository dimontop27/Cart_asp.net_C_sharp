using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_cart_view : System.Web.UI.Page
{
    string s, t;
    string[] array = new string[6];
    int total = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[7] { new DataColumn("product_name"), new DataColumn("product_description"), new DataColumn("product_price"), new DataColumn("product_quantity"), new DataColumn("product_images"), new DataColumn("id"), new DataColumn("product_id") });
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
                total = total + (Convert.ToInt32(array[2].ToString()) * Convert.ToInt32(array[3].ToString()));
            }
        }
        d1.DataSource = dt;
        d1.DataBind();

        l1.Text ="Сумма: "+ total.ToString();
    }

    protected void b1_Click(object sender, EventArgs e)
    {
        Session["checkoutbutton"] = "yes";
        Response.Redirect("checkout.aspx");
    }
}