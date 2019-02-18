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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void MenuQLHT_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            DangNhap frmDn = new DangNhap();
            frmDn.ShowDialog();
            if (frmDn.authorize == "GV".ToLower())
            {
                MenuQLuser.Enabled = false;
            }
            else if (frmDn.authorize == "SV".ToLower())
            {
                MnuLich.Enabled = false;
                MnuDanhMuc.Enabled = false;
                MnuBaoCao.Enabled = false;
                MenuQLuser.Enabled = false;
            }
            else if (frmDn.authorize == "")
            {
                menuStrip1.Enabled = false;
            }
        }

        private void MenuQLuser_Click(object sender, EventArgs e)
        {
            QuanLyUsers frmQL = new QuanLyUsers();
            frmQL.ShowDialog();
        }

        private void btnLichGV_Click(object sender, EventArgs e)
        {
            new LichDay().Show();
        }
    }
}
