using System;
using System.Linq;
using System.Web.UI;


namespace QlSach.UC
{
    public partial class UCLogin : System.Web.UI.UserControl
    {
        int lc = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lc = (int)Session["lc"];
            if (lc >= 3)
            {
                pnlCaptcha.Visible = true;
            }
            else pnlCaptcha.Visible = false;

            if (!IsPostBack)
            {
                if ((string)Session["dn"] != "")
                {
                    var db = new QlSachDbDataContext();
                    var q = db.DangNhaps.First(p => p.TenDangNhap == (string)Session["dn"]);
                    tbPass.Visible = false;
                    tbUser.Visible = false;
                    lbID.Visible = false;
                    lbPass.Visible = false;
                    btLogin.Visible = false;
                    btRegister.Visible = false;
                    btSignOut.Visible = true;
                    if (q.Quyen)
                    {
                        hlThongTin.Text = "<span id=\"hl\">Trang Admin</span>";
                        hlThongTin.NavigateUrl = "~/Admin.aspx";
                    }

                    //var page = Page.Master as AdminMasterPage;
                    //if (page != null)
                    //    page.ChangeLoginTitle(q.hoten);
                    //else
                    //{
                    //    var page2 = Page.Master as CustomerMasterPage;
                    //    if (page2 != null)
                    //        page2.ChangeLoginTitle(q.hoten);

                    //}

                    var page = Page.Master;
                    //The is operator does not check if the runtime type of the operand is exactly the given type; rather, it checks to see if the runtime type is compatible with the given type:

                    //class Animal {}
                    //class Tiger : Animal {}
                    //...
                    //object x = new Tiger();
                    //bool b1 = x is Tiger; // true
                    //bool b2 = x is Animal; // true also! Every tiger is an animal.
                    //But checking for type identity with reflection checks for identity, not for compatibility

                    //bool b3 = x.GetType() == typeof(Tiger); // true
                    //bool b4 = x.GetType() == typeof(Animal); // false! even though x is an animal
                    //If that's not what you want, then you probably want IsAssignableFrom:

                    //bool b5 = typeof(Tiger).IsAssignableFrom(x.GetType()); // true
                    //bool b6 = typeof(Animal).IsAssignableFrom(x.GetType()); // true! A variable of type Animal may be assigned a Tiger.
                    //http://stackoverflow.com/questions/10415276/how-to-check-if-variable-is-of-type-of-a-type-thats-stored-within-a-variable

                    if (page is CustomerMasterPage)
                    {
                        var currentPage = page as CustomerMasterPage;
                        currentPage.ChangeLoginTitle(q.hoten);
                    }
                    if (page is AdminMasterPage)
                    {
                        var currentPage = page as AdminMasterPage;
                        currentPage.ChangeLoginTitle(q.hoten);
                    }
                    if (page is AdminMasterPage2)
                    {
                        var currentPage = page as AdminMasterPage2;
                        currentPage.ChangeLoginTitle(q.hoten);
                    }

                    hlThongTin.Visible = true;


                }
                else
                {
                    tbPass.Visible = true;
                    tbUser.Visible = true;
                    lbID.Visible = true;
                    lbPass.Visible = true;
                    btLogin.Visible = true;
                    btRegister.Visible = true;
                    btSignOut.Visible = false;
                    hlThongTin.Visible = false;
                }
            }
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {

            if (pnlCaptcha.Visible == true && tbCaptcha.Text != QlSach.Class.CaptchaVal.randomStr) return;

            if (tbUser.Text == null || tbPass.Text == null)
            {
                Label1.Text = "Thông tin đăng nhập chưa đầy đủ!";
            }
            else
            {
                QlSachDbDataContext db = new QlSachDbDataContext();
                var p = db.DangNhaps.Where(q => q.TenDangNhap == tbUser.Text && q.MatKhau == Encoding.MaHoa(Encoding.key, tbPass.Text)).Select(q => new { q.TenDangNhap, q.MatKhau, q.Quyen });
                if (p.Count() != 0)
                {
                    Session["lc"] = 0;
                    string s = p.First().TenDangNhap;
                    Label1.Text = s;
                    Session["dn"] = s;
                    if (!p.First().Quyen)
                        Response.Redirect("default.aspx");
                    else
                        Response.Redirect("admin.aspx");

                }
                else
                {
                    Label1.Text = "Thông tin đăng nhập chưa chính xác!";
                    Session["lc"] = lc + 1;
                    if (lc+1 >= 3)
                        pnlCaptcha.Visible = true;
                }

            }
        }

        protected void btSignOut_Click(object sender, EventArgs e)
        {
            Session["dn"] = "";
            Session["gh"] = null;
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void btRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/thongtinkhachhang.aspx");
        }



    }
}