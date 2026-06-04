using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemNet
{
    public partial class Register : Form
    {
        DatabaseConnection dbCon = new DatabaseConnection();
        public Register()
        {
            InitializeComponent();
            decorate();
        }

        public void decorate()
        {
            Custom cs = new Custom();
            cs.SetRoundedTextBox(txtUsername, 80);
            cs.SetRoundedTextBox(txtPassword, 80);
            cs.SetRoundedTextBox(txtRole, 80);
            cs.SetRoundedTextBox(txtFullName, 80);
            label1.Text = "Họ và tên";
            label2.Text = "Số điện thoại";
            label3.Text = "Mật khẩu";
            label4.Text = "Mã chức vụ";
            label1.Font = new Font("Times New Roman", 16, FontStyle.Regular);
            label2.Font = new Font("Times New Roman", 16, FontStyle.Regular);
            label3.Font = new Font("Times New Roman", 16, FontStyle.Regular);
            label4.Font = new Font("Times New Roman", 16, FontStyle.Regular);
        }

        private void Register_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "Vui lòng nhập số điện thoại";
            txtUsername.ForeColor = Color.Gray;
            txtUsername.Font = new Font("Times New Roman", 15, FontStyle.Regular);
            txtPassword.Text = "Vui lòng nhập mật khẩu";
            txtPassword.ForeColor = Color.Gray;
            txtPassword.Font = new Font("Times New Roman", 15, FontStyle.Regular);
            txtRole.Text = "Vui lòng nhập mã chức vụ";
            txtRole.ForeColor = Color.Gray;
            txtRole.Font = new Font("Times New Roman", 15, FontStyle.Regular);
            txtFullName.Text = "Vui lòng nhập họ và tên";
            txtFullName.ForeColor = Color.Gray;
            txtFullName.Font = new Font("Times New Roman", 15, FontStyle.Regular);
        }

        private void btnBackLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Vui lòng nhập số điện thoại")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Vui lòng nhập số điện thoại";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Vui lòng nhập mật khẩu")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Vui lòng nhập mật khẩu";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void txtRole_Enter(object sender, EventArgs e)
        {
            if (txtRole.Text == "Vui lòng nhập mã chức vụ")
            {
                txtRole.Text = "";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void txtRole_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Vui lòng nhập mã chức vụ";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void btnBackLogin_MouseEnter(object sender, EventArgs e)
        {
            btnBackLogin.Size = new Size(btnBackLogin.Width + 5, btnBackLogin.Height + 5);
            btnBackLogin.BackColor = Color.DodgerBlue;
        }

        private void btnBackLogin_MouseLeave(object sender, EventArgs e)
        {
            btnBackLogin.Size = new Size(btnBackLogin.Width - 5, btnBackLogin.Height - 5);
            btnBackLogin.BackColor = Color.White;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            btnRegister.Size = new Size(btnRegister.Width + 5, btnRegister.Height + 5);
            btnRegister.BackColor = Color.DodgerBlue;
        }

        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            btnRegister.Size = new Size(btnRegister.Width - 5, btnRegister.Height - 5);
            btnRegister.BackColor = Color.White;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            string vtro = txtRole.Text;
            string hoten = txtFullName.Text;
            string s = "select * from dbo.DangNhap (@username,@password)";   //kiem tra tai khoan da ton tai chua
            SqlParameter[] parameters =
            {
                   new SqlParameter("@username", user),
                   new SqlParameter("@password", pass)
            };
            DataTable dt = dbCon.GetData(s, parameters);
            if ((dt == null || dt.Rows.Count == 0) && (vtro == "ChuTiem" || vtro == "PhucVu" || vtro == "ThuNgan"))
            {
                string s1 = "exec ThemtaiKhoan @sdt,@mk,@vaitro,@hoten;"; ///them tai khoan dang nhap
                SqlParameter[] parameters1 =
                {
                   new SqlParameter("@sdt", user),
                   new SqlParameter("@mk", pass),
                   new SqlParameter("@vaitro", vtro),
                   new SqlParameter("@hoten", hoten)
                };
                DataTable dt1 = dbCon.GetData(s1, parameters1);
                MessageBox.Show("Thêm tài khoản thành công!",
                "Thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                clear();
            }
            else
            {
                MessageBox.Show("Tài khoản của bạn đang tồn tại hoặc thông tin chưa chính xác!",
                "Cảnh báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
                clear();
            }
        }
        public void clear()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtRole.Text = "";
            txtFullName.Text = "";
        }
        private void txtRole_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFullName_Enter(object sender, EventArgs e)
        {
            if (txtFullName.Text == "Vui lòng nhập họ và tên")
            {
                txtFullName.Text = "";
                txtFullName.ForeColor = Color.Gray;
            }
        }

        private void txtFullName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                txtFullName.Text = "Vui lòng nhập mật khẩu";
                txtFullName.ForeColor = Color.Gray;
            }
        }
    }
}
