using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach.UC
{
    public partial class UCTimKiemChung : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox t1 = txtTk;
            t1.Attributes.Add("value", "Nhập từ khóa tìm kiếm...");
            t1.Attributes.Add("onFocus", @"if(this.value == 'Nhập từ khóa tìm kiếm...') {this.value = '';}");
            t1.Attributes.Add("onBlur", @"if (this.value == '') {this.value = 'Nhập từ khóa tìm kiếm...';}");
        }

        protected void btTim_Click(object sender, EventArgs e)
        {
            QlSachDbDataContext db = new QlSachDbDataContext();

            if (Session["dn"].ToString() == "") Response.Redirect("~/Default.aspx?tk=" + txtTk.Text);
           
            var q = db.DangNhaps.Where(p => p.TenDangNhap == (Session["dn"]).ToString()).First();
            if (!q.Quyen)
                Response.Redirect("~/Default.aspx?tk=" + txtTk.Text);
            else
                Response.Redirect("~/admin.aspx?tk=" + txtTk.Text);
            
        }
    }
}