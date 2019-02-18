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

namespace QuanLyGiangDuong
{
    public partial class DangNhap : Form
    {
        private DataProcess dp = new DataProcess();
        public string authorize = "";

        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            DataTable dtDN = dp.SelectTable("Select * from Users where UserName = '" + txtTenDN.Text + "' and Pass ='" + txtMK.Text + "'");
            if (dtDN.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập vào hệ thống !", "Thông báo !");
                authorize = dtDN.Rows[0]["ChucVu"].ToString();
                this.Close();

            }
            else
            {
                MessageBox.Show("Lỗi đăng nhập");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            dp.OpenConnect();
        }
    }
    
}
