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
    public partial class LichDay : Form
    {
        string maLHP;
        DataProcess dp = new DataProcess();
        public LichDay()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dp.SelectTable("exec LichDayGV '" + cbMaGV.SelectedValue.ToString() + "' ,'" + cbKyHoc.SelectedValue.ToString() + "'");
            DataTable dtGV = dp.SelectTable("Select TenGV from GiangVien where MaGV='" + cbMaGV.SelectedValue.ToString() + "'");
          //  groupBox2.Text = "Lịch chi tiết của thầy/cô " + dtGV.Rows[0]["TenGV"].ToString();
        }

        private void LichDay_Load(object sender, EventArgs e)
        {
            cbMaGV.DataSource = dp.SelectTable("Select *from GiangVien");
            cbMaGV.ValueMember = "MaGV";
            cbMaGV.DisplayMember = "MaGV";


        }

        private void cbMaGV_SelectedValueChanged(object sender, EventArgs e)
        {
            cbKyHoc.DataSource = dp.SelectTable("Select DISTINCT KyHoc from LopHocPhan where MaGV ='" + cbMaGV.SelectedValue.ToString() + "'");
            cbKyHoc.ValueMember = "KyHoc";
            cbKyHoc.DisplayMember = "Kyhoc";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maLHP = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void cbKyHoc_SelectedValueChanged(object sender, EventArgs e)
        {
            cbKyHoc.DataSource = dp.SelectTable("Select DISTINCT KyHoc from LopHocPhan where MaGV ='" + cbMaGV.SelectedValue.ToString() + "'");
            cbKyHoc.ValueMember = "KyHoc";
            cbKyHoc.DisplayMember = "Kyhoc";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maLHP == "")
            {
                MessageBox.Show("Vui lòng chọn lớp học phần để xóa");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dp.UpdateData("Delete from LopHocPhan where MaLopHP = '" + maLHP + "'");
                dataGridView1.DataSource = dp.SelectTable("exec LichDayGV '" + cbMaGV.SelectedValue.ToString() + "' ,'" + cbKyHoc.SelectedValue.ToString() + "'");
            }
        }
    }
}
