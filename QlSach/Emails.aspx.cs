using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QlSach
{
    public partial class LacVietEmails : System.Web.UI.Page
    {
        
        QlSachDbDataContext db = new QlSachDbDataContext();
        string appdownloadlink = "", appthreadlink = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            switch (DropDownList1.SelectedItem.Text)
            {
                case "Lạc Việt 2.1":
                    appdownloadlink = "http://www.windowsphone.com/s?appid=d6bd5f6a-5373-434b-be6f-b56d0096c33f";
                    appthreadlink = "\nThông tin thêm tại: http://www.winphoneviet.com/forum/index.php?threads/57311/#post-889880";
                    break;
                case "Fantastic Farm":
                    appdownloadlink = "http://www.windowsphone.com/s?appid=493d46ec-4b45-4617-89ba-ca7a63882218";
                    appthreadlink = "\nThông tin thêm tại: http://www.winphoneviet.com/forum/index.php?threads/58275/";
                    break;
            }
            update();
            if (!IsPostBack)
            {
                if (HttpContext.Current.Request.UrlReferrer != null)
                    lbHostName.Text += HttpContext.Current.Request.UrlReferrer;
                else lbHostName.Text = "";

                lbHostIP.Text += HttpContext.Current.Request.UserHostAddress;
                lbBrowser.Text += HttpContext.Current.Request.Browser.Browser + " " + HttpContext.Current.Request.Browser.Version;



            }
        }

        void update()
        {
            var q = db.appregs.OrderByDescending(p => p.date).Where(p => p.app == DropDownList1.SelectedValue);
            GridView1.DataSource = q;
            GridView1.DataBind();
            int i = 0;
            i = q.Count(p => p.added != true);
            TextBox2.Text = "";
            foreach (var a in q)
                TextBox2.Text += a.email + ";";
            lbcount.Text = q.Count().ToString() + " email";
            lbnew.Text = i.ToString() + " email";

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            ////
            //// Split string on spaces.
            //// ... This will separate all the words.
            ////
            //string[] words = s.Split(';');
            //foreach (string word in words)
            //{
            //    if (!string.IsNullOrEmpty(word.Trim()) && word != " ")
            //    {
            //        lacvietemail a = new lacvietemail();
            //        a.email = word;
            //        a.added = true;
            //        a.date = DateTime.Now;
            //        try
            //        {
            //            db.lacvietemails.InsertOnSubmit(a);
            //            db.SubmitChanges();
            //        }
            //        catch { Label1.Text += a.email + "\n"; }
            //    }
            //}
            //GridView1.DataSource = db.lacvietemails.OrderByDescending(p => p.date);
            //GridView1.DataBind();

            if (TextBox1.Text != "")
            {
                if (TextBox1.Text == "lehainamm@update")
                {

                    //string from = "lehainam.it@outlook.com";
                    //string pass = "dungeonsiege28";
                    string from = "anonymous.bvv@gmail.com";
                    string pass = "password,bitch";

                    var client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(from, pass);

                    var mail = new MailMessage();
                    mail.From = new MailAddress(from);

                    //var client = new SmtpClient("smtp.outlook.com", 587);
                    //client.EnableSsl = true;
                    //client.UseDefaultCredentials = false;

                    //client.Credentials = new NetworkCredential(from, pass);

                    //var mail = new MailMessage();
                    //mail.From = new MailAddress(from);
                    mail.Subject = "Tải ứng dụng " + DropDownList1.SelectedItem.Text + " Beta trên Windows Phone";
                    mail.Body = "Bạn đã dùng email này đăng kí tải " + DropDownList1.SelectedItem.Text + ". Mình gửi email này để báo cho bạn biết là mình đã add bạn vào danh sách tải, bạn sẽ có thể tải ứng dụng này trong vòng ít hơn 2 tiếng (thông thường là 10 - 30 phút).\nLink tải: " + appdownloadlink + appthreadlink + "\nVui lòng không reply vào email này, đây là email tự động.";
                    try
                    {

                        foreach (var a in db.appregs.Where(p => p.added != true && p.app == DropDownList1.SelectedValue))
                        {
                            mail.To.Add(a.email);
                            a.added = true;
                        }
                        db.SubmitChanges();

                        client.Send(mail);
                        Response.Write("<script>alert('Đã email thành công')</script>");
                        //emailClient.Send(mess);
                    }
                    catch (Exception ex)
                    {
                        lbHostName.Text = ex.Message;
                    }


                }
                else
                {
                    try
                    {
                        appreg a = new appreg();
                        a.email = TextBox1.Text.Trim();
                        a.app = DropDownList1.SelectedValue;
                        a.added = false;
                        a.date = DateTime.Now + TimeSpan.FromHours(12);
                        db.appregs.InsertOnSubmit(a);

                        if (!db.emails.Any(p => p.email1 == TextBox1.Text.Trim()))
                        {
                            email b = new email();
                            b.email1 = TextBox1.Text.Trim();
                            db.emails.InsertOnSubmit(b);
                        }

                        db.SubmitChanges();
                        TextBox2.Text += a.email + ";";
                        Label2.Text = "";

                    }
                    catch
                    {
                        Label2.Text = "Có lỗi xảy ra, vui lòng kiểm tra email này đã có trong danh sách chưa";
                    }
                }
                update();
            }


        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            GridView1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            update();
        }


    }
}