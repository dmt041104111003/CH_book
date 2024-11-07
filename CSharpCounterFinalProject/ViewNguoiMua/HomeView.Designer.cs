namespace CSharpCounterFinalProject.ViewNguoiMua
{
    partial class HomeView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button4 = new System.Windows.Forms.Button();
            this.btnKhuyenMai = new System.Windows.Forms.Button();
            this.btnGioHang = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTimKiemTheo = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.labelNhapTK = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.tableSanPhams = new System.Windows.Forms.TableLayoutPanel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1874, 1097);
            this.splitContainer1.SplitterDistance = 88;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(792, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHÀO MỪNG ";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.button4);
            this.splitContainer2.Panel1.Controls.Add(this.btnKhuyenMai);
            this.splitContainer2.Panel1.Controls.Add(this.btnGioHang);
            this.splitContainer2.Panel1.Controls.Add(this.btnSanPham);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.cbTimKiemTheo);
            this.splitContainer2.Panel2.Controls.Add(this.btnTimKiem);
            this.splitContainer2.Panel2.Controls.Add(this.labelNhapTK);
            this.splitContainer2.Panel2.Controls.Add(this.txtTimKiem);
            this.splitContainer2.Panel2.Controls.Add(this.tableSanPhams);
            this.splitContainer2.Size = new System.Drawing.Size(1874, 1005);
            this.splitContainer2.SplitterDistance = 236;
            this.splitContainer2.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 275);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(233, 87);
            this.button4.TabIndex = 3;
            this.button4.Text = "THÔNG TIN KHÁCH HÀNG";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnKhuyenMai
            // 
            this.btnKhuyenMai.Location = new System.Drawing.Point(0, 192);
            this.btnKhuyenMai.Name = "btnKhuyenMai";
            this.btnKhuyenMai.Size = new System.Drawing.Size(233, 77);
            this.btnKhuyenMai.TabIndex = 2;
            this.btnKhuyenMai.Text = "KHUYẾN MÃI";
            this.btnKhuyenMai.UseVisualStyleBackColor = true;
            // 
            // btnGioHang
            // 
            this.btnGioHang.Location = new System.Drawing.Point(0, 109);
            this.btnGioHang.Name = "btnGioHang";
            this.btnGioHang.Size = new System.Drawing.Size(233, 77);
            this.btnGioHang.TabIndex = 1;
            this.btnGioHang.Text = "GIỎ HÀNG";
            this.btnGioHang.UseVisualStyleBackColor = true;
            this.btnGioHang.Click += new System.EventHandler(this.btnGioHang_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.Location = new System.Drawing.Point(0, 26);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(233, 77);
            this.btnSanPham.TabIndex = 0;
            this.btnSanPham.Text = "SẢN PHẨM";
            this.btnSanPham.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tìm kiếm theo";
            // 
            // cbTimKiemTheo
            // 
            this.cbTimKiemTheo.FormattingEnabled = true;
            this.cbTimKiemTheo.Items.AddRange(new object[] {
            "Tìm kiếm theo tên sản phẩm",
            "Tìm kiếm theo phân loại hàng",
            "Tìm kiếm theo hãng sản xuất",
            "Tìm kiếm theo a-z"});
            this.cbTimKiemTheo.Location = new System.Drawing.Point(447, 149);
            this.cbTimKiemTheo.Name = "cbTimKiemTheo";
            this.cbTimKiemTheo.Size = new System.Drawing.Size(796, 37);
            this.cbTimKiemTheo.TabIndex = 6;
            this.cbTimKiemTheo.SelectedIndexChanged += new System.EventHandler(this.cbTimKiemTheo_SelectedIndexChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(1331, 80);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(189, 50);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // labelNhapTK
            // 
            this.labelNhapTK.AutoSize = true;
            this.labelNhapTK.Location = new System.Drawing.Point(179, 89);
            this.labelNhapTK.Name = "labelNhapTK";
            this.labelNhapTK.Size = new System.Drawing.Size(220, 29);
            this.labelNhapTK.TabIndex = 4;
            this.labelNhapTK.Text = "Nhập tên sản phẩm";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(447, 86);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(796, 35);
            this.txtTimKiem.TabIndex = 3;
            // 
            // tableSanPhams
            // 
            this.tableSanPhams.AutoSize = true;
            this.tableSanPhams.ColumnCount = 5;
            this.tableSanPhams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableSanPhams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableSanPhams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableSanPhams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableSanPhams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableSanPhams.Location = new System.Drawing.Point(39, 221);
            this.tableSanPhams.Name = "tableSanPhams";
            this.tableSanPhams.RowCount = 2;
            this.tableSanPhams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableSanPhams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableSanPhams.Size = new System.Drawing.Size(805, 1200);
            this.tableSanPhams.TabIndex = 2;
            // 
            // HomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1874, 1097);
            this.Controls.Add(this.splitContainer1);
            this.Name = "HomeView";
            this.Text = "HomeView";
            this.Load += new System.EventHandler(this.HomeView_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnKhuyenMai;
        private System.Windows.Forms.Button btnGioHang;
        private System.Windows.Forms.TableLayoutPanel tableSanPhams;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label labelNhapTK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTimKiemTheo;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}