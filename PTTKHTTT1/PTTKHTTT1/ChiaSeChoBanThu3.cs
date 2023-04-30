using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTTKHTTT1
{
    public partial class MH_ChiaSeChoBanThu3 : Form
    {
        private KhachHang kh;
        private ThongTinDatTour ThongTinDatTour;
        public MH_ChiaSeChoBanThu3(KhachHang khachHang, ThongTinDatTour thongTinDatTour)
        {
            InitializeComponent();
            this.ThongTinDatTour = thongTinDatTour;
            this.kh = khachHang;
        } 
        public void DongY_Click(object sender, EventArgs e)
        {
            if (kh.HoTen == "")
            {
                bool res2 = ThongTinDatTour.ThemKHVaoTour(ThongTinDatTour);
                if ((res2 == true))
                {
                    MessageBox.Show("Thành Công");
                    var x = new MH_TraPhi(kh, "Tour", ThongTinDatTour);
                    x.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Thất Bại");
                }
            }
            else
            {
                bool res1 = kh.ThemKH(kh);
                bool res2 = ThongTinDatTour.ThemKHVaoTour(ThongTinDatTour);
                if ((res1 == true && res2 == true))
                {
                    MessageBox.Show("Thành Công");
                    var x = new MH_TraPhi(kh, "Tour", ThongTinDatTour);
                    x.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Thất Bại");
                }
            }
              
            
        }

        private void KhongDongY_Click(object sender, EventArgs e)
        {
            var x = new MH_TimTour();
            x.Show();
            this.Hide();
        }
    }
    
}
