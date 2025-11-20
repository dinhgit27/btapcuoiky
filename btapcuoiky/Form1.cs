using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Lấy kích thước của GroupBox
            int groupWidth = groupBox1.Width;
            int groupHeight = groupBox1.Height;

            // Tính toán tọa độ X và Y để căn giữa
            int x = (formWidth - groupWidth) / 2;
            int y = (formHeight - groupHeight) / 2;

            // Thiết lập vị trí mới
            groupBox1.Location = new System.Drawing.Point(x, y);
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
        }

        
    }
}
