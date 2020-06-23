namespace QuanLyTrungTam
{
    partial class QL_ThuHocPhi
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgLichHoc = new System.Windows.Forms.DataGridView();
            this.ThoiGian = new System.Windows.Forms.DateTimePicker();
            this.bbtThangSau = new System.Windows.Forms.Button();
            this.btThangTruoc = new System.Windows.Forms.Button();
            this.btThuHocPhi = new System.Windows.Forms.Button();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_HocSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongHocPhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChuaDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgLichHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgLichHoc
            // 
            this.dgLichHoc.AllowUserToAddRows = false;
            this.dgLichHoc.AllowUserToResizeRows = false;
            this.dgLichHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgLichHoc.BackgroundColor = System.Drawing.Color.White;
            this.dgLichHoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgLichHoc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgLichHoc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgLichHoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgLichHoc.ColumnHeadersHeight = 30;
            this.dgLichHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgLichHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Ma,
            this.Ten_HocSinh,
            this.TongHocPhi,
            this.DaDong,
            this.ChuaDong});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgLichHoc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgLichHoc.GridColor = System.Drawing.Color.White;
            this.dgLichHoc.Location = new System.Drawing.Point(75, 168);
            this.dgLichHoc.Name = "dgLichHoc";
            this.dgLichHoc.RowHeadersVisible = false;
            this.dgLichHoc.RowHeadersWidth = 60;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgLichHoc.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgLichHoc.RowTemplate.Height = 50;
            this.dgLichHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLichHoc.Size = new System.Drawing.Size(1522, 664);
            this.dgLichHoc.TabIndex = 5;
            this.dgLichHoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLichHoc_CellClick);
            // 
            // ThoiGian
            // 
            this.ThoiGian.Location = new System.Drawing.Point(705, 85);
            this.ThoiGian.Name = "ThoiGian";
            this.ThoiGian.Size = new System.Drawing.Size(200, 22);
            this.ThoiGian.TabIndex = 6;
            // 
            // bbtThangSau
            // 
            this.bbtThangSau.Location = new System.Drawing.Point(1469, 105);
            this.bbtThangSau.Name = "bbtThangSau";
            this.bbtThangSau.Size = new System.Drawing.Size(128, 57);
            this.bbtThangSau.TabIndex = 7;
            this.bbtThangSau.Text = "Tháng sau";
            this.bbtThangSau.UseVisualStyleBackColor = true;
            this.bbtThangSau.Click += new System.EventHandler(this.bbtThangSau_Click);
            // 
            // btThangTruoc
            // 
            this.btThangTruoc.Location = new System.Drawing.Point(1352, 105);
            this.btThangTruoc.Name = "btThangTruoc";
            this.btThangTruoc.Size = new System.Drawing.Size(111, 57);
            this.btThangTruoc.TabIndex = 8;
            this.btThangTruoc.Text = "Tháng trước";
            this.btThangTruoc.UseVisualStyleBackColor = true;
            this.btThangTruoc.Click += new System.EventHandler(this.btThangTruoc_Click);
            // 
            // btThuHocPhi
            // 
            this.btThuHocPhi.Location = new System.Drawing.Point(1136, 105);
            this.btThuHocPhi.Name = "btThuHocPhi";
            this.btThuHocPhi.Size = new System.Drawing.Size(111, 57);
            this.btThuHocPhi.TabIndex = 9;
            this.btThuHocPhi.Tag = "Thu tiền";
            this.btThuHocPhi.Text = "Thu học phí";
            this.btThuHocPhi.UseVisualStyleBackColor = true;
            this.btThuHocPhi.Click += new System.EventHandler(this.btThuHocPhi_Click);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            // 
            // Ma
            // 
            this.Ma.HeaderText = "Mã học sinh";
            this.Ma.Name = "Ma";
            // 
            // Ten_HocSinh
            // 
            this.Ten_HocSinh.DataPropertyName = "Ten_HocSinh";
            this.Ten_HocSinh.HeaderText = "Họ và tên";
            this.Ten_HocSinh.Name = "Ten_HocSinh";
            // 
            // TongHocPhi
            // 
            this.TongHocPhi.DataPropertyName = "TongTien";
            this.TongHocPhi.HeaderText = "Tổng học phí";
            this.TongHocPhi.Name = "TongHocPhi";
            // 
            // DaDong
            // 
            this.DaDong.DataPropertyName = "DaDong";
            this.DaDong.HeaderText = "Đã đóng";
            this.DaDong.Name = "DaDong";
            // 
            // ChuaDong
            // 
            this.ChuaDong.DataPropertyName = "ChuaDong";
            this.ChuaDong.HeaderText = "Chưa đóng";
            this.ChuaDong.Name = "ChuaDong";
            // 
            // QL_ThuHocPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btThuHocPhi);
            this.Controls.Add(this.btThangTruoc);
            this.Controls.Add(this.bbtThangSau);
            this.Controls.Add(this.ThoiGian);
            this.Controls.Add(this.dgLichHoc);
            this.Name = "QL_ThuHocPhi";
            this.Size = new System.Drawing.Size(1663, 917);
            ((System.ComponentModel.ISupportInitialize)(this.dgLichHoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgLichHoc;
        private System.Windows.Forms.DateTimePicker ThoiGian;
        private System.Windows.Forms.Button bbtThangSau;
        private System.Windows.Forms.Button btThangTruoc;
        private System.Windows.Forms.Button btThuHocPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_HocSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongHocPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChuaDong;
    }
}
