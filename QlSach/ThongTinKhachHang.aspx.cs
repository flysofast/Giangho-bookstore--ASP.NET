using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class ThongTinKhachHang1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var page = Master as CustomerMasterPage;
            page.ChangeCenterTitle("Đăng kí thông tin");
            
        }
    }
}