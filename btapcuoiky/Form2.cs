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

            
            if (rbHardcoreX2.Checked) hardcoreMode = 1;     
            else if (rbHardcoreX3.Checked) hardcoreMode = 2; 
            else hardcoreMode = 0;

            Form3 form3 = new Form3(totalTime, cardCount, mode, hardcoreMode);
            this.Hide();
            form3.ShowDialog();
            this.Close();
        }
    }
}
