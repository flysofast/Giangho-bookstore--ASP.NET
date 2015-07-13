using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class XoaMatHangTrongGio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ms = Request.QueryString["ms"];
            Gio gh = new Gio();
            gh = (Gio)Session["gh"];

            for (int i = 0; i < gh.dt.Rows.Count; i++)
            {
                DataRow dr = gh.dt.Rows[i];
                if (dr["MaSach"].Equals(ms.Trim()))
                {
                    gh.dt.Rows.Remove(dr);
                    gh.dt.AcceptChanges();
                    break;
                }
            }
            Response.Redirect("HienThiGioHang.aspx");

        }
    }
}