using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class CustomerMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
        }

        public void ChangeCenterTitle(string title)
        {
            lbCenterTitle.Text = title;
        }

        public void ChangeLoginTitle(string name)
        {
            lbLogin.Text = "Xin chào, " + name;
            lbLogin.Font.Bold = true;
        }
    }
}