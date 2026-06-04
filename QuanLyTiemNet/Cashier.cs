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
    public partial class Cashier : Form
    {
        DatabaseConnection dbCon = new DatabaseConnection();
        public String sodienthoai;
        public Cashier()
        {
            InitializeComponent();
        }

        public Cashier(string sdt)
        {
            InitializeComponent();
            HienThiThongTin(sdt);
            Payment payment = new Payment(sodienthoai);
            AddFormToPanel(payment);
            
        }

        public void LayMaDichVu(string st)
        {
            
            DatabaseConnection databaseConnection = new DatabaseConnection();
            string s = "select * from dbo.TimKiemDonHang(@madv);";
            SqlParameter[] parameters =
            {
                new SqlParameter("@madv",st)
            };
            DataTable dataTable = databaseConnection.GetData(s, parameters);
            Payment payment = new Payment(dataTable);
            AddFormToPanel(payment);
            txtSearch.Text = "";
        }
        public void HienThiThongTin(string sdt)
        {
            sodienthoai = sdt;
            string s = "exec LayThongTin @sodienthoai";
            SqlParameter p = new SqlParameter("@sodienthoai", sodienthoai);
            DataTable dt = dbCon.GetData(s, p);
            string hoten = dt.Rows[0]["HoVaTen"].ToString();
            string vaitro = dt.Rows[0]["VaiTro"].ToString();
            string ma = dt.Rows[0]["MaNguoiDung"].ToString();
            label1.Text = hoten + "\n" + vaitro + "\n" + ma;
        }

        private void Cashier_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddFormToPanel(Form frm)
        {
            panel.Controls.Clear();
            frm.TopLevel = false;          
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;     
            panel.Controls.Add(frm);
            panel.Tag = frm;
            frm.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LayMaDichVu(txtSearch.Text);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
