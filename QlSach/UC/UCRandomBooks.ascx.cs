using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach.UC
{
    public partial class UCRandomBooks : System.Web.UI.UserControl
    {
        public string ShortenedString(string s, int n)
        {
            string st = s;
            if (s.Length > n)
                st = s.Substring(0, n).TrimEnd() + "...";
            return st;
        }

        public string ShortenedString(string s, int n, string ext)
        {
            string st = s;
            if (s.Length > n)
                st = s.Substring(0, n).TrimEnd() + ext;
            return st;
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            GetRandomBooks(4);
        }

       

        public void GetRandomBooks(int n)
        {
            DataList1.DataSource = GetRandomBooksFromData(4);
            DataList1.DataBind();
        }
        Random r = new Random();
        List<sach> GetRandomBooksFromData(int n)
        {
            var list=new List<sach>();
            QlSachDbDataContext db = new QlSachDbDataContext();
            
            for (int i = 0; i < n; i++)
            {
                var k = db.saches.Skip(r.Next(db.saches.Count())).First();
                list.Add(k);
            }
            return list;
        }
       
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            GetRandomBooks(4);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            GetRandomBooks(4);
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