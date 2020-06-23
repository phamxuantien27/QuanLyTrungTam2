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
    public partial class QuanLyLichHoc : UserControl
    {
        string Ma_LopHoc;
        DataTable LichHoc;
        public QuanLyLichHoc(string _ma_LopHoc)
        {
            InitializeComponent();
            Ma_LopHoc = _ma_LopHoc; 
            LoadForm();
        }

        string TaoMa_BuoiHoc(string Ma_LopHoc_Cu)
        {

            int x = 2;
            for (int i = 2; i < Ma_LopHoc_Cu.Length; i++)
            {
                if (Ma_LopHoc_Cu[i] != '0')
                {
                    x = i;
                }
            }
            string Ma_1 = Ma_LopHoc_Cu.Substring(0, x);
            string Ma_2 = Ma_LopHoc_Cu.Substring(x);
            int int_Ma_2 = Convert.ToInt32(Ma_2);
            int int_Ma_2_Moi = int_Ma_2 + 1;
            return Ma_1 + int_Ma_2_Moi.ToString();
        }

        void LoadForm()
        {
            List<EC_LichHoc> listBuoiHoc = new BUS_LichHoc().SelectByFields("Ma_LopHoc", Ma_LopHoc);
            int stt = 1;
            foreach (EC_LichHoc BuoiHoc in listBuoiHoc)
            {
                string TrangThai = BuoiHoc.TrangThai == true ? "Đã học" : "Chưa học";
                dgLichHoc.Rows.Add(stt, BuoiHoc.Ma_BuoiHoc, BuoiHoc.NgayHoc, BuoiHoc.KipHoc, BuoiHoc.PhongHoc,
                    BuoiHoc.TongHocPhi_Buoi, TrangThai, "Sửa");
                stt++;
            }

            txbMa_LopHoc.Text = Ma_LopHoc;

            EC_LopHoc LopHoc = new BUS_LopHoc().Select_ByPrimaryKey(Ma_LopHoc);

            EC_GiaoVien GiaoVien = new BUS_GiaoVien().Select_ByPrimaryKey(LopHoc.Ma_GiaoVien);
            txbTen_Giaoien.Text = GiaoVien.Ten_GiaoVien;

            EC_MonHoc MonHoc = new BUS_MonHoc().Select_ByPrimaryKey(LopHoc.Ma_MonHoc);
            txbTen_MonHoc.Text = MonHoc.Ten_MonHoc + " " + MonHoc.Lop.ToString();
        }

        public enum BuoiHoc1
        {
            Ma_BuoiHoc,
            NgayHoc,
            KipHoc,
            Phong,
            TongHocPhi_Buoi,
            TrangThai
        }

        private void dgLichHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (e.ColumnIndex == 7)
            {
                string ThaoTac = dgLichHoc.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (ThaoTac == "Thêm")
                {
                    string Ma_BuoiHoc_Cu = new BUS_LichHoc().SelectAll()[0].Ma_BuoiHoc;
                    string Ma_BuoiHoc_Moi = TaoMa_BuoiHoc(Ma_BuoiHoc_Cu);
                    DataGridViewRow cell = dgLichHoc.Rows[e.RowIndex];
                    int Kip = Int32.Parse(cell.Cells["KipHoc"].Value.ToString());
                    string Phong = cell.Cells["Phong"].Value.ToString();
                    DateTime NgayHoc = Convert.ToDateTime(cell.Cells["NgayHoc"].Value.ToString());
                    int TongHocPhi_Buoi = Convert.ToInt32(cell.Cells["TongHocPhi_Buoi"].Value.ToString());
                    bool TrangThai = cell.Cells[6].Value.ToString() == "Đã học" ? true : false;

                    int Stt_Buoi = Convert.ToInt32(cell.Cells["STT"].Value);
                    List<EC_LichHoc> ListLichHoc = new BUS_LichHoc().SelectByFields("Ma_LopHoc", Ma_LopHoc);
                    foreach(EC_LichHoc Buoi in ListLichHoc)
                    {
                        if (Stt_Buoi == Buoi.STT_Buoi)
                        {
                            MessageBox.Show("Số thứ tự buổi học đã tồn tại", "Thông báo");
                            return;
                        }
                    }

                    EC_LichHoc BuoiHoc = new EC_LichHoc(Ma_LopHoc, DateTime.Now, Kip, Ma_BuoiHoc_Moi,
                        Phong, Stt_Buoi, TongHocPhi_Buoi, TrangThai);

                    new BUS_LichHoc().ThemDuLieu(BuoiHoc);
                }
                else if (ThaoTac == "Sửa")
                {
                    DataGridViewRow cell = dgLichHoc.Rows[e.RowIndex];
                    EC_LichHoc BuoiHoc = new BUS_LichHoc().Select_ByPrimaryKey(cell.Cells["Ma_BuoiHoc"].Value.ToString());

                    BuoiHoc.STT_Buoi = Int32.Parse(cell.Cells["STT"].Value.ToString());
                    BuoiHoc.NgayHoc = Convert.ToDateTime(cell.Cells["NgayHoc"].Value);
                    BuoiHoc.PhongHoc = cell.Cells["PhongHoc"].Value.ToString();

                    new BUS_LichHoc().SuaDuLieu(BuoiHoc);
                }
            }
            else
            {

            }
        }
    }
}
