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
    public partial class HomeView : Form
    {
        DataBaseProcess db = new DataBaseProcess();
        public HomeView(string name)
        {
            InitializeComponent();
            
            //thiet lap 1 so thuoc tinh ban dau
            label1.Text += " " + name;
            // Đặt số hàng và cột
            tableSanPhams.ColumnCount = 5;
            tableSanPhams.RowCount = 2;

            // Thiết lập kích thước cho các cột (mỗi cột rộng 161)
            for (int i = 0; i < tableSanPhams.ColumnCount; i++)
            {
                tableSanPhams.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 161));
            }

            // Thiết lập kích thước cho các hàng (mỗi hàng cao 231)
            for (int i = 0; i < tableSanPhams.RowCount; i++)
            {
                tableSanPhams.RowStyles.Add(new RowStyle(SizeType.Absolute, 231));
            }

            // Đặt kích thước tổng thể cho TableLayoutPanel
            tableSanPhams.Size = new Size(161 * tableSanPhams.ColumnCount, 231 * tableSanPhams.RowCount);

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void HomeView_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 600);
            splitContainer2.SplitterDistance = 100;
            //load san pham
            LoadCacSanPham();
            CenterToScreen();
            cbTimKiemTheo.SelectedIndex = 0;

        }

        private void LoadCacSanPham()
        {
            List<string> list = new List<string>();
            string query = "select  * from SanPham";
            DataTable dt = db.DataReader(query);
            foreach (DataRow dr in dt.Rows)
            {
               
                string linksp = dr["Anh"].ToString();
                string tensp = dr["TenSanPham"].ToString();
                string gia = dr["GiaCa"].ToString();
                string masp = dr["MaSanPham"].ToString();
               
                AddProductPanel(tableSanPhams, linksp, tensp, gia,masp);

            }


        }

        //them 1 hien thi sp
        public void AddProductPanel(TableLayoutPanel tableSanPhams, string tenfileanh, string label1Text, string label2Text,string masp)
        {
            // Tạo TableLayoutPanel nhỏ với 2 cột và 3 hàng
            TableLayoutPanel innerTable = new TableLayoutPanel
            {
                ColumnCount = 2, // Thêm cột thứ hai để chứa Label "Mua ngay"
                RowCount = 3,
                Size = new Size(161, 231)
            };

            // Cột 1 chiếm 80%, cột 2 chỉ chiếm 20%
            innerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60)); // Cột 1 (Tên sản phẩm + ảnh + giá)
            innerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40)); // Cột 2 (Mua ngay)

            innerTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 161));  // Hàng 1
            innerTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));   // Hàng 2
            innerTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));   // Hàng 3

            // Tạo PictureBox và đặt ảnh vào hàng đầu tiên của innerTable
            PictureBox pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightGray,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            // Kiểm tra và tải ảnh
            string imagePath = System.Windows.Forms.Application.StartupPath + "\\AnhSP\\" + tenfileanh;

            try
            {
                pictureBox.Image = Image.FromFile(imagePath);
            }
            catch
            {
                MessageBox.Show("Không thể tải ảnh.");
            }

            innerTable.Controls.Add(pictureBox, 0, 0);
            innerTable.SetColumnSpan(pictureBox, 2); // Gộp cột cho PictureBox

            // Tạo và thêm Label thứ nhất vào hàng thứ hai của innerTable
            Label label1 = new Label
            {
                Text = label1Text,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                BackColor = Color.LightYellow
            };
            innerTable.Controls.Add(label1, 0, 1);
            innerTable.SetColumnSpan(label1, 2); // Gộp cột cho tên sản phẩm

            // Tạo và thêm Label thứ hai vào hàng thứ ba của innerTable
            Label label2 = new Label
            {
                Text = label2Text + " VND",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                BackColor = Color.LightYellow
            };
            innerTable.Controls.Add(label2, 0, 2);

            // Thêm Label "Mua ngay" vào hàng thứ ba, cột thứ hai
            Label buyNowLabel = new Label
            {
                Text = "Mua ngay",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                ForeColor = Color.Red,
                BackColor = Color.LightYellow
            };
            buyNowLabel.Click += (sender, e) => BuyNowLabel_Click(sender, e, label1Text, label2Text, tenfileanh,masp);

            innerTable.Controls.Add(buyNowLabel, 1, 2);

            // Tạo hiệu ứng nhấp nháy
            StartBlinking(buyNowLabel);

            // Thêm innerTable vào tableSanPhams
            tableSanPhams.Controls.Add(innerTable);
        }

        private void BuyNowLabel_Click(object sender, EventArgs e, string label1Text, string label2Text, string anh,string masp)
        {
            //show ra màn hình cụ thể để thêm sp vào giỏ hàng
            ChiTietSanPhamView chitietsp = new ChiTietSanPhamView(label1Text, label2Text,anh,masp);
            chitietsp.ShowDialog();

        }

        //hieu ung nhap nhay
        private void StartBlinking(Label label)
        {
            Timer timer = new Timer
            {
                Interval = 500 // Thời gian đổi màu (500 ms = 0.5 giây)
            };

            bool isRed = true;

            timer.Tick += (s, e) =>
            {
                // Đổi màu mỗi lần Timer chạy
                label.ForeColor = isRed ? Color.Red : Color.Transparent;
                isRed = !isRed; // Đổi trạng thái màu
            };

            timer.Start();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
            switch (cbTimKiemTheo.SelectedIndex )
            {
                case 0:
                    //tim kiem theo ten sp
                    TimKiemTheoTenSp(txtTimKiem.Text);
                    break;
                case 1:
                    //tim kiem theo phân loại
                    TimKiemTheoPhanLoai(txtTimKiem.Text);
                    break;
                case 2:
                    //tk theo hãng
                    TimKiemTheoHangSX(txtTimKiem.Text);
                    break;
                case 3:
                    //tk theo a-z
                    txtTimKiem.Enabled = false;//hien ra tat ca theo thu tu tu a-z
                    TimKiemRoiSapXepAZ();
                    break;
                default:
                    MessageBox.Show("Lỗi lựa chọn tìm kiếm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

            }
        }

        private void TimKiemRoiSapXepAZ()
        {
            string query = "SELECT * FROM SanPham";
            DataTable dataTable = db.DataReader(query);

            // Kiểm tra nếu không có sản phẩm
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào trong cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            DataView dataView = new DataView(dataTable);
            dataView.Sort = "TenSanPham ASC"; // Sắp xếp theo tên sản phẩm tăng dần

            tableSanPhams.Controls.Clear();

            foreach (DataRow row in dataView.ToTable().Rows)
            {
                // Lấy thông tin sản phẩm từ row
                string tenSanPham = row["TenSanPham"].ToString();
                string giaSanPham = row["GiaCa"].ToString();
                string tenFileAnh = row["Anh"].ToString();

                string masp = row["MaSanPham"].ToString();

                // Gọi hàm AddProductPanel để thêm sản phẩm vào tableSanPhams
                AddProductPanel(tableSanPhams, tenFileAnh, tenSanPham, giaSanPham, masp);
            }
        }

        private void TimKiemTheoHangSX(string text)
        {
            if (text == "")
            {
                MessageBox.Show("Không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "select * from SanPham where Hang COLLATE Latin1_General_CI_AI LIKE N'%" + text + "%';";
            DataTable dataTable = db.DataReader(query);
            //k tìm thấy
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                //tìm thấy thì xoá bảng cũ
                tableSanPhams.Controls.Clear();
                // thêm sp mới vào

                foreach (DataRow row in dataTable.Rows)
                {
                    // Lấy thông tin sản phẩm từ row
                    string tenSanPham = row["TenSanPham"].ToString();
                    string giaSanPham = row["GiaCa"].ToString();
                    string tenFileAnh = row["Anh"].ToString();
                    string masp = row["MaSanPham"].ToString();

                    // Gọi hàm AddProductPanel để thêm sản phẩm vào tableSanPhams
                    AddProductPanel(tableSanPhams, tenFileAnh, tenSanPham, giaSanPham, masp);
                }
                MessageBox.Show("Đã tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TimKiemTheoPhanLoai(string text)
        {
            if (text == "")
            {
                MessageBox.Show("Không được để trống tên phân loại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "select * from SanPham where PhanLoai COLLATE Latin1_General_CI_AI LIKE N'%" + text + "%';";
            DataTable dataTable = db.DataReader(query);
            //k tìm thấy
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                //tìm thấy thì xoá bảng cũ
                tableSanPhams.Controls.Clear();
                // thêm sp mới vào

                foreach (DataRow row in dataTable.Rows)
                {
                    // Lấy thông tin sản phẩm từ row
                    string tenSanPham = row["TenSanPham"].ToString();
                    string giaSanPham = row["GiaCa"].ToString();
                    string tenFileAnh = row["Anh"].ToString();
                    string masp = row["MaSanPham"].ToString();

                    // Gọi hàm AddProductPanel để thêm sản phẩm vào tableSanPhams
                    AddProductPanel(tableSanPhams, tenFileAnh, tenSanPham, giaSanPham, masp);
                }
                MessageBox.Show("Đã tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TimKiemTheoTenSp(string text)
        {
            if (text == "")
            {
                MessageBox.Show("Không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "select * from SanPham where TenSanPham COLLATE Latin1_General_CI_AI LIKE N'%"+text+"%';";
            DataTable dataTable = db.DataReader(query);
            //k tìm thấy
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                //tìm thấy thì xoá bảng cũ
                tableSanPhams.Controls.Clear();
                // thêm sp mới vào

                foreach (DataRow row in dataTable.Rows)
                {
                    // Lấy thông tin sản phẩm từ row
                    string tenSanPham = row["TenSanPham"].ToString();
                    string giaSanPham = row["GiaCa"].ToString();
                    string tenFileAnh = row["Anh"].ToString();
                    string masp = row["MaSanPham"].ToString();

                    // Gọi hàm AddProductPanel để thêm sản phẩm vào tableSanPhams
                    AddProductPanel(tableSanPhams, tenFileAnh, tenSanPham, giaSanPham, masp);
                }
                MessageBox.Show("Đã tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void cbTimKiemTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbTimKiemTheo.SelectedIndex)
            {
                case 0:
                    labelNhapTK.Text = "Nhập tên sản phẩm";
                    break;
                case 1:
                    //tim kiem theo phân loại
                    labelNhapTK.Text = "Nhập phân loại";
                    break;
                case 2:
                    //tk theo hãng
                    labelNhapTK.Text = "Nhập hãng cần tìm";
                    break;
                case 3:
                    //tk theo a-z
                    txtTimKiem.Enabled = false;//hien ra tat ca theo thu tu tu a-z
                    break;
                default:
                    MessageBox.Show("Lỗi lựa chọn tìm kiếm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

            }
        }
    }
}
