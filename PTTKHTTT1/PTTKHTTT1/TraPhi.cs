using Funnction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PTTKHTTT1
{
    public partial class MH_TraPhi : Form
    {
        private NhanVien nhanVien=new NhanVien();
        private NhanVien[] nv;
        DSDiaDiem[] dSDiaDiems;
        ThongTinDatTour thongTinDatTour;
        public MH_TraPhi(KhachHang kh,string predicate,ThongTinDatTour thongTinDatTour)
        {
            InitializeComponent();
            HienThi(kh,predicate,thongTinDatTour);
            this.thongTinDatTour= thongTinDatTour;
        }
        private void HienThi(KhachHang kh, string predicate, ThongTinDatTour thongTinDatTour)
        {

            if (predicate == "Tour")
            {
                nhanVien.LayNhanVien(ref nv);
                for (int i = 0; i < nv.Count(); i = i + 1)
                {
                    comboBox1.Items.Add(nv[i].MaNV);
                }
                DataTable dt = DSDiaDiem.LayDSDiaDiem(dSDiaDiems, thongTinDatTour.maTour);
                dt.Columns.Remove("MaDT");
                dataGridView1.DataSource = dt;
                textBox2.Text = thongTinDatTour.MaKH;
                textBox1.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            TraPhi_Click(thongTinDatTour.maTour);
        }
        private void TraPhi_Click(string str)
        {

            PhieuThuPhi temp = new PhieuThuPhi();
            ThongTinDatTour thongTinDatTour = new ThongTinDatTour("", "", "", "", "", "", "");
            temp.nvthuphi = comboBox1.Text.Trim();
            temp.thanhtien = textBox1.Text.Trim();
            temp.madatdv = "DV"+thongTinDatTour.DocThongTinTour(str);
            try
            {
                temp.ThemPhieuThuPhi(temp);
            }
            catch (Exception ex)
            {
               
                Support.Disconnect();
                MessageBox.Show("Thanh Toán Thất Bại");
                return;
            }
            MessageBox.Show("Thanh Toán Thành Công");
            Support.Disconnect();
        }
    }
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string DiaChi{ get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string Luong { get; set; }
        public string loaiNV{ get; set; }

        public void LayNhanVien(ref NhanVien[] nv)
        {

            NhanVienDB Temp = new NhanVienDB();
            Temp.LayNV(ref nv);
        }

    }
    public class NhanVienDB
    {
        public void LayNV(ref NhanVien[] nv)
        {
            string sql = "select manv from nhanvien1";
            Support.InitConnection();
            DataTable dataTable;
            dataTable = Support.GetDataToTable(sql);

            Support.Disconnect();
            int i = 0;
            nv = new NhanVien[dataTable.Rows.Count];
            foreach (DataRow row in dataTable.Rows)
            {

                NhanVien THUAN = new NhanVien();
                THUAN.MaNV = row[0].ToString();
                nv[i++] = THUAN;
            }   
        }

    }

    public class PhieuThuPhi
    {
        public string MaPhieuThuPhi { get; set; }
        public string madatdv { get; set; }
        public string thanhtien { get; set; }
        public string nvthuphi { get; set; }
        public void ThemPhieuThuPhi(PhieuThuPhi ptp)
        {
            PhieuThuPhiDB temp = new PhieuThuPhiDB();
            temp.ThemPhieuThuPhi(ptp);          
        }

    }

    public class PhieuThuPhiDB
    {
        public void ThemPhieuThuPhi(PhieuThuPhi ptp)
        {
            string sql = "insert into phieuthuphi (madat,thanhtien,nvthuphi) values('" + ptp.madatdv + "','" + ptp.thanhtien + "'," + ptp.nvthuphi + ")";
            Support.InitConnection();
            Support.RunSQL(sql);
            Support.Disconnect();
        }

    }
}
