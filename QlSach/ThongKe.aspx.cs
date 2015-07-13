using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        QlSachDbDataContext db = new QlSachDbDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            BindFieldData();
        }

        void BindThang()
        {

            for (int i = 12; i >= 1; i--)
            {
                ListItem li = new ListItem(i.ToString(), i.ToString());
                drdThang.Items.Insert(0, li);

            }

            drdThang.Items.Insert(0, new ListItem("-- Tất cả --", "tatca"));
        }

        void BindNgay()
        {
            drdNgay.Items.Clear();

            if (drdThang.SelectedValue == "tatca" || drdNam.SelectedValue == "tatca")
            {

                drdNgay.Items.Insert(0, new ListItem("-- Tất cả --", "tatca"));
                drdNgay.Enabled = false;
                return;
            }
            else
                drdNgay.Enabled = true;

            for (int i = DateTime.DaysInMonth(int.Parse(drdNam.SelectedValue), int.Parse(drdThang.SelectedValue)); i >= 1; i--)
            {
                ListItem li = new ListItem(i.ToString(), i.ToString());
                drdNgay.Items.Insert(0, li);

            }
            drdNgay.Items.Insert(0, new ListItem("-- Tất cả --", "tatca"));

        }

        void BindListboxLoaiData()
        {
            var hds = db.hoadons.Where(p => p.damua == true);

            if (drdNam.SelectedValue != "tatca")
                hds = hds.Where(p => p.NgayMua.Year == int.Parse(drdNam.SelectedValue));

            if (drdThang.SelectedValue != "tatca")
                hds = hds.Where(p => p.NgayMua.Month == int.Parse(drdThang.SelectedValue));

            if (drdNgay.SelectedValue != "tatca")
                hds = hds.Where(p => p.NgayMua.Day == int.Parse(drdNgay.SelectedValue));

            //var cthds = db.ChiTietHoaDons.Where(p => hds.Select(q => q.MaHoaDon).Distinct().Contains(p.MaHoaDon)).Select(p => p.MaSach);
            //var maloais = db.saches.Where(p => cthds.Contains(p.masach)).Select(p => p.maloai).Distinct();

            //var e = db.loais.Where(p => maloais.Contains(p.maloai));
            //return e;

            var dsLoai = from hd in hds
                         join cthd in db.ChiTietHoaDons on hd.MaHoaDon equals cthd.MaHoaDon
                         join s in db.saches on cthd.MaSach equals s.masach
                         join l in db.loais on s.maloai equals l.maloai
                         //where kh.Makh == int.Parse(mkh) && hd.MaHoaDon == long.Parse(drdSohd.SelectedValue)
                         select new
                         {
                             l.maloai,
                             l.tenloai
                             //thanhtien=s.gia*cthd.SoLuongMua,
                         };

            lsbLoaiSach.DataSource = dsLoai.Distinct();
            lsbLoaiSach.DataBind();
            lsbLoaiSach.Items.Insert(0, new ListItem("-- Tất cả -- ", "tatca"));
            lsbLoaiSach.Rows = db.loais.Count() + 1;
            lsbLoaiSach.SelectedValue = "tatca";

        }
        private void BindFieldData()
        {
            if (!IsPostBack)
            {
                drdNam.DataSource = db.hoadons.Where(p => p.damua).Select(p => (p.NgayMua).Year).Distinct();
                drdNam.DataBind();
                drdNam.Items.Insert(0, new ListItem("-- Tất cả --", "tatca"));

                BindThang();
                BindNgay();
                BindListboxLoaiData();
               
            }

            // Các chi tiết hóa đơn của loại sách được chọn
            IQueryable<ChiTietHoaDon> cthds=db.ChiTietHoaDons;
            if(lsbLoaiSach.SelectedValue!="tatca")
             cthds = db.ChiTietHoaDons.Where(p => db.saches.Single(q => q.masach == p.MaSach).maloai == lsbLoaiSach.SelectedValue);

            //Các hóa đơn của loại sách được chọn đã thanh toán
            var hds = db.hoadons.Where(p => cthds.Select(q => q.MaHoaDon).Contains(p.MaHoaDon) && p.damua == true);

            var dsSach = from hd in hds
                         join cthd in cthds on hd.MaHoaDon equals cthd.MaHoaDon
                         join s in db.saches on cthd.MaSach equals s.masach
                         orderby s.tensach descending
                         //where kh.Makh == int.Parse(mkh) && hd.MaHoaDon == long.Parse(drdSohd.SelectedValue)
                         select new
                         {
                             s.masach,
                             s.tensach,
                             s.gia,
                             cthd.SoLuongMua,
                             hd.NgayMua,
                             //thanhtien=s.gia*cthd.SoLuongMua,
                         };
            if (drdNam.SelectedValue != "tatca")
                dsSach = dsSach.Where(p => p.NgayMua.Year == int.Parse(drdNam.SelectedValue));

            if (drdThang.SelectedValue != "tatca")
                dsSach = dsSach.Where(p => p.NgayMua.Month == int.Parse(drdThang.SelectedValue));

            if (drdNgay.SelectedValue != "tatca")
                dsSach = dsSach.Where(p => p.NgayMua.Day == int.Parse(drdNgay.SelectedValue));

            var data=dsSach.GroupBy(i => new { i.masach, i.tensach, i.gia })
                .Select(group => new
                {
                    group.Key.masach,
                    group.Key.tensach,
                    group.Key.gia,
                    soluongmua = group.Sum(p => p.SoLuongMua),
                    thanhtien = group.Sum(p => p.SoLuongMua) * group.Key.gia
                });

            grvSach.DataSource = data;
            grvSach.DataBind();
           
            if (data.Count() != 0)
                lbNone.Visible = false;
            else
                lbNone.Visible=true;

            long tt = 0;
            long bookcount = 0;
            for (int i = 0; i < grvSach.Rows.Count; i++)
            {
                tt = tt + long.Parse(grvSach.Rows[i].Cells[4].Text.Substring(0, grvSach.Rows[i].Cells[4].Text.Length - 4));
                bookcount += long.Parse(grvSach.Rows[i].Cells[2].Text);
            }
            lbTotal.Text = string.Format("{0:0,0}", tt) + " VNĐ";
            lbTotalCount.Text = string.Format("{0:0,0}", bookcount) + " cuốn"; 
        }

        protected void drdThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindNgay();
            BindListboxLoaiData();
        }

        protected void drdNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindNgay();
            BindListboxLoaiData();
        }

        protected void drdNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindListboxLoaiData();
        }



    }
}