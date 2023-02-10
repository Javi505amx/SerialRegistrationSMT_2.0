using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SerialRegistrationSMT_2._0
{
    public partial class MainScan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            string str = Session["workOrder"].ToString();
            lblRWO.Text = str;
            lblRM.Text = Session["modelWO"].ToString();
            lblRQT.Text = Session["qty"].ToString();
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand sqlCommand1 = new SqlCommand("GetAccumulatedWO", connection1);
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand2 = sqlCommand1;
            connection1.Open();
            sqlCommand2.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str;
            sqlCommand2.CommandTimeout = 9000;
            SqlDataReader sqlDataReader1 = sqlCommand2.ExecuteReader();
            sqlDataReader1.Read();
            int int32_1 = sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("Accumulated"));
            connection1.Close();
            lblRAT.Text = int32_1.ToString();
            SqlConnection connection2 = new SqlConnection(connectionString);
            SqlCommand sqlCommand3 = new SqlCommand("GetAccumulatedDay", connection2);
            sqlCommand3.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand4 = sqlCommand3;
            connection2.Open();
            sqlCommand4.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str;
            sqlCommand4.CommandTimeout = 9000;
            SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
            sqlDataReader2.Read();
            int int32_2 = sqlDataReader2.GetInt32(sqlDataReader2.GetOrdinal("Accumulated"));
            connection2.Close();
            lblRAD.Text = int32_2.ToString();
            SqlConnection connection3 = new SqlConnection(connectionString);
            SqlCommand sqlCommand5 = new SqlCommand("GetTotalMain", connection3);
            sqlCommand5.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand6 = sqlCommand5;
            connection3.Open();
            sqlCommand6.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str;
            sqlCommand6.CommandTimeout = 9000;
            SqlDataReader sqlDataReader3 = sqlCommand6.ExecuteReader();
            sqlDataReader3.Read();
            int int32_3 = sqlDataReader3.GetInt32(sqlDataReader3.GetOrdinal("Repair"));
            connection3.Close();
            lblQtyRepair.Text = int32_3.ToString();
            SqlConnection connection4 = new SqlConnection(connectionString);
            SqlCommand sqlCommand7 = new SqlCommand("GetAccumulatedWOScrap", connection4);
            sqlCommand7.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand8 = sqlCommand7;
            connection4.Open();
            sqlCommand8.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str;
            SqlDataReader sqlDataReader4 = sqlCommand8.ExecuteReader();
            sqlDataReader4.Read();
            int int32_4 = sqlDataReader4.GetInt32(sqlDataReader4.GetOrdinal("Accumulated"));
            connection4.Close();
            lblQtyScrap.Text = int32_4.ToString();
            txtJarScan.Focus();
        }

        protected void txtSerialScan_TextChanged(object sender, EventArgs e)
        {
            string str1 = Session["workOrder"].ToString();
            string str2 = Session["userLogin"].ToString();
            string text = txtSerialScan.Text;
            string str3 = text.Substring(0, 4);
            text.Substring(4, 3);
            string[] strArray = text.Split('-');
            string upper = strArray[0].ToUpper();
            string str4 = strArray[1].ToUpper();
            string s1 = upper.Substring(8);
            if (strArray.Length > 2)
                str4 = str4 + "-" + strArray[2].ToUpper();
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand sqlCommand1 = new SqlCommand("GetDetailsWorkOrder", connection1);
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand2 = sqlCommand1;
            connection1.Open();
            sqlCommand2.Parameters.Add("@Main", SqlDbType.VarChar, 50).Value = str4;
            sqlCommand2.Parameters.Add("@YearWeek", SqlDbType.VarChar, 50).Value = str3;
            sqlCommand2.CommandTimeout = 9000;
            SqlDataReader sqlDataReader1 = sqlCommand2.ExecuteReader();
            sqlDataReader1.Read();
            try
            {
                string str5 = sqlDataReader1.GetString(sqlDataReader1.GetOrdinal("WorkOrder"));
                string s2 = sqlDataReader1.GetString(sqlDataReader1.GetOrdinal("InitialSN"));
                string s3 = sqlDataReader1.GetString(sqlDataReader1.GetOrdinal("FinalSN"));
                string str6 = sqlDataReader1.GetString(sqlDataReader1.GetOrdinal("YearWeek"));
                int int32_1 = sqlDataReader1.GetInt32(sqlDataReader1.GetOrdinal("Quantity"));
                connection1.Close();
                lblRWO.Text = str5;
                lblRQT.Text = int32_1.ToString();
                lblRSN.Text = text;
                lblRM.Text = str4;
                if (str3 == str6 && int.Parse(s1) >= int.Parse(s2) && int.Parse(s1) <= int.Parse(s3) && str1 == str5)
                {
                    SqlConnection connection2 = new SqlConnection(connectionString);
                    SqlCommand sqlCommand3 = new SqlCommand("AddScanQRMain", connection2);
                    sqlCommand3.CommandType = CommandType.StoredProcedure;
                    SqlCommand sqlCommand4 = sqlCommand3;
                    connection2.Open();
                    sqlCommand4.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                    sqlCommand4.Parameters.Add("@Model", SqlDbType.VarChar, 50).Value = str4;
                    sqlCommand4.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 50).Value = text.ToUpper();
                    sqlCommand4.Parameters.Add("@ScanDate", SqlDbType.DateTime, 50).Value = DateTime.Now;
                    sqlCommand4.Parameters.Add("@UserScan", SqlDbType.VarChar, 30).Value = str2.ToLower();
                    sqlCommand4.CommandTimeout = 9000;
                    SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
                    sqlDataReader2.Read();
                    int int32_2 = sqlDataReader2.GetInt32(sqlDataReader2.GetOrdinal("rowAffected"));
                    connection2.Close();
                    switch (int32_2)
                    {
                        case 0:
                            SqlConnection connection3 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand5 = new SqlCommand("GetAccumulatedWO", connection3);
                            sqlCommand5.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand6 = sqlCommand5;
                            connection3.Open();
                            sqlCommand6.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand6.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader3 = sqlCommand6.ExecuteReader();
                            sqlDataReader3.Read();
                            int int32_3 = sqlDataReader3.GetInt32(sqlDataReader3.GetOrdinal("Accumulated"));
                            connection3.Close();
                            lblRAT.Text = int32_3.ToString();
                            SqlConnection connection4 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand7 = new SqlCommand("GetAccumulatedDay", connection4);
                            sqlCommand7.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand8 = sqlCommand7;
                            connection4.Open();
                            sqlCommand8.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand8.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader4 = sqlCommand8.ExecuteReader();
                            sqlDataReader4.Read();
                            int int32_4 = sqlDataReader4.GetInt32(sqlDataReader4.GetOrdinal("Accumulated"));
                            connection4.Close();
                            lblRAD.Text = int32_4.ToString();
                            SqlConnection connection5 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand9 = new SqlCommand("GetTotalMain", connection5);
                            sqlCommand9.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand10 = sqlCommand9;
                            connection5.Open();
                            sqlCommand10.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand10.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader5 = sqlCommand10.ExecuteReader();
                            sqlDataReader5.Read();
                            int int32_5 = sqlDataReader5.GetInt32(sqlDataReader5.GetOrdinal("Repair"));
                            connection5.Close();
                            lblQtyRepair.Text = int32_5.ToString();
                            SqlConnection connection6 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand11 = new SqlCommand("GetAccumulatedWOScrap", connection6);
                            sqlCommand11.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand12 = sqlCommand11;
                            connection6.Open();
                            sqlCommand12.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            SqlDataReader sqlDataReader6 = sqlCommand12.ExecuteReader();
                            sqlDataReader6.Read();
                            int int32_6 = sqlDataReader6.GetInt32(sqlDataReader6.GetOrdinal("Accumulated"));
                            connection6.Close();
                            lblQtyScrap.Text = int32_6.ToString();
                            lblResult.Text = "QR DUPLICADO";
                            lblResult.ForeColor = Color.Red;
                            break;
                        case 1:
                            SqlConnection connection7 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand13 = new SqlCommand("AddInfoSerial", connection7);
                            sqlCommand13.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand14 = sqlCommand13;
                            connection7.Open();
                            sqlCommand14.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 50).Value = text;
                            sqlCommand14.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader7 = sqlCommand14.ExecuteReader();
                            sqlDataReader7.Read();
                            sqlDataReader7.GetInt32(sqlDataReader7.GetOrdinal("rowAffected"));
                            connection7.Close();
                            SqlConnection connection8 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand15 = new SqlCommand("GetAccumulatedWO", connection8);
                            sqlCommand15.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand16 = sqlCommand15;
                            connection8.Open();
                            sqlCommand16.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand16.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader8 = sqlCommand16.ExecuteReader();
                            sqlDataReader8.Read();
                            int int32_7 = sqlDataReader8.GetInt32(sqlDataReader8.GetOrdinal("Accumulated"));
                            connection8.Close();
                            lblRAT.Text = int32_7.ToString();
                            SqlConnection connection9 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand17 = new SqlCommand("GetAccumulatedDay", connection9);
                            sqlCommand17.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand18 = sqlCommand17;
                            connection9.Open();
                            sqlCommand18.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand18.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader9 = sqlCommand18.ExecuteReader();
                            sqlDataReader9.Read();
                            int int32_8 = sqlDataReader9.GetInt32(sqlDataReader9.GetOrdinal("Accumulated"));
                            connection9.Close();
                            lblRAD.Text = int32_8.ToString();
                            SqlConnection connection10 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand19 = new SqlCommand("GetTotalMain", connection10);
                            sqlCommand19.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand20 = sqlCommand19;
                            connection10.Open();
                            sqlCommand20.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand20.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader10 = sqlCommand20.ExecuteReader();
                            sqlDataReader10.Read();
                            int int32_9 = sqlDataReader10.GetInt32(sqlDataReader10.GetOrdinal("Repair"));
                            connection10.Close();
                            lblQtyRepair.Text = int32_9.ToString();
                            SqlConnection connection11 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand21 = new SqlCommand("GetAccumulatedWOScrap", connection11);
                            sqlCommand21.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand22 = sqlCommand21;
                            connection11.Open();
                            sqlCommand22.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            SqlDataReader sqlDataReader11 = sqlCommand22.ExecuteReader();
                            sqlDataReader11.Read();
                            int int32_10 = sqlDataReader11.GetInt32(sqlDataReader11.GetOrdinal("Accumulated"));
                            connection11.Close();
                            lblQtyScrap.Text = int32_10.ToString();
                            lblResult.Text = "QR GUARDADO";
                            lblResult.ForeColor = Color.Green;
                            break;
                        case 2:
                            SqlConnection connection12 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand23 = new SqlCommand("GetAccumulatedWO", connection12);
                            sqlCommand23.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand24 = sqlCommand23;
                            connection12.Open();
                            sqlCommand24.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand24.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader12 = sqlCommand24.ExecuteReader();
                            sqlDataReader12.Read();
                            int int32_11 = sqlDataReader12.GetInt32(sqlDataReader12.GetOrdinal("Accumulated"));
                            connection12.Close();
                            lblRAT.Text = int32_11.ToString();
                            SqlConnection connection13 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand25 = new SqlCommand("GetAccumulatedDay", connection13);
                            sqlCommand25.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand26 = sqlCommand25;
                            connection13.Open();
                            sqlCommand26.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand26.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader13 = sqlCommand26.ExecuteReader();
                            sqlDataReader13.Read();
                            int int32_12 = sqlDataReader13.GetInt32(sqlDataReader13.GetOrdinal("Accumulated"));
                            connection13.Close();
                            lblRAD.Text = int32_12.ToString();
                            SqlConnection connection14 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand27 = new SqlCommand("GetTotalMain", connection14);
                            sqlCommand27.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand28 = sqlCommand27;
                            connection14.Open();
                            sqlCommand28.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand28.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader14 = sqlCommand28.ExecuteReader();
                            sqlDataReader14.Read();
                            int int32_13 = sqlDataReader14.GetInt32(sqlDataReader14.GetOrdinal("Repair"));
                            connection14.Close();
                            lblQtyRepair.Text = int32_13.ToString();
                            SqlConnection connection15 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand29 = new SqlCommand("GetAccumulatedWOScrap", connection15);
                            sqlCommand29.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand30 = sqlCommand29;
                            connection15.Open();
                            sqlCommand30.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            SqlDataReader sqlDataReader15 = sqlCommand30.ExecuteReader();
                            sqlDataReader15.Read();
                            int int32_14 = sqlDataReader15.GetInt32(sqlDataReader15.GetOrdinal("Accumulated"));
                            connection15.Close();
                            lblQtyScrap.Text = int32_14.ToString();
                            lblResult.Text = "PIEZA EN REPARACIÓN";
                            lblResult.ForeColor = Color.Red;
                            break;
                        case 3:
                            SqlConnection connection16 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand31 = new SqlCommand("GetAccumulatedWO", connection16);
                            sqlCommand31.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand32 = sqlCommand31;
                            connection16.Open();
                            sqlCommand32.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand32.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader16 = sqlCommand32.ExecuteReader();
                            sqlDataReader16.Read();
                            int int32_15 = sqlDataReader16.GetInt32(sqlDataReader16.GetOrdinal("Accumulated"));
                            connection16.Close();
                            lblRAT.Text = int32_15.ToString();
                            SqlConnection connection17 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand33 = new SqlCommand("GetAccumulatedDay", connection17);
                            sqlCommand33.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand34 = sqlCommand33;
                            connection17.Open();
                            sqlCommand34.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand34.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader17 = sqlCommand34.ExecuteReader();
                            sqlDataReader17.Read();
                            int int32_16 = sqlDataReader17.GetInt32(sqlDataReader17.GetOrdinal("Accumulated"));
                            connection17.Close();
                            lblRAD.Text = int32_16.ToString();
                            SqlConnection connection18 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand35 = new SqlCommand("GetTotalMain", connection18);
                            sqlCommand35.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand36 = sqlCommand35;
                            connection18.Open();
                            sqlCommand36.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            sqlCommand36.CommandTimeout = 9000;
                            SqlDataReader sqlDataReader18 = sqlCommand36.ExecuteReader();
                            sqlDataReader18.Read();
                            int int32_17 = sqlDataReader18.GetInt32(sqlDataReader18.GetOrdinal("Repair"));
                            connection18.Close();
                            lblQtyRepair.Text = int32_17.ToString();
                            SqlConnection connection19 = new SqlConnection(connectionString);
                            SqlCommand sqlCommand37 = new SqlCommand("GetAccumulatedWOScrap", connection19);
                            sqlCommand37.CommandType = CommandType.StoredProcedure;
                            SqlCommand sqlCommand38 = sqlCommand37;
                            connection19.Open();
                            sqlCommand38.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str5;
                            SqlDataReader sqlDataReader19 = sqlCommand38.ExecuteReader();
                            sqlDataReader19.Read();
                            int int32_18 = sqlDataReader19.GetInt32(sqlDataReader19.GetOrdinal("Accumulated"));
                            connection19.Close();
                            lblQtyScrap.Text = int32_18.ToString();
                            lblResult.Text = "PIEZA SCRAP";
                            lblResult.ForeColor = Color.Red;
                            break;
                    }
                }
                else if (str3 == str6 && int.Parse(s1) >= int.Parse(s2) && int.Parse(s1) <= int.Parse(s3) && str1 != str5)
                {
                    SqlConnection connection20 = new SqlConnection(connectionString);
                    SqlCommand sqlCommand39 = new SqlCommand("GetAccumulatedWO", connection20);
                    sqlCommand39.CommandType = CommandType.StoredProcedure;
                    SqlCommand sqlCommand40 = sqlCommand39;
                    connection20.Open();
                    sqlCommand40.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str1;
                    sqlCommand40.CommandTimeout = 9000;
                    SqlDataReader sqlDataReader20 = sqlCommand40.ExecuteReader();
                    sqlDataReader20.Read();
                    int int32_19 = sqlDataReader20.GetInt32(sqlDataReader20.GetOrdinal("Accumulated"));
                    connection20.Close();
                    lblRAT.Text = int32_19.ToString();
                    SqlConnection connection21 = new SqlConnection(connectionString);
                    SqlCommand sqlCommand41 = new SqlCommand("GetAccumulatedDay", connection21);
                    sqlCommand41.CommandType = CommandType.StoredProcedure;
                    SqlCommand sqlCommand42 = sqlCommand41;
                    connection21.Open();
                    sqlCommand42.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str1;
                    sqlCommand42.CommandTimeout = 9000;
                    SqlDataReader sqlDataReader21 = sqlCommand42.ExecuteReader();
                    sqlDataReader21.Read();
                    int int32_20 = sqlDataReader21.GetInt32(sqlDataReader21.GetOrdinal("Accumulated"));
                    connection21.Close();
                    lblRAD.Text = int32_20.ToString();
                    SqlConnection connection22 = new SqlConnection(connectionString);
                    SqlCommand sqlCommand43 = new SqlCommand("GetTotalMain", connection22);
                    sqlCommand43.CommandType = CommandType.StoredProcedure;
                    SqlCommand sqlCommand44 = sqlCommand43;
                    connection22.Open();
                    sqlCommand44.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str1;
                    sqlCommand44.CommandTimeout = 9000;
                    SqlDataReader sqlDataReader22 = sqlCommand44.ExecuteReader();
                    sqlDataReader22.Read();
                    int int32_21 = sqlDataReader22.GetInt32(sqlDataReader22.GetOrdinal("Repair"));
                    connection22.Close();
                    lblQtyRepair.Text = int32_21.ToString();
                    SqlConnection connection23 = new SqlConnection(connectionString);
                    SqlCommand sqlCommand45 = new SqlCommand("GetAccumulatedWOScrap", connection23);
                    sqlCommand45.CommandType = CommandType.StoredProcedure;
                    SqlCommand sqlCommand46 = sqlCommand45;
                    connection23.Open();
                    sqlCommand46.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = str1;
                    SqlDataReader sqlDataReader23 = sqlCommand46.ExecuteReader();
                    sqlDataReader23.Read();
                    int int32_22 = sqlDataReader23.GetInt32(sqlDataReader23.GetOrdinal("Accumulated"));
                    connection23.Close();
                    lblQtyScrap.Text = int32_22.ToString();
                    lblResult.Text = "QR NO COINCIDE CON LA WORK ORDER ESCANEADA";
                    lblResult.ForeColor = Color.Red;
                }
                else if (int.Parse(s1) > int.Parse(s3))
                {
                    lblResult.Text = "QR NO ENCONTRADO. CONTACTE AL DEPTO DE IT.";
                    lblResult.ForeColor = Color.Red;
                    txtSerialScan.Text = "";
                    txtSerialScan.Focus();
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = "QR NO ENCONTRADO. CONTACTE AL DEPTO DE IT.";
                lblResult.ForeColor = Color.Red;
                txtSerialScan.Text = "";
                txtSerialScan.Focus();
            }
            txtSerialScan.Text = "";
            txtSerialScan.Focus();
        }

        protected void txtJarScan_TextChanged(object sender, EventArgs e)
        {
            string text = this.txtJarScan.Text;
            DateTime now = DateTime.Now;
            string connectionString = ConfigurationManager.ConnectionStrings["pasta"].ConnectionString;
            SqlConnection connection1 = new SqlConnection(connectionString);
            SqlCommand sqlCommand1 = new SqlCommand("GetSettingTimes", connection1);
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand2 = sqlCommand1;
            connection1.Open();
            sqlCommand2.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 20).Value = (object)text;
            SqlDataReader sqlDataReader1 = sqlCommand2.ExecuteReader();
            sqlDataReader1.Read();
            DateTime dateTime1 = sqlDataReader1.GetDateTime(sqlDataReader1.GetOrdinal("SettingEnd"));
            connection1.Close();
            SqlConnection connection2 = new SqlConnection(connectionString);
            SqlCommand sqlCommand3 = new SqlCommand("GetOpeningTimes", connection2);
            sqlCommand3.CommandType = CommandType.StoredProcedure;
            SqlCommand sqlCommand4 = sqlCommand3;
            connection2.Open();
            sqlCommand4.Parameters.Add("@SerialNumber", SqlDbType.VarChar, 50).Value = (object)text;
            SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
            sqlDataReader2.Read();
            DateTime dateTime2 = sqlDataReader2.GetDateTime(sqlDataReader2.GetOrdinal("OpenPastaExpiration"));
            connection2.Close();
            if (now > dateTime1 && now < dateTime2)
            {
                this.lblJarScan.Text = "CUMPLIÓ CON EL TIEMPO DE AMBIENTACIÓN REQUERIDO";
                this.lblJarScan.ForeColor = Color.Green;
                this.txtJarScan.Enabled = false;
                this.txtSerialScan.Enabled = true;
                this.txtSerialScan.Focus();
            }
            else if (now < dateTime1)
            {
                this.lblJarScan.Text = "NO HA CUMPLIDO CON EL TIEMPO DE AMBIENTACION";
                this.lblJarScan.ForeColor = Color.Red;
                this.txtJarScan.Text = "";
                this.txtJarScan.Focus();
            }
            else
            {
                if (!(now > dateTime2))
                    return;
                this.lblJarScan.Text = "HA TERMINADO EL TIEMPO DE VIDA UTIL. TOME OTRA PASTA POR FAVOR.";
                this.lblJarScan.ForeColor = Color.Red;
                this.txtJarScan.Text = "";
                this.txtJarScan.Focus();
            }
        }
    }
}