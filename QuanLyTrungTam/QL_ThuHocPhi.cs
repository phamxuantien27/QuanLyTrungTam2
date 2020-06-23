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

namespace QuanLyTrungTam
{
    public partial class QL_ThuHocPhi : UserControl
    {
        DataTable data;
        public QL_ThuHocPhi()
        {
            InitializeComponent();
            Load();
        }

        void Load()
        {
            dgLichHoc.Rows.Clear();
            DateTime date = ThoiGian.Value;
            data = new function().Select_HocPhi_Thang(date);
            int i = 1;

            foreach(DataRow row in data.Rows)
            {
                dgLichHoc.Rows.Add(i.ToString(), row["Ma_HocSinh"].ToString(), row["Ten_HocSinh"].ToString(), row["TongSoTien"].ToString(),
                    row["DaDong"].ToString(), row["ChuaDong"].ToString());
                i++;
            }
        }
        string Ma_HocSinh = "";
        private void dgLichHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (data == null)
            {
                return;
            }
            if (e.RowIndex == -1)
            {
                return;
            }
            foreach(DataRow row in data.Rows)
            {
                if (row["Ma_HocSinh"].ToString() == dgLichHoc.Rows[e.RowIndex].Cells["Ma"].Value.ToString())
                {
                    Ma_HocSinh = row["Ma_HocSinh"].ToString();
                }
            }
        }

        private void btThuHocPhi_Click(object sender, EventArgs e)
        {
            if (Ma_HocSinh == "")
            {
                return;
            }
            ThuHocPhi ThuHocPhi = new ThuHocPhi(Ma_HocSinh, ThoiGian.Value);
            ThuHocPhi.Show();
        }

        private void btThangTruoc_Click(object sender, EventArgs e)
        {
            DateTime date = ThoiGian.Value;
            if (date.Month > 1)
            {
                DateTime date1 = new DateTime(date.Year, date.Month - 1, date.Day);
                ThoiGian.Value = date1;
            }
            else
            {
                DateTime date1 = new DateTime(date.Year - 1, 12, date.Day);
                ThoiGian.Value = date1;
            }
            Load();
        }

        private void bbtThangSau_Click(object sender, EventArgs e)
        {
            DateTime date = ThoiGian.Value;
            if (date.Month < 12)
            {
                DateTime date1 = new DateTime(date.Year, date.Month + 1, date.Day);
                ThoiGian.Value = date1;
            }
            else
            {
                DateTime date1 = new DateTime(date.Year + 1, 1, date.Day);
                ThoiGian.Value = date1;
            }
            Load();
        }
    }
}
