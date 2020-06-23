using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTrungTam_BUS;
using QuanLyNhaHang_Entity;

namespace QuanLyTrungTam
{
    public partial class LopDay : UserControl
    {
        string Ma_GiaoVien;
        public LopDay(string _ma_GiaoVien)
        {
            Ma_GiaoVien = _ma_GiaoVien;
            InitializeComponent();
            Load();
        }

        void Load()
        {
            List<EC_LopHoc> listDanhSachLop = new BUS_LopHoc().SelectByFields("Ma_GiaoVien", Ma_GiaoVien);
            dgLopHoc.DataSource = listDanhSachLop;

            cbTenMon.Items.Clear();
            List<EC_MonHoc> listtMonHoc = new BUS_MonHoc().SelectAll();
            string TenMon = listtMonHoc[0].Ten_MonHoc;
            cbTenMon.Items.Add(TenMon);
            foreach (EC_MonHoc MonHoc in listtMonHoc)
            {
                if (MonHoc.Ten_MonHoc != TenMon)
                {
                    cbTenMon.Items.Add(MonHoc.Ten_MonHoc);
                    TenMon = MonHoc.Ten_MonHoc;
                }
            }
        }

        private void dgLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string Ma_LopHoc = dgLopHoc.Rows[e.RowIndex].Cells["Ma_LopHoc"].Value.ToString();
            //Form form = new Form();
            //form.Size = new System.Drawing.Size(1000, 1000);
            //form.Controls.Add(new DiemDanh(Ma_LopHoc));
            //form.Show();
        }
    }
}
