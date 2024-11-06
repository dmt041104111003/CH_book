using CSharpCounterFinalProject.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CSharpCounterFinalProject.ViewCustomer
{
    public partial class CartCus : Form
    {
        List<Item> products;
        string UserName;
        public CartCus(string lableName)
        {
            InitializeComponent();
            CenterToScreen();
            labelNameCart.Text = lableName;
        }

        private void CartCus_Load(object sender, EventArgs e)
        {
            List<Item> items = GetProductsFromDatabase(6);
            UpdateTableLayoutPanel(items);
            UserName = labelNameCart.Text;
        }

        // Phương thức để cập nhật TableLayoutPanel với dữ liệu sản phẩm
        void UpdateTableLayoutPanel(List<Item> products)
        {
            mainTableLayoutPanel.Controls.Clear();
            // Định dạng `TableLayoutPanel` chính
            mainTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F)); // 3 cột
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F)); // 2 hàng
            //mainTableLayoutPanel.Anchor = AnchorStyles.None;

            // Lặp qua danh sách sản phẩm
            int productIndex = 0;
            foreach (var product in products)
            {
                // Tạo `TableLayoutPanel` con với 3 hàng và 1 cột
                TableLayoutPanel productLayoutPanel = new TableLayoutPanel();
                productLayoutPanel.RowCount = 3;
                productLayoutPanel.ColumnCount = 1;
                productLayoutPanel.Dock = DockStyle.Fill;
                productLayoutPanel.Tag = product;
                productLayoutPanel.Click += ProductPanel_Click; //---fix k nhấn đc ?

                


                // PictureBox
                PictureBox pictureBox = new PictureBox();
                string fileImage = product.Image.ToString();
                string imagePath = System.Windows.Forms.Application.StartupPath + "\\Items\\" + fileImage;

                if (File.Exists(imagePath))
                {
                    pictureBox.Image = System.Drawing.Image.FromFile(imagePath);
                }
                else
                {
                    // Xử lý lỗi, ví dụ: hiển thị thông báo hoặc thực hiện một hành động khác.
                }
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Size = new Size(130, 130);
                //pictureBox.Dock = DockStyle.Top;
                pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                // nameLabel
                Label nameLabel = new Label();
                nameLabel.Text = product.Name;
                nameLabel.TextAlign = ContentAlignment.MiddleCenter; // Đặt vị trí giữa cho Label
                nameLabel.ForeColor = ColorTranslator.FromHtml("#609966");
                nameLabel.Dock = DockStyle.Bottom;

                // priceLabel
                Label priceLabel = new Label();
                priceLabel.Text = product.Price.ToString() + "vnđ";
                priceLabel.TextAlign = ContentAlignment.MiddleCenter; // Đặt vị trí giữa cho Label
                priceLabel.Dock = DockStyle.Bottom;
                priceLabel.ForeColor = ColorTranslator.FromHtml("#609966");


                // Thêm các điều khiển vào `TableLayoutPanel` con
                productLayoutPanel.Controls.Add(pictureBox, 0, 0);
                productLayoutPanel.Controls.Add(nameLabel, 0, 1);
                productLayoutPanel.Controls.Add(priceLabel, 0, 2);

                // Thêm `TableLayoutPanel` con vào `TableLayoutPanel` chính
                mainTableLayoutPanel.Controls.Add(productLayoutPanel, productIndex % 3, productIndex / 3);
                productIndex++;



                //thêm skien click để đảm bảo nhấn vào đâu thì cũng kích hoạt sự kiện
                pictureBox.Click += ProductPanel_Click;
                nameLabel.Click += ProductPanel_Click;
                priceLabel.Click += ProductPanel_Click;
            }
        }

        // Hàm để lấy dữ liệu sản phẩm từ cơ sở dữ liệu
        List<Item> GetProductsFromDatabase(int limit)
        {
            List<Item> items = new List<Item>();
            string connectionString = Classes.DataBaseProcess.strConnect;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TOP " + limit + " Item_ID, ItemName, Price, Quantity, Image FROM Item WHERE Quantity > 0"; // Thay thế bằng tên bảng và cột tương ứng
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item();
                            item.Name = reader["ItemName"].ToString(); 
                            item.Price = (int)reader["Price"];
                            item.Image = reader["Image"].ToString();
                            item.Item_ID = int.Parse(reader["Item_ID"].ToString());
                            item.Quantity = int.Parse(reader["Quantity"].ToString());
                            items.Add(item);
                        }
                    }
                }
            }
            return items;
        }

        private void ProductPanel_Click(object sender, EventArgs e)
        {
            // Ép kiểu `sender` thành `Control`
            Control control = sender as Control;
            if (control == null)
                return;

            // Lấy `TableLayoutPanel` cha của `control`
            TableLayoutPanel productPanel = control.Parent as TableLayoutPanel;
            if (productPanel == null)
                return;

            // Tiếp tục xử lý với productPanel
            PictureBox pictureBox = productPanel.Controls[0] as PictureBox;
            Label nameLabel = productPanel.Controls[1] as Label;
            Label priceLabel = productPanel.Controls[2] as Label;

            // Kiểm tra các thành phần con để tránh lỗi null
            if (nameLabel == null || priceLabel == null || pictureBox == null)
                return;

            // Lấy dữ liệu từ các điều khiển và sử dụng nó
            string productName = nameLabel.Text;
            string price = priceLabel.Text;

            // Lấy đối tượng `Item` từ thuộc tính Tag
            Item product = productPanel.Tag as Item;
            if (product == null)
                return;

            // Lấy đường dẫn ảnh từ product
            string fileImage = product.Image.ToString();
            string imagePath = System.Windows.Forms.Application.StartupPath + "\\Items\\" + fileImage;
            string itemID = product.Item_ID.ToString();

            var children = new DetailItemCus(itemID, productName, price, imagePath);
            children.Show();
        }



        private void btnSearchCus_Click(object sender, EventArgs e)
        {
            string sql = "";
            string name = txtSearchItemCus.Text;
            int quantity = (int)txtQuantityCus.Value;
            if (quantity > 0)
            {
                sql = "SELECT TOP 6 Item_ID, ItemName, Price, Quantity, Image " +
                             "FROM Item  " +
                             "WHERE ItemName LIKE (N'%" + name + "%') AND Quantity > " + quantity;
            }
            else
            {
                sql = "SELECT TOP 6 Item_ID, ItemName, Price, Quantity, Image " +
                             "FROM Item  " +
                             "WHERE ItemName LIKE (N'%" + name + "%') AND Quantity > 0";
            }

            List<Item> items = new List<Item>();
            string connectionString = Classes.DataBaseProcess.strConnect;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item();
                            item.Name = reader["ItemName"].ToString();
                            item.Price = (int)reader["Price"];
                            item.Image = reader["Image"].ToString();
                            item.Item_ID = int.Parse(reader["Item_ID"].ToString());
                            item.Quantity = int.Parse(reader["Quantity"].ToString());
                            items.Add(item);
                        }
                    }
                }
            }
            UpdateTableLayoutPanel(items);
        }

        private void btnLookCart_Click(object sender, EventArgs e) //xem gio hang
        {
            var child = new ListItemCus(labelNameCart.Text);
            child.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var children = new HomeCustomerView(UserName);
            children.Show();
        }

        private void mainTableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
