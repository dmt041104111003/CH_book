using CSharpCounterFinalProject.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpCounterFinalProject.ViewNguoiMua
{
    public partial class ChiTietSanPhamView : Form
    {
        DataBaseProcess db = new DataBaseProcess();

        //THONG TIN SAN PHAM
        string tensp, gia, fileanh, masp;
        public ChiTietSanPhamView(string label1Text, string label2Text, string anh, string masp2)
        {
            InitializeComponent();
            tensp = label1Text;
            gia = label2Text;
            fileanh = anh;
            masp = masp2;
            labelTenSP.Text = tensp;
            labelGia.Text = gia + "VND";
            string imagePath = System.Windows.Forms.Application.StartupPath + "\\AnhSP\\" + fileanh;
            boxAnhSP.Image = Image.FromFile(imagePath);
            boxAnhSP.SizeMode = PictureBoxSizeMode.Zoom; //anh vua van
            //tim kiem nhung cai khac qua masp
            string query = "select * from SanPham where MaSanPham = '" + masp+"'";
            DataTable dt = db.DataReader(query);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("ERRORs", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataRow dataRow = dt.Rows[0];
            string hangsx = dataRow["HangSX"].ToString();
            string phanloai = dataRow["PhanLoai"].ToString();
            string mota = dataRow["MoTa"].ToString();
            string tonkho = dataRow["TonKho"].ToString();

            labelHangSP.Text = hangsx;
            labelLoaiSP.Text = phanloai;
            labelTonKho.Text = tonkho;
            txtMoTaSP.Text = mota;
            txtMoTaSP.ReadOnly = true;
            txtMoTaSP.TabStop = false;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ChiTietSanPhamView_Load(object sender, EventArgs e)
        {
            this.Size = new Size(600, 400);
            CenterToScreen();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(soLuongUpDown.Value > 0 )
            {
                //them vao gio hang

                MessageBox.Show($"Bạn đã thêm sản phẩm {tensp} với số lượng {soLuongUpDown.Value} vào giỏ hàng !\n Hãy kiểm tra giỏ hàng nhé !", "Thông báo", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Bạn chưa thay đổi số lượng sản phẩm!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
