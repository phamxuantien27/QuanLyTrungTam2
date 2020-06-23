using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTrungTam_BUS;
using QuanLyNhaHang_Entity;

namespace QuanLyTrungTam
{
    public partial class ThuHocPhi : Form
    {
        string Ma_HocSinh;
        DateTime ThoiGian;
        public ThuHocPhi(string _Ma_HocSinh, DateTime _ThoiGian)
        {
            InitializeComponent();
            Ma_HocSinh = _Ma_HocSinh;
            ThoiGian = _ThoiGian;
            Load();
        }

        void Load()
        {
            EC_HocSinh HocSinh = new BUS_HocSinh().Select_ByPrimaryKey(Ma_HocSinh);
            txbMa_HocSinh.Text = HocSinh.Ma_HocSinh;
            txbTenHocSinh.Text = HocSinh.Ten_HocSinh;
            txbNgayThu.Text = DateTime.Now.ToShortDateString();
            txbThang.Text = ThoiGian.Month.ToString() + "/" + ThoiGian.Year.ToString();
            
            DataTable data = new function().Select_HocPhi_Thang(ThoiGian);
            foreach(DataRow row in data.Rows)
            {
                if (row["Ma_HocSinh"].ToString() == HocSinh.Ma_HocSinh)
                {
                    txbTongHocPhi.Text = row["TongSoTien"].ToString();
                }
            }
        }

        private void btDongTien_Click(object sender, EventArgs e)
        {
            try
            {
                new function().DongTien_Thang(Ma_HocSinh, ThoiGian);
                MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không thành công!", "Thông báo");
                return;
            }

        }
    }
}
