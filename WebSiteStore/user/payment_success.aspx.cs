using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class user_payment_success : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ариорх\Documents\Visual Studio 2017\WebSites\WebSiteStore\App_Data\shopping.mdf;Integrated Security=True");
    string s, t;
    string[] array = new string[6];
    string order_id;
    string order = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        order = Request.QueryString["order"].ToString();

        if (order == Session["order_no"].ToString())
        {
            //getting user details and storing in order_details
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from registration where email='" + Session["user"].ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into orders values('" + dr["firstname"].ToString() + "','" + dr["lastname"].ToString() + "','" + dr["email"].ToString() + "','" + dr["address"].ToString() + "','" + dr["city"].ToString() + "','" + dr["mobile"].ToString() + "')";
                cmd1.ExecuteNonQuery();

            }
            //end storing user details

            //geting orders id from orders table
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select top 1 * from orders where email='" + Session["user"].ToString() + "' order by id desc ";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            da.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                order_id = dr2["Id"].ToString();
            }
            //ending geting orders id from orders table



            //getting ordered items from cookies

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

                    SqlCommand cmd3 = con.CreateCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "insert into order_details values('" 
                        + order_id.ToString() + 
                        "','" + array[0].ToString() + 
                        "','" + array[2].ToString() + 
                        "','" + array[3].ToString() + 
                        "','" + array[4].ToString() + "')";
                    cmd3.ExecuteNonQuery();

                }
            }
            //end getting ordered items from cookies
        }
        else
        {
            Response.Redirect("login.apsx");
        }
        con.Close();

        Session["user"] = "";
        Response.Cookies["cobra"].Expires = DateTime.Now.AddDays(-1);
        Response.Cookies["cobra"].Expires = DateTime.Now.AddDays(-1);

        Response.Redirect("display_item.aspx");
    }

}
