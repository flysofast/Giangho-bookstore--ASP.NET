using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QlSach
{
    public class Gio
    {
        public DataTable dt = new DataTable("BanHang");
        public Gio()
        {
            dt.Columns.Add("Masach");
            dt.Columns.Add("Tensach");
            dt.Columns.Add("Soluong");
            dt.Columns.Add("Gia");
            dt.Columns.Add("ThanhTien");
        }
        public bool ThemGioHang(string ms, string ts, int sl, int gia)
        {
            QlSachDbDataContext db = new QlSachDbDataContext();

            //Kiểm tra xem còn đủ sách để đặt mua không (kiểm tra trước đỡ chạy vòng lặp)
            if (db.saches.Single(p => p.masach == ms).soluong < sl)
                return false;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                DataRow dr = dt.Rows[i];
                if (dr["Masach"].ToString().Trim().Equals(ms.Trim()))
                {
                    int sltam = int.Parse(dr["Soluong"].ToString());
                    
                    //Kiểm tra xem còn đủ sách để đặt mua không (cộng thêm số lượng đã có trong giỏ hàng)
                   
                    if (db.saches.Single(p => p.masach == ms).soluong < sl+sltam)
                    {
                        return false;
                    }

                    dt.Rows[i]["Soluong"] = Convert.ToString(sltam + sl);
                    dt.Rows[i]["ThanhTien"] = int.Parse(dr["Gia"].ToString()) * (sltam + sl);
                    dt.AcceptChanges();
                    return true;
                }
            }
            
            
           
            
            DataRow dr1 = dt.NewRow();
            dr1["masach"] = ms;
            dr1["tensach"] = ts;
            dr1["soluong"] = sl;
            dr1["gia"] = gia;
            dr1["thanhtien"] = sl * gia;
            dt.Rows.Add(dr1);
            dt.AcceptChanges();
            return true;
            //            for (int i = 0; i < dt.Rows.Count; i++)
            //{ //Lấy về dòng thứ i lưu vào dr1
            //DataRow dr1 = dt.Rows[i];
            //// Nếu mã sách trùng nhau thì tăng số lượng và tính lại thành tiền
            //if (dr1["Masach"].ToString().Trim().Equals(ms.Trim()))
            //{
            //int sltam = int.Parse(dr1["Soluong"].ToString());
            //dr1["Soluong"] = Convert.ToString(sltam + sl);
            //dr1["ThanhTien"] = int.Parse(dr1["Soluong"].ToString()) *
            //int.Parse(dr1["Gia"].ToString());
            //return;
        }
        public int TongTien()
        {
            int s = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                s += int.Parse(dr["thanhtien"].ToString());
            }
            return s;
        }
    }
}