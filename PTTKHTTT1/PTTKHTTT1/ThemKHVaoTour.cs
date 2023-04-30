using Funnction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTTKHTTT1
{
    public partial class MH_ThemKHVaoTour : Form
    {
        static public string maTour;
        public MH_ThemKHVaoTour(string matour)
        {
            InitializeComponent();
            maTour = matour;
        }

        private void QuayLai_Click(object sender, EventArgs e)
        {
            var x = new MH_TimTour();
            x.Show();
            this.Hide();
        }

        private void XacNhan_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" || textBox2.Text== ""||textBox4.Text== ""||textBox5.Text== ""||textBox6.Text== ""||dateTimePicker1.Text=="")
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin");
            }
               
            else
            {

                Support.InitConnection();
                string makh = ""; 
                makh=Support.GetFieldValues("Select makh from khachhang where email='"+textBox5.Text.Trim()+"'");
                if(makh=="")
                {
                    KhachHang kh = new KhachHang("", "", textBox5.Text.Trim(), textBox1.Text.Trim(), "", dateTimePicker1.Text.Trim(), textBox4.Text.Trim());

                    string sql = "select count(makh) from khachhang";
                    Support.InitConnection();
                    sql = Support.GetFieldValues(sql);
                    int temp = int.Parse(sql) + 1;
                    ThongTinDatTour thongTinDatTour = new ThongTinDatTour(maTour,textBox2.Text.Trim(), textBox6.Text.Trim(), "", "", temp.ToString(), "");
                    Support.Disconnect();
                    var x = new MH_ChiaSeChoBanThu3(kh, thongTinDatTour);
                    x.Show();
                    this.Hide();
                }    
                else
                {
                    KhachHang kh = new KhachHang("", "", "", "", makh, "", "");
                    ThongTinDatTour thongTinDatTour = new ThongTinDatTour(maTour,textBox2.Text.Trim(), textBox6.Text.Trim(), "", "", makh, "");
                    Support.Disconnect();
                    var x = new MH_ChiaSeChoBanThu3(kh, thongTinDatTour);
                    x.Show();
                    this.Hide();
                }
            }    
        }
    }
    public class KhachHang
    {
        public string cccd;
        public string diachi;
        public string Email;
        public string HoTen;
        public string MaKH;
        public string NgaySinh;
        public string SDT;
        private KhachHangDB khachHangDB = new KhachHangDB();
        public KhachHang(string cccd,string diachi,string Email,string HoTen,string MaKH,string NgaySinh,string SDT) 
        {
            this.cccd = cccd;
            this.diachi= diachi;
            this.Email = Email;
            this.HoTen = HoTen;
            this.MaKH= MaKH;
            this.NgaySinh= NgaySinh;
            this.SDT = SDT;
        }
        public bool ThemKH(KhachHang KH)
        {
            return khachHangDB.ThemKH(KH);
        }
    }
    public class ThongTinDatTour
    {
        public string DiaDiemKhoiHanh { get; set; }
        public string GhiChu { get; set; }
        public string MaDatTour { get; set; }
        public string MaKH { get; set; }
        public string NgayKhoiHanh { get; set; }
        public string NgayKetThuc { get; set; }
        public string maTour { get; set; }
        public ThongTinDatTourDB ThongTinDatTourDB = new ThongTinDatTourDB();

        public ThongTinDatTour(string maTour,string DiaDiemKhoiHanh, string GhiChu, string MaDatTour, string NgayKhoiHanh, string MaKH, string NgayKetThuc)
        {
            this.DiaDiemKhoiHanh = DiaDiemKhoiHanh;
            this.GhiChu = GhiChu;
            this.MaDatTour = MaDatTour;
            this.NgayKhoiHanh = NgayKhoiHanh;
            this.MaKH = MaKH;
            this.NgayKetThuc = NgayKetThuc;
            this.maTour = maTour;
        }
        public bool ThemKHVaoTour(ThongTinDatTour thongTinDatTour)
        {

            return ThongTinDatTourDB.ThemKHVaoTour(thongTinDatTour);
        }
        public string DocThongTinTour(string str)
        {
            ThongTinDatTourDB temp = new ThongTinDatTourDB();
            return temp.DocThongTinTour(str);
        }
        
    }

    public class KhachHangDB
    {
        public bool ThemKH(KhachHang khachHang)
        {
            bool res = true;
            string sql = "insert into KhachHang(hoten,ngaysinh,sdt,email) values ('"+ khachHang.HoTen + "','"+ khachHang.NgaySinh + "'," + khachHang.SDT + ",'" + khachHang.Email + "')";
            Support.InitConnection();
            try
            {
                Support.RunSQL(sql);
            }
            catch (Exception ex)
            {
                res = false;
                Support.Disconnect();
                return res;
            }
            Support.Disconnect();
            return res;
        }
    }

    public class ThongTinDatTourDB
    {
        public bool ThemKHVaoTour(ThongTinDatTour thongTinDatTour)
        {
            bool res = true;
            string sql = "insert into ThongTinDatTour(matour,makh,diadiemkhoihanh,ghichu) values ('" + MH_ThemKHVaoTour.maTour+ "','" + thongTinDatTour.MaKH + "','" + thongTinDatTour.DiaDiemKhoiHanh + "','" + thongTinDatTour.GhiChu + "')";
            Support.InitConnection();
            try
            {
                Support.RunSQL(sql);
            }
            catch (Exception ex)
            {
                res = false;
                Support.Disconnect();
                return res;
            }
            Support.Disconnect();
            return res;
        }
        public string DocThongTinTour(string str)
        {
            string sql = "Select madatTour from thongtindattour where matour="+str+" ";
            Support.InitConnection();
            string res = Support.GetFieldValues(sql);
            return res;
        }
    }
}
