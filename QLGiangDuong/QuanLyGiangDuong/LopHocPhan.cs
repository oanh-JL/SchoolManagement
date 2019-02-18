using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGiangDuong
{
    public partial class LopHocPhan : Form
    {
        DataProcess dp = new DataProcess();
        public LopHocPhan()
        {
            InitializeComponent();
        }

        private void LopHocPhan_Load(object sender, EventArgs e)
        {
            try
            {
                cbHocKy.DataSource = dp.SelectTable("Select * from HocKy");
                cbHocKy.ValueMember = "KyHoc";
                cbHocKy.DisplayMember = "KyHoc";
                cbMaGV.DataSource = dp.SelectTable("Select * from GiangVien");
                cbMaGV.ValueMember = "MaGV";
                cbMaGV.DisplayMember = "MaGV";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
   
        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngaybd = DateTime.Parse(txtTGBD.Text);
                DateTime ngaykt = DateTime.Parse(txtTGKT.Text);
                dp.UpdateData("insert into LopHocPhan values('" + txtMaHocPhan.Text + "',N'" + txtMonHoc.Text + "','" + cbMaGV.SelectedValue.ToString() +
                    "','" + ngaybd.ToShortDateString() + "','" + ngaykt.ToShortDateString() + "','" + cbHocKy.SelectedValue.ToString() + "')");
                dp.UpdateData("insert into ChiTietLopHP values('" + txtMaHocPhan.Text + "','" + cbPhongTrong.SelectedValue.ToString() + "','" +
                    txtCaHoc.Text + "',N'" + txtThu.Text + "')");
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            try
            {
                cbPhongTrong.DataSource = null;
                cbPhongTrong.DataSource = dp.SelectTable("exec phongtrong '" + txtCaHoc.Text  + "',N'" + txtThu.Text + "','" + txtTGBD.Text + "','" + txtTGKT.Text + "'");
                cbPhongTrong.ValueMember = "MaPhong";
                cbPhongTrong.DisplayMember = "TenPhong";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
