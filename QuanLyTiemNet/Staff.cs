using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemNet
{
    public partial class Staff : Form
    {
        DatabaseConnection dbCon = new DatabaseConnection();
        public string masonv;
        public Staff()
        {
            InitializeComponent();
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
            setToaDo();
            loadComputer();
        }

        public Staff(string user)
        {
            InitializeComponent();
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
            setToaDo();
            HienThiThongTin(user);
            loadComputer();
        }

        public void loadComputer()
        {
            string s = "select * from view_TrangThaiMayTinh";
            DataTable dt = dbCon.GetData(s);
            foreach (DataRow row in dt.Rows)
            {
                int stt = Convert.ToInt32(row["MaMayTinh"]);
                string trangthai = row["TrangThai"].ToString();

                // Tìm button theo tên, tìm cả trong các container con
                Button btn = this.Controls.Find("button" + stt, true).FirstOrDefault() as Button;

                if (btn != null)
                {
                    if (trangthai == "DangSuDung")
                        btn.BackColor = Color.Red;
                    else if (trangthai == "ChuaSuDung")
                        btn.BackColor = Color.Green;
                }
            }
        }

        public void setToaDo()
        {
            button1.Location = new Point(36, 28);
            button10.Location = new Point(36, 28);
            button19.Location = new Point(36, 28);
            button28.Location = new Point(36, 28);
            button37.Location = new Point(36, 28);
            button2.Location = new Point(236, 28);
            button11.Location = new Point(236, 28);
            button20.Location = new Point(236, 28);
            button29.Location = new Point(236, 28);
            button38.Location = new Point(236, 28);
            button3.Location = new Point(436, 28);
            button12.Location = new Point(436, 28);
            button21.Location = new Point(436, 28);
            button30.Location = new Point(436, 28);
            button39.Location = new Point(436, 28);
            button4.Location = new Point(36,168);
            button13.Location = new Point(36, 168);
            button22.Location = new Point(36, 168);
            button31.Location = new Point(36, 168);
            button40.Location = new Point(36, 168);
            button5.Location = new Point(236, 168);
            button14.Location = new Point(236, 168);
            button23.Location = new Point(236, 168);
            button32.Location = new Point(236, 168);
            button41.Location = new Point(236, 168);
            button6.Location = new Point(436, 168);
            button15.Location = new Point(436, 168);
            button24.Location = new Point(436, 168);
            button33.Location = new Point(436, 168);
            button42.Location = new Point(436, 168);
            button7.Location = new Point(36, 308);
            button16.Location = new Point(36, 308);
            button25.Location = new Point(36, 308);
            button34.Location = new Point(36, 308);
            button43.Location = new Point(36, 308);
            button8.Location = new Point(236, 308);
            button17.Location = new Point(236, 308);
            button26.Location = new Point(236, 308);
            button35.Location = new Point(236, 308);
            button44.Location = new Point(236, 308);
            button9.Location = new Point(436, 308);
            button18.Location = new Point(436, 308);
            button27.Location = new Point(436, 308);
            button36.Location = new Point(436, 308);
            button45.Location = new Point(436, 308);

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tab = sender as TabControl;
            Graphics g = e.Graphics;
            Brush textBrush;

            Rectangle tabBounds = tab.GetTabRect(e.Index);
            string tabText = tab.TabPages[e.Index].Text;

            // Danh sách màu cho từng tab
            Color[] colors = { Color.LightBlue, Color.LightYellow, Color.Pink, Color.Lavender, Color.DarkGray };
            Color backColor = colors[e.Index % colors.Length];

            // Nếu tab đang được chọn
            if (e.State == DrawItemState.Selected)
            {
                g.FillRectangle(new SolidBrush(backColor), tabBounds);
                g.DrawRectangle(Pens.Black, tabBounds); // viền đen
                textBrush = Brushes.DarkBlue;
            }
            else
            {
                g.FillRectangle(new SolidBrush(backColor), tabBounds);
                textBrush = Brushes.Black;
            }

            // Vẽ chữ
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(tabText, e.Font, textBrush, tabBounds, sf);
        }

        public void HienThiThongTin(string sdt)
        {
            string s = "exec LayThongTin @sdt";
            SqlParameter[] parameters =
            {
                   new SqlParameter("@sdt", sdt)
            };
            DataTable dt = dbCon.GetData(s, parameters);
            string tenNV = dt.Rows[0]["HoVaTen"].ToString();
            string sdtNv = dt.Rows[0]["SoDienThoai"].ToString();
            string maNV = dt.Rows[0]["MaNguoiDung"].ToString();
            masonv= maNV;
            label.Text = tenNV+"\n" + sdtNv+"\nPhục Vụ"+"\n"+maNV;
            label.Font = new Font("Times New Roman", 16, FontStyle.Regular);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button48_Click(object sender, EventArgs e)
        {
            Login login= new Login();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6); 
                int so = int.Parse(number);
                Order order = new Order(so,masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so,masonv);
                order.Show();
                this.Hide();
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string tenButton = btn.Name;
                string number = tenButton.Substring(6);
                int so = int.Parse(number);
                Order order = new Order(so, masonv);
                order.Show();
                this.Hide();
            }
        }

        private void btnKhoiDong_Click(object sender, EventArgs e)
        {
            string mamaytinh = txtRestart.Text.Trim();
            if (string.IsNullOrEmpty(mamaytinh)) return;

            int so = int.Parse(mamaytinh);
            int tam = ((so / 100) - 1) * 9 + (so % 100);  // mã máy tính

            // Lấy số phút còn lại
            string st = "select * from dbo.KhoiDongLaiMayTinh(@tam);";
            SqlParameter[] parameters0 =
            {
            new SqlParameter("@tam", tam)
            };
            DataTable dt0 = dbCon.GetData(st, parameters0);
            int soPhut = Convert.ToInt32(dt0.Rows[0]["SoPhut"]);

            if (soPhut == 0)
            {
                return;
            }
            else
            {
                // Thực hiện tái khởi động
                string st1 = "exec TaiKhoiDong @tam;";
                SqlParameter[] parameters1 =
                {
                new SqlParameter("@tam", tam)
                };
                dbCon.GetData(st1, parameters1);

                // Kiểm tra trạng thái máy
                string s = "select dbo.KiemTraTinhTrangMayTinh(@stt);";
                SqlParameter[] parameters =
                {
                new SqlParameter("@stt", tam)
                };
                DataTable dt = dbCon.GetData(s, parameters);

                if (dt.Rows[0][0].ToString() == "ChuaSuDung")
                {
                    DateTime now = DateTime.Now;
                    string s1 = "exec NapTienLanDau @stt,@sophut,@time,@manv;";
                    SqlParameter[] parameters22 =
                    {
                    new SqlParameter("@stt", tam),      
                    new SqlParameter("@sophut", soPhut),
                    new SqlParameter("@time", now),     
                    new SqlParameter("@manv", masonv)   
                    };
                    dbCon.GetData(s1, parameters22);

                    loadComputer();
                    MessageBox.Show("Khởi động lại máy tính thành công!");
                }

                txtRestart.Text = "";
            }
        }



        private void btnBlock_Click(object sender, EventArgs e)
        {
            if (txtSuspend.Text == null || txtSuspend.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã máy tính cần khóa");
                return;
            }
            string mamaytinh = txtSuspend.Text;
            int so = int.Parse(mamaytinh);
            int tam = ((so / 100) - 1) * 9 + (so % 100);
            string s = "select * from dbo.SoPhutConLai(@so)";
            SqlParameter[] parameters =
            {
                   new SqlParameter("@so", tam)
            };
            DataTable dt = dbCon.GetData(s, parameters);
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Mã máy tính không tồn tại");
            }
            else
            {
                int sophut = Convert.ToInt32(dt.Rows[0]["SoPhut"]);
                if (sophut > 0)
                {

                    string s1 = "exec CapNhatDuLieu @tam,@sophut;";
                    SqlParameter[] parameters1 =
                    {
                        new SqlParameter("@tam", tam),
                        new SqlParameter("@sophut", sophut)
                    };
                    DataTable dt1 = dbCon.GetData(s1, parameters1);
                    string s2 = "select * from dbo.TimMaDichVu(@timma);";
                    SqlParameter[] parameters2 =
                    {
                    new SqlParameter("@timma", tam)
                    };
                    DataTable dt2 = dbCon.GetData(s2, parameters2);
                    string madichvu = dt2.Rows[0][0].ToString();
                    string s3 = "exec HuyBan @stt,@madv;";
                    SqlParameter[] parameters3 =
                    {
                    new SqlParameter("@stt", tam),
                    new SqlParameter("@madv", madichvu)
                    };
                    DataTable dt3 = dbCon.GetData(s3, parameters3);

                    loadComputer();
                }
                else
                {
                    MessageBox.Show("Máy tính chưa được sử dụng, không thể khóa");
                }
            }
            txtSuspend.Text = "";
        }

        
        private void btnLichSuDonHang_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();

        }

        private void txtRestart_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
