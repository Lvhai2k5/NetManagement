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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyTiemNet
{
    public partial class Payment : Form
    {
        DatabaseConnection connection = new DatabaseConnection();
        public DataTable dt;
        public Payment()
        {
            InitializeComponent();
            loadForm();
        }

        public Payment(string sdt)
        {
            InitializeComponent();
            loadForm();
            
        }
        public Payment(DataTable dataTable)
        {
            InitializeComponent();
            dt=dataTable;
            dataGridView.DataSource = dt;
        }

      
       
        public void loadForm()
        {
            string s = "select * from view_tradulieu;";
            DataTable dataTable = connection.GetData(s);
            dataGridView.DataSource= dataTable;
        }
        private void Payment_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {

        }
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string sql = "select * from dbo.LocDuLieu(@ngay);";
            SqlParameter p = new SqlParameter("@ngay", dateTimePicker1.Value.Date);
            DataTable dt = connection.GetData(sql, p);
            dataGridView.DataSource = dt;
        }
    }
}
