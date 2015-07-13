using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class QLLoai1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QlSachDbDataContext db = new QlSachDbDataContext();
            try
            {

                var w = db.DangNhaps.Where(p => p.TenDangNhap == (Session["dn"]).ToString()).First();
                if (!w.Quyen) Response.Redirect("Default.aspx");
            }
            catch
            {
                Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {
                var q = db.loais;

                DropDownList1.DataSource = q.Select(p => p.tenloai);
                DropDownList1.DataBind();
                drdDanhmuc.DataSource = db.danhmucs;
                drdDanhmuc.DataBind();
                drdDanhmuc.SelectedValue = q.First().madanhmuc;
                tbMaloai.Text = q.First().maloai;
                tbTenloai.Text = q.First().tenloai;
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            QlSachDbDataContext db = new QlSachDbDataContext();
            var q = db.loais.Skip(DropDownList1.SelectedIndex).Take(1).First();
            tbMaloai.Text = q.maloai;
            tbTenloai.Text = q.tenloai;
            drdDanhmuc.SelectedValue = q.madanhmuc;
            btSua.Enabled = true;
            btXoa.Enabled = true;
        }

        protected void btSua_Click(object sender, EventArgs e)
        {

            QlSachDbDataContext db = new QlSachDbDataContext();
            loai q = db.loais.Single(p => p.tenloai == DropDownList1.SelectedValue.ToString());
            if (!db.loais.Any(p => p.tenloai != q.tenloai && p.tenloai == tbTenloai.Text))
            {
                q.tenloai = tbTenloai.Text;
                q.madanhmuc = drdDanhmuc.SelectedValue;
                db.SubmitChanges();
                //System.Windows.Forms.MessageBox.Show("Sửa thành công!");
                Response.Write("<script>alert('Sửa thành công!')</script>");
                var a = db.loais.Select(p => new { p.tenloai, p.maloai });

                DropDownList1.DataSource = a.Select(p => p.tenloai);
                DropDownList1.DataBind();
                DropDownList1.SelectedValue = tbTenloai.Text;
                //Response.Redirect(Request.RawUrl);
            }
            else
                lbTen.Visible = true;

        }

        protected void btThem_Click(object sender, EventArgs e)
        {
            lbTen.Visible = false;
            lbMa.Visible = false;
            QlSachDbDataContext db = new QlSachDbDataContext();
            if (btThem.Text == "Thêm mới...")
            {
                tbMaloai.Enabled = true;
                tbMaloai.Text = "";
                tbTenloai.Text = "";
                DropDownList1.Visible = false;
                Label1.Visible = false;
                btSua.Enabled = false;
                btXoa.Enabled = false;
                btThem.Text = "Thêm";
            }
            else
            {
                bool kt = true;
                if (db.loais.Any(p => p.tenloai == tbTenloai.Text))
                {
                    lbTen.Visible = true;
                    kt = false;
                }
                if (db.loais.Any(p => p.maloai == tbMaloai.Text))
                {
                    lbMa.Visible = true;
                    kt = false;
                }
                if (kt == true)
                {
                    loai l = new loai();
                    l.tenloai = tbTenloai.Text;
                    l.maloai = tbMaloai.Text;
                    l.madanhmuc = drdDanhmuc.SelectedValue;
                    db.loais.InsertOnSubmit(l);
                    db.SubmitChanges();
                    //System.Windows.Forms.MessageBox.Show("Thêm loại mới thành công!");
                    Response.Write("<script>alert('Thêm loại mới thành công!')</script>");
                    //Response.Redirect(Request.RawUrl);

                    lbTen.Visible = false;
                    lbMa.Visible = false;
                    tbMaloai.Enabled = false;

                    DropDownList1.Visible = true;
                    Label1.Visible = true;
                    btSua.Enabled = true;
                    btXoa.Enabled = true;
                    btThem.Text = "Thêm mới...";
                    var a = db.loais.Select(p => new { p.tenloai, p.maloai });

                    DropDownList1.DataSource = a.Select(p => p.tenloai);
                    DropDownList1.DataBind();
                    DropDownList1.SelectedValue = tbTenloai.Text;

                }

            }

        }

        protected void btXoa_Click(object sender, EventArgs e)
        {
            QlSachDbDataContext db = new QlSachDbDataContext();

            loai q = db.loais.Single(p => p.tenloai == DropDownList1.SelectedValue.ToString());
            if (!db.saches.Any(p => p.maloai == q.maloai))
            {
                db.loais.DeleteOnSubmit(q);
                db.SubmitChanges();
                Response.Write("<script>alert('Xóa thành công!')</script>");
                //Response.Redirect(Request.RawUrl);
                var a = db.loais.Select(p => new { p.tenloai, p.maloai });

                DropDownList1.DataSource = a.Select(p => p.tenloai);
                DropDownList1.DataBind();
                tbMaloai.Text = a.First().maloai;
                tbTenloai.Text = a.First().tenloai;
            }
            else
            {
                //Type cstype = this.GetType();

                //// Get a ClientScriptManager reference from the Page class.
                //ClientScriptManager cs = Page.ClientScript;

                //// Check to see if the startup script is already registered.
                //if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                //{
                //    String cstext = "alert('Danh mục này vẫn chưa trống, hãy xóa các sách trong danh mục này trước!');";
                //    cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                //}

                Response.Write("<script>alert('Danh mục này vẫn chưa trống, hãy xóa các sách trong danh mục này trước!')</script>");

                //Response.Redirect("Admin.aspx");
            }
        }

    }
}