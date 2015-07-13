using System;
using System.Drawing;
using System.Linq;

namespace QlSach
{
    public partial class ThemAdmin : System.Web.UI.Page
    {
        private QlSachDbDataContext db = new QlSachDbDataContext();
        private sach s;
        string ms = "";

        protected void Page_Load(object sender, EventArgs e)
        {

           
            ms = Request.QueryString["ms"];
            if (!IsPostBack)
            {
                //Lấy mã sách cần sửa hoặc cần thêm

                if (ms != null)
                {
                    //Lọc ra sách có mã cần sửa
                    s = db.saches.Single(p => p.masach == ms);
                    //Lấy đường dẫn file ảnh cần sửa
                    //string dd = Server.MapPath(s.anh);
                    txtms.Text = s.masach;
                    txtts.Text = s.tensach;
                    txttg.Text = s.tacgia;
                    txtgia.Text = s.gia.ToString();
                    txtsl.Text = s.soluong.ToString();
                    CKEditorControl1.Text = s.tomtat;
                    CNgayNhap.SelectedDate = s.NgayNhap != null ? DateTime.Parse(s.NgayNhap.Value.ToShortDateString()) : DateTime.Today;
                    CNgayNhap.DataBind();
                    DMaloai.DataSource = db.loais;
                    //DMaloai.DataValueField = "maloai";
                    DMaloai.SelectedValue = s.maloai;
                    DMaloai.DataBind();

                    if (!string.IsNullOrEmpty(s.anh))
                        Image1.ImageUrl = s.anh;
                }
                else
                {
                    DMaloai.DataSource = db.loais;
                    //DMaloai.DataValueField = "maloai";
                    DMaloai.DataBind();
                }
            }
            CNgayNhap.SelectedDate = DateTime.Today;
        }

        protected void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
                LHienthiloi.Visible = false;
                QlSachDbDataContext db = new QlSachDbDataContext();
                if (string.IsNullOrEmpty(ms) && db.saches.Any(p => p.masach == txtms.Text))
                {
                    lbMaSachTrung.Visible = true;
                    return;
                }
                lbMaSachTrung.Visible = false;
                //Tạo ra 1 lớp sách
                sach s;
                if (string.IsNullOrEmpty(ms))
                    s = new sach();
                else s = db.saches.Single(p => p.masach == ms);

                s.masach = txtms.Text.Replace("\"", "&quot;");
                s.tensach = txtts.Text.Replace("\"", "&quot;");
                s.tacgia = txttg.Text.Replace("\"", "&quot;");
                s.gia = int.Parse(txtgia.Text);
                s.soluong = int.Parse(txtsl.Text);
                s.sotap = txtSotap.Text;
                s.maloai = DMaloai.SelectedValue;
                s.NgayNhap = CNgayNhap.SelectedDate;
                
                s.tomtat = CKEditorControl1.Text.Replace("\"","&quot;");
                if (FileUpload1.FileName != "")
                { //UpLoad ảnh lên máy chủ
                    FileUpload1.SaveAs(Server.MapPath(@"Image_sach/"
                    + FileUpload1.FileName));
                    s.anh = @"Image_sach/" + FileUpload1.FileName;
                    Image1.ImageUrl = s.anh;
                }
                
                if (string.IsNullOrEmpty(ms))
                    db.saches.InsertOnSubmit(s); //Chèn thêm 1 sách
                
                db.SubmitChanges();//Lưu sách vào csdl
                Response.Write("<script>alert('Cập nhật thành công!')</script>");
            }
            catch (Exception tt)
            {
                LHienthiloi.Text = tt.Message; //Thông báo lỗi
                LHienthiloi.Visible = true;
            }
        }
    }
}