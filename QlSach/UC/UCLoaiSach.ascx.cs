using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach.UC
{
    
    public partial class UCLoaiSach : System.Web.UI.UserControl
    {
        string mainpage = "default.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            //QlSachDbDataContext db = new QlSachDbDataContext();
            //string s = Session["dn"].ToString();
            //var p = db.DangNhaps.Where(q => q.TenDangNhap == s).Select(q => new { q.Quyen });
            //if (p.Count() != 0 && p.First().Quyen)
            //    path = "~/admin.aspx";
            //else
            //    path = "~/default.aspx";

            //if (!IsPostBack)
            //{

            //    loai all = new loai();
            //    all.maloai = "";
            //    all.tenloai = "Tất cả các loại sách";
            //    var loaisach = db.loais.ToList();
            //    loaisach.Insert(0, all);

            //    GridView1.DataSource = loaisach;
            //    GridView1.DataBind();
            //}
            QlSachDbDataContext db = new QlSachDbDataContext();
            if(db.DangNhaps.Any(p=>p.TenDangNhap==Session["dn"].ToString()&&p.Quyen))
                mainpage="admin.aspx";

        }

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType != DataControlRowType.Header)
        //    {
        //        if (e.Row.Cells.Count != 0 && e.Row.Cells[0].Controls.Count != 0)
        //        {
        //            HyperLink myLink = (HyperLink)e.Row.Cells[0].Controls[0];

        //            //myLink.NavigateUrl = myLink.NavigateUrl.Insert(0, HttpContext.Current.Request.Url.AbsolutePath);
        //            myLink.NavigateUrl = myLink.NavigateUrl.Insert(0, path);
        //        }
        //    }
        //}

        public void BuildMenu()
        {
            QlSachDbDataContext db = new QlSachDbDataContext();
            Response.Write("<li class=\"dm\"><a href=\""+mainpage+ "\">"+"Tất cả các loại sách</a></li>");
            foreach (var dm in db.danhmucs)
            {

                Response.Write("<li class=\"dm\">"+dm.tendanhmuc+"<ul class=\"ls\">");
                
                
                //Response.Write("<div class=\"accordionButton\">" + dm.tendanhmuc + "</div>");
                //Response.Write("<div class=\"accordionContent\">");
                foreach (var loai in db.loais.Where(p => p.madanhmuc == dm.madanhmuc))
                {
                    //Response.Write("<a href=\"default.aspx?ml=" + loai.maloai + "\">" + loai.tenloai + "</a><br />");
                    Response.Write("<li><a href=\""+mainpage+"?ml=" + loai.maloai + "\">" + loai.tenloai + "</a></li>");
                }
                Response.Write("</ul></li>");

            }
        }
    }
}