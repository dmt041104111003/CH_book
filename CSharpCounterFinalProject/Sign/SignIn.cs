using CSharpCounterFinalProject.ViewCustomer;
using CSharpCounterFinalProject.ViewNguoiMua;
using System;
using System.Data;
using System.Windows.Forms;

namespace CSharpCounterFinalProject.Sign
{
    public partial class SignIn : Form
    {
        // Declare and constructor global variable in class to use DataBaseProcess
        Classes.DataBaseProcess dtBase = new Classes.DataBaseProcess();
        public SignIn()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void BtnHuyClick(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnDangNhapCkick(object sender, EventArgs e)
        {
            string username = txtName.Text;
            string password = txtPassword.Text;
            if(username == "admin" && password == "admin")
            {
                try
                {
                    string sql = "SELECT * FROM customer WHERE userName = N'" + username + "' AND passWord = N'" + password + "'";
                    dtBase.DataReader(sql);
                    MessageBox.Show("Đăng nhập thành công!");
                    var childView = new HomeFrm();
                    childView.Name = username;
                    childView.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thông tin đăng nhập sai!");
                }
            }else
            {
                DataTable dataTable = new DataTable();
                string sql = "SELECT * FROM customer WHERE userName = N'" + username + "' AND passWord = N'" + password + "'";
                dataTable = dtBase.DataReader(sql);
                string name = dataTable.Rows[0]["FullName"].ToString();
                if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    
                    HomeView home = new HomeView(name);
                    this.Hide();
                    home.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập sai!");
                    return;
                }
            }  
        }

        private void BtnSignUpClick(object sender, EventArgs e)
        {
            var childView = new SignUp();
            childView.Show();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }
    }
}
