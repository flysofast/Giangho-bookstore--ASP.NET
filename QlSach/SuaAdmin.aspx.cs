using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class SuaAdmin : System.Web.UI.Page
    {
        private QlSachDbDataContext db;
        private sach s;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                //Lấy mã sách cần sửa
                string ms = Request.QueryString["ms"];
                db = new QlSachDbDataContext();
                //Lọc ra sách có mã cần sửa
                s = db.saches.Single(p => p.masach == ms);
                //Lấy đường dẫn file ảnh cần sửa
                string dd = Server.MapPath(s.anh);
                txtms.Text = s.masach;
                txtts.Text = s.tensach;
                txttg.Text = s.tacgia;
                txtgia.Text = s.gia.ToString();
                txtsl.Text = s.soluong.ToString();
                CNgayNhap.SelectedDate = s.NgayNhap != null ? DateTime.Parse(s.NgayNhap.Value.ToShortDateString()) : DateTime.Today;
                CNgayNhap.DataBind();
                DMaloai.DataSource = db.loais;
                DMaloai.DataValueField = "maloai";
                DMaloai.DataBind();
                DMaloai.Text = s.maloai;
                Image1.ImageUrl = s.anh;
            }
        }

        protected void btLuu_Click(object sender, EventArgs e)
        {
            string ms = Request.QueryString["ms"];
            db = new QlSachDbDataContext();
            //Lọc ra sách có mã cần sửa
            s = db.saches.Single(p => p.masach == ms);
            s.masach = txtms.Text;
            s.tensach = txtts.Text;
            s.tacgia = txttg.Text;
            s.gia = int.Parse(txtgia.Text);
            s.soluong = int.Parse(txtsl.Text);
            s.maloai = DMaloai.Text;
            if (FileUpload1.FileName != "")
            {//UpLoad file ảnh lên server
                FileUpload1.SaveAs(Server.MapPath(@"Image_sach/" +FileUpload1.FileName));
               System.IO.File.Delete(Server.MapPath(s.anh));
                s.anh = @"Image_sach/" + FileUpload1.FileName;
                Image1.ImageUrl = s.anh;
            }
            db.SubmitChanges();
            Response.Redirect("Admin.aspx");
        }
    }
}