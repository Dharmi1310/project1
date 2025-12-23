using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Web;
using System;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.HttpMethod == "POST")
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];

            string connStr = "server=localhost;database=yourdb;uid=root;pwd=yourpassword;";
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM userdetails WHERE username=@u AND passward=@p";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1)
                {
                    Response.Redirect("success.html");
                }
                else
                {
                    Response.Redirect("failed.html");
                }
            }
        }
    }
}
