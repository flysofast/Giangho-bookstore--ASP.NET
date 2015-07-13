using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
             var page = Master as AdminMasterPage;
            page.ChangeCenterTitle("Danh sách sách");
        }
    }
}