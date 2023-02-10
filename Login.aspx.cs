using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SerialRegistrationSMT_2._0
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Request.Cookies["userLogin"] != null)
                    Response.Cookies.Add(new HttpCookie("userLogin")
                    {
                        Expires = DateTime.Now.AddDays(-1.0)
                    });
                if ((string)Session["userLogin"] != null)
                    Session.Remove("userLogin");
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.AddHeader("Pragma", "no-cache");
            txtUser.Focus();
        }
        public void saveDataUser()
        {
            string text = txtUser.Text;
            ScanHistoric.userLogin = txtUser.Text;
            ScanHistoric.loginDate = DateTime.Now.ToString("MM/dd/yyyy");
            ScanHistoric.loginTime = DateTime.Now.ToString("HH:mm:ss");
            ScanHistoric.longDateTime = ScanHistoric.loginDate + " " + ScanHistoric.loginTime;
            Session["userLogin"] = txtUser.Text;
            Session["password"] = txtPassword.Text;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand sqlCommand1 = new SqlCommand("GetFullName", connection);
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand2 = sqlCommand1;
            sqlCommand2.Connection.Open();
            sqlCommand2.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = text;
            SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
            sqlDataReader.Read();
            string str1 = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Area"));
            string str2 = sqlDataReader.GetString(sqlDataReader.GetOrdinal("FullName"));
            connection.Close();
            Session["fullName"] = str2.ToLower();
            Session["area"] = str1;
            Session["user"] = text;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtUser.Text == "")
            {
                lblError.Text = "Ingresa tus datos";
                lblError.ForeColor = Color.Red;
            }
            else
            {
                string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection connection1 = new SqlConnection(connectionString);
                SqlCommand sqlCommand1 = new SqlCommand("ValidateUser", connection1);
                sqlCommand1.CommandType = CommandType.StoredProcedure;
                SqlCommand sqlCommand2 = sqlCommand1;
                sqlCommand2.Connection.Open();
                sqlCommand2.Parameters.Add("@User", SqlDbType.VarChar, 50).Value = txtUser.Text;
                sqlCommand2.Parameters.Add("@Pass", SqlDbType.VarChar, 50).Value = txtPassword.Text;
                sqlCommand2.CommandTimeout = 9000;
                SqlDataReader sqlDataReader1 = sqlCommand2.ExecuteReader();
                sqlDataReader1.Read();
                if (sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("Users")) > 0)
                {
                    SqlConnection connection2 = new SqlConnection(connectionString);
                    SqlCommand sqlCommand3 = new SqlCommand("ValidateUserAdmin", connection2);
                    sqlCommand3.CommandType = CommandType.StoredProcedure;
                    SqlCommand sqlCommand4 = sqlCommand3;
                    sqlCommand4.Connection.Open();
                    sqlCommand4.Parameters.Add("@User", SqlDbType.VarChar, 50).Value = txtUser.Text;
                    sqlCommand4.Parameters.Add("@Pass", SqlDbType.VarChar, 50).Value = txtPassword.Text;
                    sqlCommand4.CommandTimeout = 9000;
                    SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
                    sqlDataReader2.Read();
                    sqlDataReader2.GetInt32(sqlDataReader2.GetOrdinal("Users"));
                    connection2.Close();
                    saveDataUser();
                    Response.Redirect("Menu.aspx");
                }
                else
                {
                    lblError.Text = "Usuario o contraseña incorrectos";
                    lblError.ForeColor = Color.Red;
                    txtPassword.Focus();
                }
                connection1.Close();
            }
        }

        protected void txtUser_TextChanged(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }
    }
}