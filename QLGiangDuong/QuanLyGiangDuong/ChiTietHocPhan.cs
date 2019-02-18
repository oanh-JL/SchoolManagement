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
    public partial class ChiTietLopHP : Form
    {
        DataProcess dp = new DataProcess();
        public ChiTietLopHP()
        {
            InitializeComponent();
        }

        private void ChiTietLopHP_Load(object sender, EventArgs e)
        {
            cbMaHP.DataSource = dp.SelectTable("Select * from LopHocPhan");
            cbMaHP.ValueMember = "MaLopHP";
            cbMaHP.DisplayMember = "MaLopHP";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            DataTable dtLGV = dp.SelectTable("exec LichGV '" + cbMaHP.SelectedValue.ToString() + "'");
            try
            {
                DateTime TGBD, TGKT;
                txtMaHP.Text = dtLGV.Rows[0]["MaLopHP"].ToString();
                txtMonHoc.Text = dtLGV.Rows[0]["MonHoc"].ToString();
                txtKhuNha.Text = dtLGV.Rows[0]["TenNha"].ToString();
                txtPhong.Text = dtLGV.Rows[0]["TenPhong"].ToString();
                txtTenGV.Text = dtLGV.Rows[0]["TenGV"].ToString();
                TGBD = DateTime.Parse(dtLGV.Rows[0]["ThoiGianBD"].ToString());
                txtTGBD.Text = TGBD.ToShortDateString();
                TGKT = DateTime.Parse(dtLGV.Rows[0]["ThoiGianKT"].ToString());
                txtTGKT.Text = TGKT.ToShortDateString();
                txtThu.Text = dtLGV.Rows[0]["Thu"].ToString();
                txtCaHoc.Text = dtLGV.Rows[0]["CaHoc"].ToString();
                txtHocKy.Text = dtLGV.Rows[0]["KyHoc"].ToString();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
