using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach.UC
{
    public partial class UCLoaiAdmin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QlSachDbDataContext db=new QlSachDbDataContext();
            GridView1.DataSource = db.loais;
            GridView1.DataBind();
        }
    }
}