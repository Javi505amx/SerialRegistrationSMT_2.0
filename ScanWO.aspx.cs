using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SerialRegistrationSMT_2._0
{
    public partial class ScanWO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtWorkOrder.Attributes.Add("OnClick", "selectWorkOrder()");
            txtWorkOrder.Attributes.Add("OnFocus", "selectWorkOrder()");
            Session["ID"].ToString();
            txtWorkOrder.Focus();
        }

        protected void txtWorkOrder_TextChanged(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand sqlCommand1 = new SqlCommand("GetModelQtyByWorkOrder", connection);
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand2 = sqlCommand1;
            connection.Open();
            sqlCommand2.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = txtWorkOrder.Text.ToUpper();
            SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
            sqlDataReader.Read();
            try
            {
                string str1 = sqlDataReader.GetString(sqlDataReader.GetOrdinal("WorkOrder"));
                string str2 = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Model"));
                int int32 = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Quantity"));
                connection.Close();
                Session["workOrder"] = str1;
                Session["modelWO"] = str2;
                Session["qty"] = int32.ToString();
                if (str2.Substring(0, 3) == "MX1")
                {
                    Response.Redirect("MainScan.aspx");
                }
                else
                {
                    if (!(str2.Substring(0, 3) == "MX2"))
                        return;
                    Response.Redirect("ScanScard.aspx");
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                txtWorkOrder.Focus();
            }
        }
    }
}