using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemNet
{

    public partial class Order : Form

    {
        DatabaseConnection dbCon = new DatabaseConnection();
        public int sttMayTinh,tam3;
        public string manv;
        public string tam1, tam2;

        public Order()
        {
            InitializeComponent();
        }

        public Order(int stt, string nv)
        {
            InitializeComponent();
            sttMayTinh = stt;
            manv = nv;
            HienThiAll(stt);


        }

        public void HienThiAll(int stt)
        {
            comboBox1.SelectedIndex = 0;
            int ss1 = (stt / 9)+1;
            int ss2 = (stt % 9);
            int socuoicung = ( ss1*100 + (ss2));
            label1.Text = "Máy tính số: " + socuoicung.ToString();

            string s = "select dbo.KiemTraTinhTrangMayTinh(@stt);";
            SqlParameter[] parameters =
            {
                new SqlParameter("@stt", stt)
            };
            DataTable dt = dbCon.GetData(s, parameters);
            if (dt.Rows[0][0].ToString() == "ChuaSuDung")
            {
                //setup time bat dau va ket thuc
                DateTime now = DateTime.Now;
                string formattedDate = now.ToString("yyyy-MM-dd HH:mm:ss");
                label3.Text = "Giờ bắt đầu:" + formattedDate;
                label4.Text = "Giờ kết thúc:" + formattedDate;
                dataGridView1.DataSource = null;

            }
            else
            if (dt.Rows[0][0].ToString() == "DangSuDung")
            {
                //tra ve thoi gian bat dau va ket thuc
                string s1 = "exec ThoiGian @stt;";
                SqlParameter[] parameters1 =
                {
                    new SqlParameter("@stt", stt)
                };
                DataTable dt1 = dbCon.GetData(s1, parameters1);
                label3.Text = "Giờ bắt đầu:" + dt1.Rows[0]["GioBatDau"].ToString();
                label4.Text = "Giờ kết thúc:" + dt1.Rows[0]["GioKetThuc"].ToString();

                //tim ma dich vu may tinh dang su dung
                string s2 = "select * from dbo.TimMaDichVu(@timma);";
                SqlParameter[] parameters2 =
                {
                    new SqlParameter("@timma", sttMayTinh)
                };
                DataTable dt2 = dbCon.GetData(s2, parameters2);
                string madichvu = dt2.Rows[0]["MaDH"].ToString();

                hienthidata(madichvu);
            }
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Order_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtTien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số tiền nạp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double tien;
            int soPhut;

            if (double.TryParse(txtTien.Text, out tien))
            {
                soPhut = (int)(tien / 100);
                MessageBox.Show("Bạn mua " + soPhut + " phút","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Giá trị không hợp lệ.\nHệ thống đã gán = 0.","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtTien.Text = "";
                return;
            }

            //Kiem tra tinh trang may tinh
            int SoPhut = (int)(tien / 100);
            string s = "select dbo.KiemTraTinhTrangMayTinh(@stt);";
            SqlParameter[] parameters =
            {
                new SqlParameter("@stt", sttMayTinh)
            };
            DataTable dt = dbCon.GetData(s, parameters);

            //Neu chua su dung thi nap tien lan dau
            if (dt.Rows[0][0].ToString() == "ChuaSuDung")
            {
                DateTime now = DateTime.Now;
                string formattedDate = now.ToString("yyyy-MM-dd HH:mm:ss");
                string s1 = "exec NapTienLanDau @stt,@sophut,@time,@manv;";
                SqlParameter[] parameters1 =
                {
                    new SqlParameter("@stt", sttMayTinh),
                    new SqlParameter("@sophut", SoPhut),
                    
                    new SqlParameter("@time", formattedDate),
                    new SqlParameter("@manv", manv)
                };
                DataTable dt1 = dbCon.GetData(s1, parameters1);
                HienThiAll(sttMayTinh);
                MessageBox.Show("Bắt đầu sử dụng máy tính thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }

            //Neu dang su dung thi gia han them thoi gian
            else
            {
                string s2 = "exec GiaHanMayTinh @stt,@sophut;";
                SqlParameter[] parameters2 =
                {
                    new SqlParameter("@stt", sttMayTinh),
                    new SqlParameter("@sophut", SoPhut)
                };
                DataTable dt2 = dbCon.GetData(s2, parameters2);
                HienThiAll(sttMayTinh);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn hủy bàn này không?",   // nội dung
                    "Xác nhận hủy",                               // tiêu đề
                    MessageBoxButtons.YesNo,                      // nút Yes/No
                    MessageBoxIcon.Question                       // icon dấu hỏi
            );

            if (result == DialogResult.Yes)
            {
                string s1 = "select * from dbo.TimMaDichVu(@timma);";
                SqlParameter[] parameters1 =
                {
                    new SqlParameter("@timma", sttMayTinh)
                };
                DataTable dt1 = dbCon.GetData(s1, parameters1);
                string madichvu = dt1.Rows[0][0].ToString();
                string s = "exec HuyBan @stt,@madv;";
                SqlParameter[] parameters =
                {
                new SqlParameter("@stt", sttMayTinh),
                new SqlParameter("@madv", madichvu)
            };
                DataTable dt = dbCon.GetData(s, parameters);
                HienThiAll(sttMayTinh);
                MessageBox.Show("Đã hủy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Hủy bỏ thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string s = "select * from dbo.LayTenTaiKhoan (@manv);";
            SqlParameter[] parameters =
            {
                new SqlParameter("@manv", manv)
            };
            DataTable dt = dbCon.GetData(s, parameters);
            string username = dt.Rows[0][0].ToString();
            Staff staff = new Staff(username);
            staff.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void hienthidata(string madichvu)
        {
            string s = "select * from dbo.DanhsachDichVuThem(@madv);";
            SqlParameter[] parameters =
            {
                new SqlParameter("@madv", madichvu)
            };
            DataTable dt = dbCon.GetData(s, parameters);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "select dbo.KiemTraTinhTrangMayTinh(@stt);";
            SqlParameter[] parameters =
            {
                new SqlParameter("@stt",sttMayTinh)
            };
            DataTable dt = dbCon.GetData(s, parameters);

            if (dt.Rows[0][0].ToString() == "ChuaSuDung")
            {
                MessageBox.Show("Máy tính chưa được sử dụng, không thể thêm dịch vụ đi kèm!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string s1 = "select * from dbo.TimMaDichVu(@timma);";
                SqlParameter[] parameters1 =
                {
                    new SqlParameter("@timma", sttMayTinh)
                };
                DataTable dt1 = dbCon.GetData(s1, parameters1);
                string madichvu = dt1.Rows[0][0].ToString();
                string tenma = null;
                if (comboBox1.SelectedItem != null) 
                {
                    tenma = comboBox1.SelectedItem.ToString();
                }
          
                int slma = int.TryParse(txtMonAn.Text, out int value1) ? value1 : 0;
                
                if (slma > 0 && tenma != null)
                {
                    string s2 = "exec ThemDichVuKhac @stt,@madv,@tenma,@slma;";
                    SqlParameter[] parameters2 =
                    {
                        new SqlParameter("@stt", sttMayTinh),
                        new SqlParameter("@madv", madichvu),
                        new SqlParameter("@tenma", tenma),
                        new SqlParameter("@slma", slma)
                    };
                    DataTable dt2 = dbCon.GetData(s2, parameters2);
                    txtMonAn.Text = "";
                }
                
                
                hienthidata(madichvu);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //tim ma dich vu
            string s2 = "select * from dbo.TimMaDichVu(@timma);";
            SqlParameter[] parameters2 =
            {
                    new SqlParameter("@timma", sttMayTinh)
                };
            DataTable dt2 = dbCon.GetData(s2, parameters2);
            string madichvu = dt2.Rows[0]["MaDH"].ToString();

            //tinh tien 
            string s = "select dbo.TinhTongTienHoaDon(@madv) as TongTien;";
            SqlParameter[] parameters =
            {
                new SqlParameter("@madv", madichvu)
            };
            DataTable dt = dbCon.GetData(s, parameters);

            int tongTien = Convert.ToInt32(dt.Rows[0]["TongTien"]);
            MessageBox.Show("Tổng tiền hóa đơn: " + tongTien.ToString() + " VND", "Thông báo");

            ///luu hoa don
            string s00 = "select * from dbo.ChiTietDonHang(@madh);";
            SqlParameter[] parameters00 =
            {
                new SqlParameter("@madh", madichvu)
            };
            DataTable dt00 = dbCon.GetData(s00, parameters00);
            string bill = "===== HÓA ĐƠN THANH TOÁN =====\n";

            foreach (DataRow row in dt00.Rows)
            {
                string tenDV = row["TenSanPham"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                int Gia = Convert.ToInt32(row["Gia"]);

                bill += $"{tenDV} - SL: {soLuong}\n";
            }

            bill += "===============================\n";
            bill += "Cảm ơn quý khách!";

            string s01 ="exec TaoHoaDon @madv,@chitiet,@tongtien,@manv;";
            SqlParameter[] parameters01 =
            {
                new SqlParameter("@madv", madichvu),
                new SqlParameter("@chitiet", bill),
                new SqlParameter("@tongtien", tongTien),
                new SqlParameter("@manv", manv)
            };
            DataTable dt01 = dbCon.GetData(s01, parameters01);

            //string s02 = "exec LichSuDonHang @matruyvan,@manv,@tongtien;";
            //SqlParameter[] parameters02 =
            //{
            //    new SqlParameter("@matruyvan", madichvu),
            //    new SqlParameter("@manv", manv),
            //    new SqlParameter("@tongtien", tongTien)
             
            //};
            //DataTable dt02 = dbCon.GetData(s02, parameters02);


            //string s1 = "select * from dbo.TimMaDichVu(@timma);";
            //SqlParameter[] parameters1 =
            //{
            //        new SqlParameter("@timma", sttMayTinh)
            //    };
            //DataTable dt1 = dbCon.GetData(s1, parameters1);
            //string madichvu = dt1.Rows[0][0].ToString();
            string s3 = "exec HuyBan @stt,@madv;";
            SqlParameter[] parameters4 =
            {
                new SqlParameter("@stt", sttMayTinh),
                new SqlParameter("@madv", madichvu)
            };
            DataTable dt0 = dbCon.GetData(s3, parameters4);
            HienThiAll(sttMayTinh);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "select * from dbo.TimMaDichVu(@timma);";
            SqlParameter[] parameters =
            {
                new SqlParameter("@timma", sttMayTinh)
            };
            DataTable dt = dbCon.GetData(s, parameters);


            string tamdh = dt.Rows[0]["MaDH"].ToString();
            string s1 = "exec CapNhatSanPham @madh,@ten,@sl";
            SqlParameter[] parameters1 =
            {
                new SqlParameter("@madh", tamdh),
                new SqlParameter("@ten", comboBox1.SelectedItem.ToString()),
                new SqlParameter("@sl", txtMonAn.Text)
            };
            DataTable dt1 = dbCon.GetData(s1, parameters1);
            hienthidata(tamdh);
            txtMonAn.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s1 = "select * from dbo.TimMaDichVu(@timma);";
            SqlParameter[] parameters1 =
            {
                new SqlParameter("@timma", sttMayTinh)
            };
            DataTable dt1 = dbCon.GetData(s1, parameters1);
            tam1 = dt1.Rows[0]["MaDH"].ToString();
            tam2 = comboBox1.SelectedItem.ToString();
            tam3 = int.TryParse(txtMonAn.Text, out int value1) ? value1 : 0;
            string s = "exec XoaDuLieu @tam1,@tam2,@tam3;";
            SqlParameter[] parameters =
            {
                new SqlParameter("@tam1", tam1),
                new SqlParameter("@tam2", tam2),
                new SqlParameter("@tam3", tam3)
            };
            DataTable dt = dbCon.GetData(s, parameters);
            hienthidata(tam1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // kiểm tra không chọn header
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells["TenSanPham"].Value.ToString();
                txtMonAn.Text = row.Cells["SoLuong"].Value.ToString();
            }
        }
    }
}
