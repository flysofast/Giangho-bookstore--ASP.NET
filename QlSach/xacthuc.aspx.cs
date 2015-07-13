using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class xacthuc : System.Web.UI.Page
    {
        string mkh = "";
        QlSachDbDataContext db = new QlSachDbDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
                mkh = drdMakh.SelectedValue;

            if (!IsPostBack)
            {
                //Lấy về mã khách hàng của khách hàng chọn ở trang KhachHangAdmin
                mkh = Request.QueryString["makh"];

                UpdateKhachHangData();
                // Chọn những khách hàng trong bảng khách hàng mà ko phải là admin
                drdMakh.DataSource = db.KhachHangs.Where(p => !db.DangNhaps.Where(q => q.Quyen).Select(q => q.TenDangNhap).Contains(p.TenDangNhap));
                drdMakh.DataBind();
                drdMakh.SelectedValue = mkh;
                drdSohd.DataSource = db.hoadons.Where(p => p.makh == long.Parse(mkh)).OrderBy(p => p.NgayMua);
                drdSohd.DataBind();

            }
            UpdateHoaDonData();

        }

        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{


        //    if (e.CommandName == "btSua")
        //    {
        //        var tb1 = new TextBox();
        //        tb1 = (TextBox)GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[6].FindControl("SLMoi");
        //        
        //        try
        //        {
        //            ChiTietHoaDon cthd = db.ChiTietHoaDons.Single(p => p.MaChiTietHD == int.Parse(GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text));

        //            cthd.SoLuongMua = int.Parse(tb1.Text);
        //            db.SubmitChanges();
        //        }
        //        catch
        //        {
        //            Response.Write("Lỗi");
        //        }
        //    }
        //}

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int d = e.RowIndex;
            //  long mkh = int.Parse(Request.QueryString["makh"]);


            ChiTietHoaDon cthd = db.ChiTietHoaDons.Single(p => p.MaChiTietHD == int.Parse(GridView1.Rows[d].Cells[0].Text));
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
            //if (!db.hoadons.Any(p => p.makh == mkh))
            //{
            //    KhachHang kh = db.KhachHangs.Single(p => p.Makh == mkh);
            //    db.KhachHangs.DeleteOnSubmit(kh);//Xóa khách hàng
            //    db.SubmitChanges();
            //}

            //Response.Redirect(Request.RawUrl);
            UpdateHoaDonData();

        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header)
            {
                TextBox tb = new TextBox();
                tb.ID = "SLMoi";
                tb.Text = "0";
                tb.Width = 40;
                e.Row.Cells[6].Controls.Add(tb);
            }
        }




        protected void drdSohd_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateHoaDonData();
        }

        void UpdateHoaDonData()
        {

            //Lấy về các sách mà khách hàng đã đặt mua
            var dsSach = from kh in db.KhachHangs
                         join hd in db.hoadons on kh.Makh equals hd.makh
                         join cthd in db.ChiTietHoaDons on hd.MaHoaDon equals cthd.MaHoaDon
                         join s in db.saches on cthd.MaSach equals s.masach
                         orderby hd.NgayMua descending
                         where kh.Makh == int.Parse(mkh) && hd.MaHoaDon == long.Parse(drdSohd.SelectedValue)
                         select new
                         {
                             s.masach,
                             cthd = cthd.MaChiTietHD,
                             makh = kh.Makh,
                             mahd = hd.MaHoaDon,
                             Tensach = s.tensach,
                             TacGia = s.tacgia,
                             ngaymua = hd.NgayMua.ToShortDateString(),
                             Soluongmua = cthd.SoLuongMua,
                             s.gia,
                             ThanhTien = cthd.SoLuongMua * s.gia,
                             ttr = hd.damua == true ? "Đã thanh toán" : "Chưa thanh toán",
                             kh.hoten
                         };
            //Nạp các sách ra GridView1
            GridView1.DataSource = dsSach;
            GridView1.DataBind();
            //Tính tổng tiền
            long tt = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
                tt = tt + long.Parse(GridView1.Rows[i].Cells[5].Text);
            lbTotal.Text = string.Format("{0:0,0}", tt) + " VNĐ";
            var q = db.hoadons.Single(p => p.MaHoaDon == long.Parse(drdSohd.SelectedValue));
            lbNgaymua.Text = q.NgayMua.ToString();

            if (q.damua == true)
            {
                CheckBox1.Text = "Đã thanh toán";
                CheckBox1.Checked = true;
                CheckBox1.ForeColor = Color.Green;
            }
            else
            {
                CheckBox1.Text = "Chưa thanh toán";
                CheckBox1.Checked = false;
                CheckBox1.ForeColor = Color.Red;
            }
        }

        //protected void btThayDoi_Click(object sender, EventArgs e)
        //{
        //    hoadon hd = db.hoadons.Single(p => p.MaHoaDon == int.Parse(drdSohd.SelectedValue));
        //    hd.damua = hd.damua == true ? false : true;
        //    db.SubmitChanges();
        //    //  Response.Redirect(Request.RawUrl);
        //    UpdateHoaDonData();
        //}


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int d = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "btSua")
            {

                TextBox tb1;
                tb1 = (TextBox)GridView1.Rows[d].Cells[6].FindControl("SLMoi");
                ChiTietHoaDon cthd = db.ChiTietHoaDons.Single(p => p.MaChiTietHD == long.Parse(GridView1.Rows[d].Cells[0].Text));
                cthd.SoLuongMua = int.Parse(tb1.Text);
                db.SubmitChanges();
            }
            //if (e.CommandName == "btXoa")
            //{
            //    //  long mkh = int.Parse(Request.QueryString["makh"]);


            //    ChiTietHoaDon cthd = db.ChiTietHoaDons.Single(p => p.MaChiTietHD == int.Parse(GridView1.Rows[d].Cells[0].Text));
            //    long mahd = cthd.MaHoaDon;
            //    db.ChiTietHoaDons.DeleteOnSubmit(cthd);
            //    db.SubmitChanges();
            //    if (!db.ChiTietHoaDons.Any(p => p.MaHoaDon == mahd))
            //    {
            //        hoadon hd = db.hoadons.Single(p => p.MaHoaDon == mahd);
            //        db.hoadons.DeleteOnSubmit(hd);
            //        db.SubmitChanges();
            //    }
            //}
            // Response.Redirect(Request.RawUrl);
            UpdateHoaDonData();
        }

        void UpdateKhachHangData()
        {

            var q = db.KhachHangs.Single(p => p.Makh.ToString() == mkh);
            Lhoten.Text = q.hoten;
            Ldiachi.Text = q.diachi;
            Lemail.Text = q.email;
            LSDT.Text = q.SoDT;
            lbTenDN.Text = q.TenDangNhap;
        }
        protected void drdMakh_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mkh = drdMakh.SelectedValue;

            UpdateKhachHangData();

            drdSohd.DataSource = db.hoadons.Where(p => p.makh == long.Parse(mkh)).OrderBy(p => p.NgayMua);
            drdSohd.DataBind();
            UpdateHoaDonData();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            hoadon hd = db.hoadons.Single(p => p.MaHoaDon == int.Parse(drdSohd.SelectedValue));
            hd.damua = hd.damua == true ? false : true;
            db.SubmitChanges();
            //Response.Redirect(Request.RawUrl);
            UpdateHoaDonData();
        }
    }
}