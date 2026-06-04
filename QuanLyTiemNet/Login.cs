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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyTiemNet
{
    public partial class Login : Form
    {
        DatabaseConnection dbCon = new DatabaseConnection();
        public Login()
        {
            InitializeComponent();
            decorate();
        }

        public void decorate()
        {
            Custom cs = new Custom();
            cs.SetRoundedTextBox(txtUsername, 80);
            cs.SetRoundedTextBox(txtPassword, 80);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "Nhập số điện thoại";
            txtUsername.ForeColor = Color.Gray;
            txtUsername.Font = new Font("Times New Roman", 16, FontStyle.Italic);

            txtPassword.AutoSize = false;   // 🔹 tắt autosize
            txtPassword.Height = 100;        // 🔹 cho textbox cao hơn
            txtPassword.Text = "Nhập mật khẩu";
            txtPassword.ForeColor = Color.Gray;
            txtPassword.Font = new Font("Times New Roman", 16, FontStyle.Italic);
            txtPassword.UseSystemPasswordChar = false; // để placeholder hiển thị rõ
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Nhập số điện thoại")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Nhập số điện thoại";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Nhập mật khẩu")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;   // ✅ sửa: chữ đen khi nhập
                txtPassword.Font = new Font("Times New Roman", 16, FontStyle.Regular);
            }
            txtPassword.UseSystemPasswordChar = !checkBox1.Checked; // ✅ che hoặc hiện theo checkbox
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = false; // ✅ tắt che khi hiển thị placeholder
                txtPassword.Text = "Nhập mật khẩu";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.Font = new Font("Times New Roman", 16, FontStyle.Italic);
            }
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.Size = new Size(btnLogin.Width + 5, btnLogin.Height + 5);
            btnLogin.BackColor = Color.DodgerBlue;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.Size = new Size(btnLogin.Width - 5, btnLogin.Height - 5);
            btnLogin.BackColor = Color.White;
        }

        private void btnForgotPassword_MouseEnter(object sender, EventArgs e)
        {
            btnForgotPassword.Size = new Size(btnForgotPassword.Width + 5, btnForgotPassword.Height + 5);
            btnForgotPassword.BackColor = Color.DodgerBlue;
        }

        private void btnForgotPassword_MouseLeave(object sender, EventArgs e)
        {
            btnForgotPassword.Size = new Size(btnForgotPassword.Width - 5, btnForgotPassword.Height - 5);
            btnForgotPassword.BackColor = Color.White;
        }

        private void btnSignUp_MouseEnter(object sender, EventArgs e)
        {
            btnSignUp.Size = new Size(btnSignUp.Width + 5, btnSignUp.Height + 5);
            btnSignUp.BackColor = Color.DodgerBlue;
        }

        private void btnSignUp_MouseLeave(object sender, EventArgs e)
        {
            btnSignUp.Size = new Size(btnSignUp.Width - 5, btnSignUp.Height - 5);
            btnSignUp.BackColor = Color.White;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
            this.Hide();
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;
            string s = "select * from dbo.DangNhap (@username,@password)";
            SqlParameter[] parameters =
            {
                   new SqlParameter("@username", user),
                   new SqlParameter("@password", pass)
            };
            DataTable dt = dbCon.GetData(s, parameters);
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Sai số điện thoại hoặc mật khẩu");
            }
            else
            {
                string vaiTro = dt.Rows[0]["VaiTro"].ToString();
                if (vaiTro == "ChuTiem")
                {
                    Admin adminForm = new Admin();
                    adminForm.Show();
                    this.Hide();
                }
                else if (vaiTro == "PhucVu")
                {
                    Staff staffForm = new Staff(user);
                    staffForm.Show();
                    this.Hide();
                }
                else if (vaiTro == "ThuNgan")
                {
                    Cashier cashier = new Cashier(user);
                    cashier.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Vai trò không hợp lệ.");
                }
            }
        }

        private void panel_2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != "Nhập mật khẩu") // ✅ chỉ xử lý khi nhập mật khẩu thật
            {
                txtPassword.UseSystemPasswordChar = !checkBox1.Checked;
            }
        }
    }
}
