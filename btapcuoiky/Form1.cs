using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btapcuoiky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Gán sự kiện click cho các nút (nếu bạn chưa double click trong designer)
            //btnSetup.Click += BtnSetup_Click;
            //btnExit.Click += BtnExit_Click;
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            // Ẩn Form 1 và mở Form 2
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();

            // Khi Form 2 (hoặc chuỗi Form 2->3) đóng hoàn toàn, hiện lại Form 1
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn muốn thoát game?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Tắt toàn bộ game
            }
            // Nếu chọn No thì hộp thoại tự tắt, không làm gì thêm
        }
    }
}
