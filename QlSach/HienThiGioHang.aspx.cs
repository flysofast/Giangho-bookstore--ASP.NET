using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class HienThiGioHang1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var page = Master as CustomerMasterPage;
            page.ChangeCenterTitle("Giỏ hàng");
            Gio gh = new Gio();
            gh = (Gio)Session["gh"];
            if (gh == null)
            {
                btCapNhat.Visible = false;
                btThanhToan.Visible = false;
                btXoaGio.Visible = false;
                lbTT.Text = "Bạn chưa có mặt hàng nào trong giỏ!";
            }
            else
            {
                GridView1.DataSource = gh.dt;
                GridView1.DataBind();
                LTongtien.Text = string.Format("{0:0,0}", gh.TongTien()) + " VNĐ";
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header)
            {

                TextBox textbox = new TextBox();
                textbox.ID = "tb";
                textbox.Text = "0";
                HyperLink hyperLink = new HyperLink();
                hyperLink.Text = "Xóa";
                hyperLink.NavigateUrl = "XoaMatHangTrongGio.aspx?ms=" + e.Row.Cells[0].Text;
                e.Row.Cells[5].Controls.Add(textbox);
                e.Row.Cells[6].Controls.Add(hyperLink);
            }
        }

        protected void btCapNhat_Click(object sender, EventArgs e)
        {
            Gio gh = new Gio();
            gh = (Gio)Session["gh"];
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string ms = GridView1.Rows[i].Cells[0].Text.Trim();
                TextBox tb = new TextBox();
                tb = (TextBox)GridView1.Rows[i].Cells[5].FindControl("tb");
                int sl = int.Parse(tb.Text);
                if (sl != 0)
                    if(!gh.ThemGioHang(ms, "", sl, 0))
                        Response.Write("<script>alert('Số lượng hàng còn lại không đủ!')</script>");
            }
            Session["gh"] = gh;
            GridView1.DataSource = gh.dt;
            GridView1.DataBind();
            LTongtien.Text = string.Format("{0:0,0}", gh.TongTien()) + " VNĐ";
        }

        protected void btXoaGio_Click(object sender, EventArgs e)
        {
            Session["gh"] = null;
            GridView1.DataSource = null;
            GridView1.DataBind();
            LTongtien.Text = "0 VNĐ";
            //Type cstype = this.GetType();

            //// Get a ClientScriptManager reference from the Page class.
            //ClientScriptManager cs = Page.ClientScript;

            //// Check to see if the startup script is already registered.
            //if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
            //{
            //    String cstext = "alert('Xóa giỏ hàng thành công!');";
            //    cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
            //}
            Response.Write("<script>alert(\"Xóa giỏ hàng thành công!\")</script>");
        }

        protected void btThanhToan_Click(object sender, EventArgs e)
        {
            QlSachDbDataContext db = new QlSachDbDataContext();
            
            
            //admin hoặc chưa đăng nhập thì ko được đặt mua
            if ((string)Session["dn"] == "" )
            {

                Response.Redirect("ThongTinKhachHang.aspx");
            }
            else
            {
                var q = db.KhachHangs.Where(p => p.TenDangNhap == (string)Session["dn"]);
                var dn = db.DangNhaps.Single(p => p.TenDangNhap == (string)Session["dn"]);
                // Tài khoản chưa đang đăng nhập chưa có mã khách hàng, nghĩa là được tạo bởi admin, không phải tự đăng kí
                if (q.Count() == 0||dn.Quyen)
                {
                    Response.Write("<script>alert(\"Tài khoản này không được phép giao dịch!\");window.location='default.aspx'</script>");
                    return;
                }

                long makh = q.First().Makh;

                long mahd = 0;
                if (!db.hoadons.Any())
                    mahd = 0;
                else
                    mahd = db.hoadons.Max(p => p.MaHoaDon);
                hoadon hd = new hoadon();
                hd.MaHoaDon = mahd + 1;
                hd.makh = makh;
                hd.damua = false;
                hd.NgayMua = DateTime.Now;
                db.hoadons.InsertOnSubmit(hd);
                db.SubmitChanges();
                var dt = new DataTable();
                var gh = new Gio();
                gh = (Gio)Session["gh"];
                dt = gh.dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var cthd = new ChiTietHoaDon();
                    long macthd;
                    if (!db.ChiTietHoaDons.Any())
                        macthd = 0;
                    else
                        macthd = db.ChiTietHoaDons.Max(p => p.MaChiTietHD);
                    cthd.MaChiTietHD = macthd + 1;
                    cthd.MaHoaDon = mahd + 1;
                    cthd.MaSach = dt.Rows[i]["masach"].ToString();
                    cthd.SoLuongMua = int.Parse(dt.Rows[i]["soluong"].ToString());

                    //Trừ số lượng sách mua
                    sach s = db.saches.Single(p => p.masach == cthd.MaSach);
                    s.soluong -= cthd.SoLuongMua;

                    db.ChiTietHoaDons.InsertOnSubmit(cthd);
                    db.SubmitChanges();
                    //Type cstype = this.GetType();

                    //// Get a ClientScriptManager reference from the Page class.
                    //ClientScriptManager cs = Page.ClientScript;

                    //// Check to see if the startup script is already registered.
                    //if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    //{
                    //    String cstext = "alert('Thành toán thành công!');";
                    //    cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    //}
                   

                }
                Response.Write("<script>alert(\"Đặt mua thành công!\")</script>");

            }
            Session["gh"] = null;
            Response.Write("<script>window.location='default.aspx'</script>");
        }
    }
}