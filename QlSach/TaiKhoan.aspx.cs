using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class TaiKhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QlSachDbDataContext db = new QlSachDbDataContext();
                //var q = db.DangNhaps.Select(p => new { p.TenDangNhap, p.MatKhau, p.hoten, p.Quyen });

                drdID.DataSource = db.DangNhaps.Select(p => p.TenDangNhap);
                drdID.DataBind();

            }
        }

        protected void drdID_SelectedIndexChanged(object sender, EventArgs e)
        {
            QlSachDbDataContext db = new QlSachDbDataContext();
            var q = db.DangNhaps.Where(p => p.TenDangNhap == drdID.SelectedValue.ToString());
            tbHoten.Text = q.First().hoten.Trim();
            tbID.Text = q.First().TenDangNhap;
            tbPass.Text = "";
            rdAdmin.Checked = q.First().Quyen;
            rdNormal.Checked = !rdAdmin.Checked;
        }

        protected void btSua_Click(object sender, EventArgs e)
        {
            if(!ThongTinDayDu())
            {
                Response.Write("<script>alert('Vui lòng điển đầy đủ thông tin!'); </script>");
                return;
            }

            QlSachDbDataContext db = new QlSachDbDataContext();
            DangNhap q = db.DangNhaps.Single(p => p.TenDangNhap == drdID.SelectedValue.ToString());
            q.MatKhau = Encoding.MaHoa(Encoding.key,tbPass.Text);
            q.Quyen = rdAdmin.Checked;
            q.hoten = tbHoten.Text;
            db.SubmitChanges();
            //System.Windows.Forms.MessageBox.Show("Sửa thành công!");
            Response.Write("<script>alert('Sửa thành công!');</script>");
            drdID.DataSource = db.DangNhaps.Select(p => p.TenDangNhap);
            drdID.DataBind();
            drdID.SelectedValue = q.TenDangNhap;
        }

        protected void btXoa_Click(object sender, EventArgs e)
        {

            if (!ThongTinDayDu())
            {
                Response.Write("<script>alert('Vui lòng điển đầy đủ thông tin!');</script>");
                return;
            }
            else { 

            QlSachDbDataContext db = new QlSachDbDataContext();

            DangNhap dn = db.DangNhaps.Single(p => p.TenDangNhap == drdID.SelectedValue.ToString());
            if (dn.TenDangNhap != (string)Session["dn"])
            {
                db.DangNhaps.DeleteOnSubmit(dn);
                db.SubmitChanges();
                //System.Windows.Forms.MessageBox.Show("Xóa thành công!");
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                //HttpContext.Current.Response.Write(
                //"<SCRIPT LANGUAGE=''JavaScript''>alert('Không thể xóa tài khoản đang sử dụng!')</SCRIPT>");


                //Type cstype = this.GetType();

                //// Get a ClientScriptManager reference from the Page class.
                //ClientScriptManager cs = Page.ClientScript;

                //// Check to see if the startup script is already registered.
                //if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                //{
                //    String cstext = "alert('Không thể xóa tài khoản đang sử dụng!');";
                //    cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                //}
                Response.Write("<script>alert(\"Không thể xóa tài khoản đang sử dụng!\")</script>");
            }
            }
        }

        protected void btThem_Click(object sender, EventArgs e)
        {
            lbID.Visible = false;
            QlSachDbDataContext db = new QlSachDbDataContext();
            if (btThem.Text == "Thêm mới...")
            {
                tbID.Enabled = true;
                tbID.Text = "";
                tbHoten.Text = "";
                tbPass.Text = "";
                btSua.Enabled = false;
                btXoa.Enabled = false;
                rdAdmin.Checked = false;
                rdNormal.Checked = !rdAdmin.Checked;
                btThem.Text = "Thêm";
            }
            else
            {
                if (!db.DangNhaps.Any(p => p.TenDangNhap == tbID.Text))
                {
                    DangNhap dn = new DangNhap();
                    dn.TenDangNhap = tbID.Text;
                    dn.MatKhau = Encoding.MaHoa(Encoding.key,tbPass.Text);
                    dn.hoten = tbHoten.Text;
                    dn.Quyen = rdAdmin.Checked;
                    db.DangNhaps.InsertOnSubmit(dn);
                    db.SubmitChanges();
                    //System.Windows.Forms.MessageBox.Show("Thêm tài khoản mới thành công!");
                    Response.Write("<script>alert('Thêm tài khoản mới thành công!')</script>");

                    Response.Redirect(Request.RawUrl);
                    
                    //btThem.Text = "Thêm";
                    //drdID.DataSource = db.DangNhaps.Select(p => p.TenDangNhap);
                    //drdID.DataBind();
                    //drdID.SelectedValue = tbID.Text;

                    //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "DoPostBack", "__doPostBack(sender, e)", true);

                }
                else
                {
                    lbID.Visible = true;
                }
            }
        }

        protected void btTim_Click(object sender, EventArgs e)
        {
                lbNone.Visible = false;
                QlSachDbDataContext db = new QlSachDbDataContext();
                var q = db.DangNhaps.Where(p => p.TenDangNhap.Contains(tbTKID.Text.Trim()) && p.hoten.Contains(tbTKHoten.Text.Trim()));
                if (q.Any())
                {
                    tbHoten.Text = q.First().hoten;
                    tbID.Text = q.First().TenDangNhap;
                    tbPass.Text = "";
                    rdAdmin.Checked = q.First().Quyen;
                    rdNormal.Checked = !rdAdmin.Checked;
                    //drdID.DataSource = q.Select(p => p.TenDangNhap);
                    //drdID.DataBind();
                }
                else
                {
                    lbNone.Visible = true;
                }
        }

        //protected void drdID_DataBound(object sender, EventArgs e)
        //{
        //    QlSachDbDataContext db = new QlSachDbDataContext();
        //    var q = db.DangNhaps.Where(p => p.TenDangNhap == drdID.SelectedValue.ToString());
        //    tbHoten.Text = q.First().hoten;
        //    tbID.Text = q.First().TenDangNhap;
        //    tbPass.Text = "";
        //    rdAdmin.Checked = q.First().Quyen;
        //    rdNormal.Checked = !rdAdmin.Checked;
        //}

        bool ThongTinDayDu()
        {
            bool kt = true;
            if (string.IsNullOrEmpty(tbHoten.Text)) kt = false;
            if (string.IsNullOrEmpty(tbID.Text)) kt = false;
            //if (string.IsNullOrEmpty(tbPass.Text)) kt = false;
            return kt;
        }
    }
}