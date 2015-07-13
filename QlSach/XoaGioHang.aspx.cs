using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class XoaGioHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["gh"] = null;
            Response.Write("<script>alert(\"Xóa giỏ hàng thành công!\");window.location='default.aspx';</script>");
        }
    }
}