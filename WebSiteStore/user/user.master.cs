using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class user_user : System.Web.UI.MasterPage
{
    string s, t;
    string[] array = new string[6];
    int total = 0;
    int totalcount = 0;
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ариорх\Documents\Visual Studio 2017\WebSites\WebSiteStore\App_Data\shopping.mdf;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from product_category";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        dl1.DataSource = dt;
        dl1.DataBind();

        con.Close();

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
                total = total + (Convert.ToInt32(array[2].ToString()) * Convert.ToInt32(array[3].ToString()));
                totalcount ++;
                cart_total_item.Text = totalcount.ToString();
                cart_total_price.Text = total.ToString();
            }
        }
    }
}
