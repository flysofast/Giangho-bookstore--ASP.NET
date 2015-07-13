using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class HienThiKhachHang1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if ((string)Session["dn"] == "")
            {
                hlDoiThongTin.Visible = false; 
                Label1.Text = "Đăng nhập để xem thông tin giao dịch của tài khoản!";
            }
            var page = Master as CustomerMasterPage;
            page.ChangeCenterTitle("Thông tin khách hàng");
            QlSachDbDataContext db = new QlSachDbDataContext();
            var q = from kh in db.KhachHangs
                    join hd in db.hoadons on kh.Makh equals hd.makh
                    join cthd in db.ChiTietHoaDons on hd.MaHoaDon equals cthd.MaHoaDon
                    join s in db.saches on cthd.MaSach equals s.masach
                    where (kh.TenDangNhap == (string)Session["dn"])
                    select new
                               {
                                   s.masach,
                                   kh.Makh,
                                   kh.hoten,
                                   s.tensach,
                                   s.tacgia,
                                   cthd.SoLuongMua,
                                   hd.MaHoaDon,
                                   hd.NgayMua,
                                   tt = hd.damua == true ? "Đã thanh toán" : "Chưa thanh toán"

                               };
            GridView1.DataSource = q;
            GridView1.DataBind();
        }


    }
}