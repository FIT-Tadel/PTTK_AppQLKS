using Funnction;
using PTTKHTTT1;
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
    public partial class MH_TimTour : Form
    {
        private DSDiaDiem[] dSDiaDiems;
        public MH_TimTour()
        {
            InitializeComponent();
            
        }
        public void HienThi(DataTable dt)
        {
            dataGridView1.DataSource = dt;
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = ButtonTimKiem_Click(textBox1.Text, dSDiaDiems);
            HienThi(dt);
        }

        private DataTable ButtonTimKiem_Click(string str, DSDiaDiem[]dSDiaDiems)
        {
            
            return DSDiaDiem.LayDSDiaDiem(str, dSDiaDiems);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonTimKiem_Click(sender, e);
        }

        private void chonTour_Click(object sender, EventArgs e)
        {

            int index = dataGridView1.CurrentCell.RowIndex;
            if (index !=-1 ) {
                MessageBox.Show(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var x = new MH_ThemKHVaoTour(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                x.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Vui Lòng Chọn Tour");
            }    
        }
    }
    public class DSDiaDiem
    {
        private string DiaDiemDi;
        private string DiaDiemDen;
        private string MaDT;
        private string MaTour;
        private string PhiTour;
        private string SLToiDa;
        private string TenTour;
        public DSDiaDiem(string DiaDiemDi,string DiaDiemDen,string MaDT,string MaTour,string PhiTour,string SLToiDa,string TenTour)
        {
            this.DiaDiemDen = DiaDiemDen;
            this.MaDT = MaDT;
            this.DiaDiemDi = DiaDiemDi;
            this.SLToiDa = SLToiDa;
            this.MaTour = MaTour;
            this.PhiTour=PhiTour;
            this.TenTour=TenTour;
        }
        static public DataTable LayDSDiaDiem(string str, DSDiaDiem[] dSDiaDiems)
        {
            DataTable dt=DSDiaDiemDB.DocDSDiaDiem(str, dSDiaDiems);
            return dt;
        }
        static public DataTable LayDSDiaDiem(DSDiaDiem[] dSDiaDiems, string str)
        {
            DataTable dt = DSDiaDiemDB.DocDSDiaDiem(dSDiaDiems, str);
            return dt;
        }
    }
}

    public partial class DSDiaDiemDB
    {
        static public DataTable DocDSDiaDiem(string str, DSDiaDiem[] dSDiaDiems)
        {
            
            string sql = "select matour,diadiemdi,diadiemden,phitour from dsdiadiem where diadiemdi='"+str+"' or diadiemden='"+str+"'";
            Support.InitConnection();
            DataTable dataTable;
            dataTable= Support.GetDataToTable(sql);
            
            Support.Disconnect();
            int i = 0;
            dSDiaDiems = new DSDiaDiem[dataTable.Rows.Count];
            foreach (DataRow row in dataTable.Rows)
            {

                DSDiaDiem THUAN=new DSDiaDiem(row["DiaDiemDi"].ToString(),(string)row["DiaDiemDen"].ToString(),"",(string)row["MATOUR"].ToString(),(string)row["PhiTour"].ToString(),"","");
                dSDiaDiems[i++] = THUAN;
            }
            return dataTable;
        }
        static public DataTable DocDSDiaDiem(DSDiaDiem[] dSDiaDiems,string maTour)
        {

            string sql = "select * from dsdiadiem where maTour='"+maTour+"'";
            Support.InitConnection();
            DataTable dataTable;
            dataTable = Support.GetDataToTable(sql);

            Support.Disconnect();
            int i = 0;
            dSDiaDiems = new DSDiaDiem[dataTable.Rows.Count];
            foreach (DataRow row in dataTable.Rows)
            {

                DSDiaDiem THUAN = new DSDiaDiem(row["DiaDiemDi"].ToString(), (string)row["DiaDiemDen"].ToString(), "", (string)row["MATOUR"].ToString(), (string)row["PhiTour"].ToString(), "", "");
                dSDiaDiems[i++] = THUAN;
            }
            return dataTable;
        }
    }

