using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class KhachhangAdmin : System.Web.UI.Page
    {
        static bool purchased = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QlSachDbDataContext db = new QlSachDbDataContext();
                //Xóa khách hàng đặt hàng quá 15 ngày
                //Chú ý: khi xóa khách hàng sẽ xóa các hóa đơn thanh toán
                // và các chi tiết hóa đơn của khách hàng
                db.XoaKh(); //Gọi lại thủ tục xóa
                BindData();
            }
        }
        void UpdateHlStatus()
        {
            hlDaThanhToan.Font.Bold = hlChuaThanhToan.Font.Italic = purchased;
            hlDaThanhToan.Font.Italic = hlChuaThanhToan.Font.Bold = !purchased;
        }
        void BindData()
        {
            UpdateHlStatus();

            //Lấy về makh, Socthd, Tensach, Soluongmua, gia, Hoten, diachi,std và ngaymua
            // của tất cả các khách hàng theo thứ tự giảm dần của ngày mua
            //Nối 4 bảng KhacHang, HoaDon, ChiTietHoaDon và sach để lấy dữ liệu
            QlSachDbDataContext db = new QlSachDbDataContext();
            var q = from kh in db.KhachHangs
                    join hd in db.hoadons on kh.Makh equals hd.makh
                    join cthd in db.ChiTietHoaDons on hd.MaHoaDon equals cthd.MaHoaDon
                    join s in db.saches on cthd.MaSach equals s.masach
                    orderby hd.NgayMua descending
                    where (hd.damua == purchased)
                    select new
                    {
                        Tensach = s.tensach,
                        hd.MaHoaDon,
                        makh = kh.Makh,
                        socthd = cthd.MaChiTietHD,
                        s.masach,
                        Soluongmua = cthd.SoLuongMua,
                        gia = s.gia,
                        HoTen = kh.hoten,
                        diachi = kh.diachi,
                        SDT = kh.SoDT,
                        ngaymua = hd.NgayMua.ToShortDateString(),

                    };

            GridView1.DataSource = q;
            GridView1.DataBind();
            lbNull.Visible = q.Count() == 0 ? true : false;
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Lấy về chỉ số dòng của khách vừa chọn
            int d = e.RowIndex;
            //Lấy về mã khách hàng có chỉ số là d trên GridView1
            // long mkh = int.Parse(GridView1.Rows[d].Cells[1].Text);

            QlSachDbDataContext db = new QlSachDbDataContext();
            var a = GridView1.Rows.Count;
            ChiTietHoaDon cthd = db.ChiTietHoaDons.Single(p => p.MaChiTietHD == int.Parse(GridView1.Rows[d].Cells[9].Text));
            long mahd = cthd.MaHoaDon;
            db.ChiTietHoaDons.DeleteOnSubmit(cthd);
            db.SubmitChanges();
            if (!db.ChiTietHoaDons.Any(p => p.MaHoaDon == mahd))
            {
                hoadon hd = db.hoadons.Single(p => p.MaHoaDon == mahd);
                db.hoadons.DeleteOnSubmit(hd);
                db.SubmitChanges();
            }
            ////Lọc ra khách hàng có mà là mkh
            //if(!db.hoadons.Any(p=>p.makh==mkh))
            //{
            //    KhachHang kh = db.KhachHangs.Single(p => p.Makh == mkh);
            //    db.KhachHangs.DeleteOnSubmit(kh);//Xóa khách hàng
            //    db.SubmitChanges();
            //}

            BindData();


        }

        protected void btTK_Click(object sender, EventArgs e)
        {
            QlSachDbDataContext db = new QlSachDbDataContext();
            var q = from kh in db.KhachHangs
                    join hd in db.hoadons on kh.Makh equals hd.makh
                    join cthd in db.ChiTietHoaDons on hd.MaHoaDon equals cthd.MaHoaDon
                    join s in db.saches on cthd.MaSach equals s.masach
                    orderby hd.NgayMua descending
                    where (kh.hoten.Contains(tbHoten.Text))
                    select new
                    {
                        Tensach = s.tensach,
                        hd.MaHoaDon,
                        makh = kh.Makh,
                        socthd = cthd.MaChiTietHD,
                        s.masach,
                        Soluongmua = cthd.SoLuongMua,
                        gia = s.gia,
                        HoTen = kh.hoten,
                        diachi = kh.diachi,
                        SDT = kh.SoDT,
                        ngaymua = hd.NgayMua.ToShortDateString(),

                    };
            //nạp dữ liệu vào GridView1
            try
            {
                GridView1.Columns.Remove(GridView1.Columns[10]);
            }
            catch { }
            GridView1.DataSource = q;
            GridView1.DataBind();
            lbNull.Visible = q.Count() == 0 ? true : false;
        }

        protected void hlChuaThanhToan_Click(object sender, EventArgs e)
        {
            purchased = false;
            BindData();
        }

        protected void hlDaThanhToan_Click(object sender, EventArgs e)
        {
            purchased = true;
            BindData();
        }
    }
}