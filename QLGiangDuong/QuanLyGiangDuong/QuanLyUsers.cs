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
    public partial class QuanLyUsers : Form
    {
        DataProcess db = new DataProcess();
        Common common = new Common();
        public QuanLyUsers()
        {
            InitializeComponent();
            dvgUser.DataSource = db.SelectTable("Select * from Users");
            
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try { 
            int lastrow = dvgUser.Rows.Count - 2;
            string id = dvgUser.Rows[lastrow].Cells["ID"].Value.ToString();
            string User = dvgUser.Rows[lastrow].Cells["Ten"].Value.ToString();
            string chucvu = dvgUser.Rows[lastrow].Cells["Chucvu"].Value.ToString();
            string UserName = dvgUser.Rows[lastrow].Cells["UserName"].Value.ToString();
            string Pass = dvgUser.Rows[lastrow].Cells["Pass"].Value.ToString();
            db.UpdateData("insert into Users values('" + id + "','" + User + "','" + chucvu + "','" + UserName + "','" + Pass + "')");
                }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dvgUser.DataSource = db.SelectTable("Select * from Users");
        }

        private void dvgUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            

        }
    }

}
