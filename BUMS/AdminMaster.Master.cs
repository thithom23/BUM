using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUMS
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        public string active0 = "";
        public string active1 = "";
        public string active2 = "";
        public string active3 = "";
        public string active4 = "";
        public string active5 = "";
        public string active6 = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.IsPostBack)
            {
               
                active0 = "active";
                string click = Request.QueryString["click"];
                if (click == "0")
                {
                    active0 = "active";
                    active1 = "";
                    active2 = "";
                    active3 = "";
                    active4 = "";
                    active5 = "";
                    active6 = "";
                }
                if (click == "1")
                {
                    active0 = "";
                    active1 = "active";
                    active2 = "";
                    active3 = "";
                    active4 = "";
                    active5 = "";
                    active6 = "";

                }
                if (click == "2")
                {
                    active0 = "";
                    active1 = "";
                    active2 = "active";
                    active3 = "";
                    active4 = "";
                    active5 = "";
                    active6 = "";
                }
                if (click == "3")
                {
                    active0 = "";
                    active1 = "";
                    active2 = "";
                    active3 = "active";
                    active4 = "";
                    active5 = "";
                    active6 = "";
                }
                if (click == "4")
                {
                    active0 = "";
                    active1 = "";
                    active2 = "";
                    active3 = "";
                    active4 = "active";
                    active5 = "";
                    active6 = "";
                }
                if (click == "5")
                {
                    active0 = "";
                    active1 = "";
                    active2 = "";
                    active3 = "";
                    active4 = "";
                    active5 = "active";
                    active6 = "";
                }
                if (click == "6")
                {
                    active0 = "";
                    active1 = "";
                    active2 = "";
                    active3 = "";
                    active4 = "";
                    active5 = "";
                    active6 = "active";
                }
                Page.DataBind();
            }
        }

        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}