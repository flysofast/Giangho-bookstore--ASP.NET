using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class LuuGioHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            string ms = Request.QueryString["ms"];
            QlSachDbDataContext db = new QlSachDbDataContext();
            var q = db.saches.Where(p => p.masach == ms);
           
                string ts = q.First().tensach;
                int gia = int.Parse(q.First().gia.ToString());

                int sl = 1;
                Gio gh;
                if (Session["gh"] == null)
                    gh = new Gio();
                else
                    gh = (Gio)Session["gh"];
                if (gh.ThemGioHang(ms, ts, sl, gia))
                {
                    Session["gh"] = gh;
                    //Response.Write("<script>alert('Đã thêm hàng vào giỏ!')</script>");
                    Response.Redirect("HienThiGioHang.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Số lượng hàng còn lại không đủ!');window.location ='default.aspx';</script>");
                }
        }
    }
}