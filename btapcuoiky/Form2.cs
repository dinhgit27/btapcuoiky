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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            cbTime.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLevel.DropDownStyle = ComboBoxStyle.DropDownList;

            if (cbTime.Items.Count > 0) cbTime.SelectedIndex = 0;
            if (cbLevel.Items.Count > 0) cbLevel.SelectedIndex = 0;

            rb1Player.Checked = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int totalTime = 120;
            if (cbTime.SelectedIndex == 1) totalTime = 180;
            else if (cbTime.SelectedIndex == 2) totalTime = 240;

            int cardCount = 20;
            if (cbLevel.SelectedIndex == 1) cardCount = 30;
            else if (cbLevel.SelectedIndex == 2) cardCount = 40;
            int mode = rb1Player.Checked ? 1 : 2;

            int hardcoreMode = 0;

            if (rbHardcoreX2.Checked) hardcoreMode = 1;      // X2
            else if (rbHardcoreX3.Checked) hardcoreMode = 2; // X3
            else hardcoreMode = 0;                           // Bình thường

            // 5. Chạy Form 3 với tham số mới
            Form3 form3 = new Form3(totalTime, cardCount, mode, hardcoreMode);
            this.Hide();
            form3.ShowDialog();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            // Lấy kích thước của khu vực làm việc bên trong Form
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Lấy kích thước của GroupBox
            int groupWidth = groupBox3.Width;
            int groupHeight = groupBox3.Height;

            // Tính toán tọa độ X và Y để căn giữa
            int x = (formWidth - groupWidth) / 2;
            int y = (formHeight - groupHeight) / 2;

            // Thiết lập vị trí mới
            groupBox3.Location = new System.Drawing.Point(x, y);


            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            groupBox2.BackColor = System.Drawing.Color.Transparent;
        }

        private void rbHardcoreX3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
