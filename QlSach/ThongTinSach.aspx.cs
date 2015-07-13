using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class ThongTinSach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ms = Request.QueryString["ms"];
            if (string.IsNullOrEmpty(ms)) Response.Write("<script>window.location='~/default.aspx';<script>");
            var master = (CustomerMasterPage)Page.Master;
            master.ChangeCenterTitle("Thông tin sách");

            QlSachDbDataContext db = new QlSachDbDataContext();
            sach s = db.saches.Single(p => p.masach == ms);
            lbLoaiSach.Text = db.loais.Single(p => p.maloai == s.maloai).tenloai;
            lbMaSach.Text = s.masach;
            lbTacgia.Text = s.tacgia;
            lbTieuDe.Text = s.tensach;
            lbSotap.Text = string.IsNullOrEmpty(s.sotap) ? "Chưa rõ" : s.sotap;
            lbTomTat.Text = s.tomtat;
            Image1.ImageUrl = s.anh;

            if (s.soluong > 0)
            {
                lbTinhTrang.Text = "Còn hàng";
                lbTinhTrang.ForeColor = Color.Green;
            }
            else
            {
                lbTinhTrang.Text = "Hết hàng";
                lbTinhTrang.ForeColor = Color.Red;
            }
        }
    }
}