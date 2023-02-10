using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SerialRegistrationSMT_2._0
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user"].ToString();
            if (Session["area"].ToString() == "Calidad")
            {
                btnInRework.Visible = true;
                btnOutRework.Visible = true;
                btnLogout.Visible = true;
                btnConsultWO.Visible = true;
                btnScrap.Visible = true;
            }
            else if (Session["area"].ToString() == "IT")
            {
                btnOutRework.Visible = true;
                btnLogout.Visible = true;
                btnQRScan.Visible = true;
                btnInRework.Visible = true;
                btnConsultWO.Visible = true;
                btnScrap.Visible = true;
                btnValidateJar.Visible = true;
                btnScard.Visible = true;
                btnUsers.Visible = true;
            }
            //else
            //{
            //    btnQRScan.Visible = true;
            //    btnLogout.Visible = true;
            //    btnValidateJar.Visible = true;
            //    btnScard.Visible = true;
            //    if (Session["user"].ToString() == "ginad" || Session["user"].ToString() == "danielag")
            //        btnScrap.Visible = true;
            //    btnConsultWO.Visible = true;
            //}
        }

        protected void btnScard_Click(object sender, EventArgs e)
        {
            this.Session["ID"] = "Scard";
            this.Response.Redirect("ScanWO.aspx");
        }

        protected void btnQRScan_Click(object sender, EventArgs e)
        {
            this.Session["ID"] = "Main";
            this.Response.Redirect("ScanWO.aspx");
        }
    }
}