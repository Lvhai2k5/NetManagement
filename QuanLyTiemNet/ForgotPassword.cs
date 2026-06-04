using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemNet
{
    public partial class ForgotPassword : Form
    {
        DatabaseConnection dbCon = new DatabaseConnection();
        public ForgotPassword()
        {
            InitializeComponent();
        }

   
        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            txtsdt.Text = "Vui lòng mã nhân viên";
            txtsdt.ForeColor = Color.Gray;
            txtsdt.Font = new Font("Times New Roman", 17, FontStyle.Italic);
        }

        private void btnBackLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void txtsdt_Enter(object sender, EventArgs e)
        {
            if (txtsdt .Text == "Vui lòng mã nhân viên")
            {
                txtsdt.Text = "";
                txtsdt.ForeColor = Color.Black;
            }
        }

        private void txtsdt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtsdt.Text))
            {
                txtsdt.Text = "Vui lòng mã nhân viên";
                txtsdt.ForeColor = Color.Gray;
            }
        }

        private void txtsdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReUse_Click(object sender, EventArgs e)
        {
            if (txtsdt.Text == "Vui lòng mã nhân viên" || string.IsNullOrWhiteSpace(txtsdt.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string user = txtsdt.Text;
            string s = "select * from dbo.QuenMatKhau (@manv)";
            SqlParameter[] parameters =
            {
                   new SqlParameter("@manv", user)
            };
            DataTable dataTable = dbCon.GetData(s, parameters);
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Mã nhân viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string newPassword = dataTable.Rows[0]["MatKhau"].ToString();
                MessageBox.Show($"Mật khẩu của bạn là: {newPassword}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login login = new Login();
                login.Show();
                this.Hide();



            }
        }
    }
}
