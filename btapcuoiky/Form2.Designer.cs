namespace btapcuoiky
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbHardcoreX3 = new System.Windows.Forms.RadioButton();
            this.rbHardcoreX2 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb2Player = new System.Windows.Forms.RadioButton();
            this.rb1Player = new System.Windows.Forms.RadioButton();
            this.cbLevel = new System.Windows.Forms.ComboBox();
            this.cbTime = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbNormal);
            this.groupBox2.Controls.Add(this.rbHardcoreX3);
            this.groupBox2.Controls.Add(this.rbHardcoreX2);
            this.groupBox2.Location = new System.Drawing.Point(430, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(161, 84);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode";
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Checked = true;
            this.rbNormal.Location = new System.Drawing.Point(24, 59);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(82, 17);
            this.rbNormal.TabIndex = 12;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "Bình thường";
            this.rbNormal.UseVisualStyleBackColor = true;
            // 
            // rbHardcoreX3
            // 
            this.rbHardcoreX3.AutoSize = true;
            this.rbHardcoreX3.Location = new System.Drawing.Point(24, 34);
            this.rbHardcoreX3.Name = "rbHardcoreX3";
            this.rbHardcoreX3.Size = new System.Drawing.Size(110, 17);
            this.rbHardcoreX3.TabIndex = 11;
            this.rbHardcoreX3.Text = "SuperHardcoreX3";
            this.rbHardcoreX3.UseVisualStyleBackColor = true;
            // 
            // rbHardcoreX2
            // 
            this.rbHardcoreX2.AutoSize = true;
            this.rbHardcoreX2.Location = new System.Drawing.Point(24, 11);
            this.rbHardcoreX2.Name = "rbHardcoreX2";
            this.rbHardcoreX2.Size = new System.Drawing.Size(110, 17);
            this.rbHardcoreX2.TabIndex = 10;
            this.rbHardcoreX2.Text = "SuperHardcoreX2";
            this.rbHardcoreX2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Level";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Thời gian";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStart.Location = new System.Drawing.Point(333, 340);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 16;
            this.btnStart.Text = "Vào game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.rb2Player);
            this.groupBox1.Controls.Add(this.rb1Player);
            this.groupBox1.Location = new System.Drawing.Point(212, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 82);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chế độ ";
            // 
            // rb2Player
            // 
            this.rb2Player.AutoSize = true;
            this.rb2Player.Location = new System.Drawing.Point(35, 39);
            this.rb2Player.Name = "rb2Player";
            this.rb2Player.Size = new System.Drawing.Size(83, 17);
            this.rb2Player.TabIndex = 5;
            this.rb2Player.TabStop = true;
            this.rb2Player.Text = "2 người chơi";
            this.rb2Player.UseVisualStyleBackColor = true;
            // 
            // rb1Player
            // 
            this.rb1Player.AutoSize = true;
            this.rb1Player.Location = new System.Drawing.Point(35, 16);
            this.rb1Player.Name = "rb1Player";
            this.rb1Player.Size = new System.Drawing.Size(83, 17);
            this.rb1Player.TabIndex = 4;
            this.rb1Player.TabStop = true;
            this.rb1Player.Text = "1 người chơi";
            this.rb1Player.UseVisualStyleBackColor = true;
            // 
            // cbLevel
            // 
            this.cbLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbLevel.FormattingEnabled = true;
            this.cbLevel.Items.AddRange(new object[] {
            "Dễ",
            "Vừa",
            "Khó"});
            this.cbLevel.Location = new System.Drawing.Point(430, 125);
            this.cbLevel.Name = "cbLevel";
            this.cbLevel.Size = new System.Drawing.Size(121, 21);
            this.cbLevel.TabIndex = 14;
            // 
            // cbTime
            // 
            this.cbTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbTime.FormattingEnabled = true;
            this.cbTime.Items.AddRange(new object[] {
            "2 phút",
            "3 phút",
            "4 phút"});
            this.cbTime.Location = new System.Drawing.Point(212, 125);
            this.cbTime.Name = "cbTime";
            this.cbTime.Size = new System.Drawing.Size(121, 21);
            this.cbTime.TabIndex = 13;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbLevel);
            this.Controls.Add(this.cbTime);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbHardcoreX3;
        private System.Windows.Forms.RadioButton rbHardcoreX2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb2Player;
        private System.Windows.Forms.RadioButton rb1Player;
        private System.Windows.Forms.ComboBox cbLevel;
        private System.Windows.Forms.ComboBox cbTime;
    }
}