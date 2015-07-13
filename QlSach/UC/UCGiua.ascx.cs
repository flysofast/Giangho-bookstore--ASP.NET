using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach.UC
{
    public partial class UCGiua : System.Web.UI.UserControl
    {
        public string ShortenedString(string s, int n)
        {
            string st = s;
            if (s.Length > n)
                st = s.Substring(0, n).TrimEnd() + "...";
            return st;
        }

        public string ShortenedString(string s, int n,string ext)
        {
            string st = s;
            if (s.Length > n)
                st = s.Substring(0, n).TrimEnd() + ext;
            return st;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                QlSachDbDataContext db = new QlSachDbDataContext();
                string tk = Request.QueryString["tk"];
                string ml = Request.QueryString["ml"];
                string tam = Request.QueryString["trang"];
                int trang;
                if (tam == null || tam == "") trang = 1;
                else
                    trang = int.Parse(tam);
                IQueryable<sach> q;
                int st = 0;
                if (string.IsNullOrEmpty(tk))
                {
                    if (string.IsNullOrEmpty(ml))
                    {
                        q = from p in db.saches orderby p.NgayNhap descending select p;
                        DataList1.DataSource = q.Skip(trang * 9 - 9).Take(9);
                    }
                    else
                    {
                        q = from p in db.saches where p.maloai == ml orderby p.NgayNhap descending select p;
                        DataList1.DataSource = q.Skip(trang * 9 - 9).Take(9);
                    }

                    st = q.Count() % 9 == 0 ? q.Count() / 9 : q.Count() / 9 + 1;

                    BuildLpTrang(st, ml, tk, trang);

                    DataList1.DataBind();
                }
                else
                {
                    q = from p in db.saches where p.tensach.Contains(tk) || p.tacgia.Contains(tk) orderby p.NgayNhap descending select p;
                    DataList1.DataSource = q.Skip(trang * 9 - 9).Take(9);


                    st = q.Count() % 9 == 0 ? q.Count() / 9 : q.Count() / 9 + 1;
                    //for (int i = 1; i <= st; i++)
                    //{
                    //    LpTrang.Text = LpTrang.Text + "<a href='Default.aspx?trang=" + i.ToString() + "&tk="
                    //        + tk + "'>" + i.ToString() + " | " + "</a>";
                    //}

                    BuildLpTrang(st, ml, tk, trang);
                    DataList1.DataBind();
                }
            }
        }

        void BuildLpTrang(int st, string ml, string tk, int trang)
        {
            if (st == 0)
            {
                LpTrang.Text = "<span style='font-style:italic'>Không có kết quả nào cho từ khóa \"" + tk + "\"<span>";
                return;
            }

            string normalStyle = "class=\"hyperlinkButton\" style=\"padding-left:5px;padding-right:5px;\"";
            string currentPageStyle = "class=\"hyperlinkButton\" style=\"padding-left:5px;padding-right:5px;background-color:red\"";
            string rightStyle = normalStyle;
            if (trang == 1) rightStyle = currentPageStyle;

            int from = trang - 4;
            int to = trang + 4;

            if (from > 2)
                LpTrang.Text = "<span class=\"short-left-moving-animation\" style=\"font-weight:bold;color:#333e40;\"><a " + rightStyle + "  href='Default.aspx?trang=" + 1 + "&tk="
                          + tk + "&ml=" + ml + "'>" + 1 + "</a> ◀ </span>";
            else
                LpTrang.Text = "<a " + rightStyle + "  href='Default.aspx?trang=" + 1 + "&tk="
                          + tk + "&ml=" + ml + "'>" + 1 + "</a>  ";

            for (int i = from; i <= to; i++)
            {
                if (i > 1 && i < st)
                    if (i == trang) LpTrang.Text = LpTrang.Text + "<a " + currentPageStyle + " href='Default.aspx?trang=" + i.ToString() + "&tk="
                           + tk + "&ml=" + ml + "'>" + i.ToString() + "</a>  ";
                    else
                        LpTrang.Text = LpTrang.Text + "<a " + normalStyle + " href='Default.aspx?trang=" + i.ToString() + "&tk="
                            + tk + "&ml=" + ml + "'>" + i.ToString() + "</a>  ";
            }

            if (trang == st) rightStyle = currentPageStyle;
            else rightStyle = normalStyle;

            if (to < st - 1)
                LpTrang.Text += "<span class=\"short-right-moving-animation\" style=\"font-weight:bold;color:#333e40;\"> ▶ <a " + rightStyle + "  href='Default.aspx?trang=" + st + "&tk="
                        + tk + "&ml=" + ml + "'>" + st + "</a></span>";
            else
                if (st > 1)
                    LpTrang.Text = LpTrang.Text + "<a " + rightStyle + "  href='Default.aspx?trang=" + st + "&tk="
                                + tk + "&ml=" + ml + "'>" + st + "</a>";

        }

        public string GetLoaiSach(string ml)
        {
            QlSachDbDataContext db = new QlSachDbDataContext();
            return db.loais.Single(p => p.maloai == ml).tenloai;
        }

        public string GetTinhTrang(string ms)
        {
            QlSachDbDataContext db = new QlSachDbDataContext();
            long sl = db.saches.Single(p => p.masach == ms).soluong ?? 0;
            if (sl <= 0)
            {
                return "<span class=&quot;hethang&quot;>Hết hàng</span>";
            }
            else
                return "<span class=&quot;conhang&quot;>Còn hàng</span>";

        }
    }
}