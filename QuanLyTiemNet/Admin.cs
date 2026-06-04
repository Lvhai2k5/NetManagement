using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemNet
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
           
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {

        }

        private void AddFormToPanel(Form frm)
        {
            panel2.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panel2.Controls.Add(frm);
            panel2.Tag = frm;
            frm.Show();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Login login= new Login();
            login.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOrderLog_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            AddFormToPanel(payment);
        }
    }
}
