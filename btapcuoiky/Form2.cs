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
            // Giả sử bạn đã đặt tên 3 nút mới là rbNormal, rbHardcoreX2, rbHardcoreX3
            // Nếu bạn chưa đặt tên trong Design thì nhớ đặt, hoặc dùng tên mặc định (radioButton1...)
            // Ở đây mình mặc định bạn đặt tên chuẩn là: rbNormal, rbHardcoreX2, rbHardcoreX3
            // Nếu chưa có rbNormal thì bạn cứ để mặc định code sẽ tự hiểu là 0.
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // 1. Lấy Thời gian
            int totalTime = 120;
            if (cbTime.SelectedIndex == 1) totalTime = 180;
            else if (cbTime.SelectedIndex == 2) totalTime = 240;

            // 2. Lấy Level
            int cardCount = 20;
            if (cbLevel.SelectedIndex == 1) cardCount = 30;
            else if (cbLevel.SelectedIndex == 2) cardCount = 40;

            // 3. Lấy Chế độ người chơi
            int mode = rb1Player.Checked ? 1 : 2;

            // 4. --- LẤY CHẾ ĐỘ HARDCORE ---
            // 0 = Bình thường, 1 = X2 (Chậm), 2 = X3 (Nhanh)
            int hardcoreMode = 0;

            // Lưu ý: Bạn cần thay tên rbHardcoreX2, rbHardcoreX3 đúng với tên bạn đặt trong Designer
            // Nếu bạn chưa tạo nút rbNormal thì logic else cuối cùng sẽ lo việc đó
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
        }
    }
}
