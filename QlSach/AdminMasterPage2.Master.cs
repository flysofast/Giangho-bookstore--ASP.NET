using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class AdminMasterPage2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Page.MaintainScrollPositionOnPostBack = true;
            if (Session["dn"].ToString() == "") Response.Redirect("Default.aspx");
            QlSachDbDataContext db1 = new QlSachDbDataContext();
            try
            {

                var w = db1.DangNhaps.Where(p => p.TenDangNhap == (Session["dn"]).ToString()).First();
                if (!w.Quyen) Response.Redirect("Default.aspx");
            }
            catch
            {
                Response.Redirect("Default.aspx");
            }
        }

        

        public void ChangeLoginTitle(string name)
        {
            lbLogin.Text = "Xin chào, " + name;
            lbLogin.Font.Bold = true;
        }
    }
}