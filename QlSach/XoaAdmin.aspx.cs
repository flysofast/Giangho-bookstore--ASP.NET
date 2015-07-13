using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class XoaAdmin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Lấy mã sách cần xóa
            string ms = Request.QueryString["ms"];
            QlSachDbDataContext db = new QlSachDbDataContext();
            //Lọc ra sách có mã cần xóa
            sach s = db.saches.Single(p => p.masach == ms);
            //Lấy đường dẫn file ảnh cần xóa
            if (!string.IsNullOrEmpty(s.anh))
            {
                string dd = Server.MapPath(s.anh);
                //Xóa file ảnh trên server

                //************

                File.Delete(dd);
            }

            //Xóa sách có mã sách =ms
            db.saches.DeleteOnSubmit(s);
            //Lưu lại vào csdl
            db.SubmitChanges();
            Response.Redirect("Admin.aspx");
        }
    }
}