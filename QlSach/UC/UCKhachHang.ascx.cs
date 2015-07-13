using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace QlSach.UC
{
    public partial class UCKhachHang : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QlSachDbDataContext db = new QlSachDbDataContext();
            
            if (Request.QueryString["act"] == "tdtt" && (string)Session["dn"] != "")
            {
                var dnhap = db.DangNhaps.Single(p => p.TenDangNhap == (string)Session["dn"]);
                var a = db.KhachHangs.Where(p => p.TenDangNhap == dnhap.TenDangNhap);
                // Tài khoản chưa đang đăng nhập chưa có mã khách hàng, nghĩa là được tạo bởi admin, không phải tự đăng kí
                if (a.Count() == 0||dnhap.Quyen)
                {
                    Response.Write("<script>alert(\"Tài khoản này không được phép sử dụng chức năng này!\");window.location='default.aspx'</script>");
                    return;
                }

                GridView1.Visible = false;
                lbGioHang.Visible = false;
                lbTT.Visible = false;
                LTongtien.Visible = false;
                tbTenDangNhap.Enabled = false;
                RequireFieldValidator3.Enabled = false;
                Button1.Text = "Thay đổi";
             
                var q = from dn in db.DangNhaps
                        join kh in db.KhachHangs on dn.TenDangNhap equals kh.TenDangNhap
                        where dn.TenDangNhap == (string)Session["dn"]
                        select new
                                   {
                                       kh.hoten,
                                       kh.TenDangNhap,
                                       dn.MatKhau,
                                       kh.diachi,
                                       kh.SoDT,
                                       kh.email
                                   };

                tbTenDangNhap.Text = q.First().TenDangNhap;
                tbDiachi.Text = q.First().diachi;
                tbEmail.Text = q.First().email;
                tbSdt.Text = q.First().SoDT;
                tbHoten.Text = q.First().hoten;
            }
            else
            {
                //if (Session["gh"] == null)
                //    Response.Redirect("default.aspx");
                //else


                Gio gh = new Gio();
                gh = (Gio)Session["gh"];
                if (gh == null)
                {
                    if ((string)Session["dn"] != "") Response.Redirect("default.aspx");

                    lbTT.Visible = false;
                    lbGioHang.Visible = false;
                }
                else
                {
                    lbTT.Visible = true;
                    lbGioHang.Visible = true;
                    GridView1.DataSource = gh.dt;
                    GridView1.DataBind();
                    LTongtien.Text = string.Format("{0:0,0}", gh.TongTien()) + " VNĐ";
                }

            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            QlSachDbDataContext db = new QlSachDbDataContext();
            if ((string)Session["dn"] == "")
            {

                if (!(db.DangNhaps.Where(p => p.TenDangNhap == tbTenDangNhap.Text)).Any())
                {
                    DangNhap dn = new DangNhap();
                    dn.TenDangNhap = tbTenDangNhap.Text;
                    dn.MatKhau = Encoding.MaHoa(Encoding.key, tbMK.Text);
                    dn.Quyen = false;
                    dn.hoten = tbHoten.Text;
                    db.DangNhaps.InsertOnSubmit(dn);
                    db.SubmitChanges();
                }
                else
                {
                    //Type cstype = this.GetType();

                    //// Get a ClientScriptManager reference from the Page class.
                    //ClientScriptManager cs = Page.ClientScript;

                    //// Check to see if the startup script is already registered.
                    //if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                    //{
                    //    String cstext = "alert('Tên đăng nhập này đã tồn tại!');";
                    //    cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    //}
                    Response.Write("<script>alert(\"Tên đăng nhập này đã tồn tại!\")</script>");
                    
                    return;
                }
                long makh;
                if (db.KhachHangs.Count() == 0)
                    makh = 0;
                else
                    makh = db.KhachHangs.Max(p => p.Makh);
                KhachHang kh = new KhachHang();
                kh.Makh = makh + 1;
                kh.hoten = tbHoten.Text;
                kh.SoDT = tbSdt.Text;
                kh.email = tbEmail.Text;
                kh.diachi = tbDiachi.Text;
                kh.TenDangNhap = tbTenDangNhap.Text;
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();

                if (Session["gh"] == null)
                {
                    Response.Write("<script>alert(\"Giỏ hàng trống!\");window.location='default.aspx';</script>");
                    //Response.Redirect("default.aspx");
                    return;
                }

                long mahd = 0;
                if (db.hoadons.Count() == 0)
                    mahd = 0;
                else
                    mahd = db.hoadons.Max(p => p.MaHoaDon);
                hoadon hd = new hoadon();
                hd.MaHoaDon = mahd + 1;
                hd.makh = kh.Makh;
                hd.damua = false;
                hd.NgayMua = DateTime.Now;
                db.hoadons.InsertOnSubmit(hd);
                db.SubmitChanges();
                DataTable dt = new DataTable();
                Gio gh = new Gio();
                gh = (Gio)Session["gh"];
                dt = gh.dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ChiTietHoaDon cthd = new ChiTietHoaDon();
                    long macthd;
                    if (db.ChiTietHoaDons.Count() == 0)
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
                    //    String cstext = "alert('Đặt mua thành công!');";
                    //    cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                    //}
                    

                }

                Response.Write("<script>alert(\"Đăng kí thành công!\")</script>");
                Response.Write("<script>window.location='xoagiohang.aspx';</script>");
            }
            else
            {
                string sdn = (string)Session["dn"];
                DangNhap dn = db.DangNhaps.Single(p => p.TenDangNhap == sdn);
                KhachHang kh = db.KhachHangs.Single(p => p.TenDangNhap == sdn);
                dn.MatKhau = Encoding.MaHoa(Encoding.key, tbMK.Text);
                db.SubmitChanges();
                kh.hoten = tbHoten.Text;
                kh.diachi = tbDiachi.Text;
                kh.SoDT = tbSdt.Text;
                kh.email = tbEmail.Text;
                db.SubmitChanges();
               
                Response.Write("<script>alert(\"Thay đổi thông tin thành công!\");window.location ='default.aspx';</script>");
                //Response.Redirect("~/default.aspx");
            }
        }


    }
}