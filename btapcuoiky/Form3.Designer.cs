namespace btapcuoiky
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblP2 = new System.Windows.Forms.Label();
            this.lblP1 = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.FlipTimer = new System.Windows.Forms.Timer(this.components);
            this.hardcoreTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pnlCards
            // 
            this.pnlCards.Location = new System.Drawing.Point(3, 36);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(898, 486);
            this.pnlCards.TabIndex = 7;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(3, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(30, 13);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "Time";
            // 
            // lblP2
            // 
            this.lblP2.AutoSize = true;
            this.lblP2.Location = new System.Drawing.Point(374, 9);
            this.lblP2.Name = "lblP2";
            this.lblP2.Size = new System.Drawing.Size(67, 13);
            this.lblP2.TabIndex = 5;
            this.lblP2.Text = "Người chơi 2";
            // 
            // lblP1
            // 
            this.lblP1.AutoSize = true;
            this.lblP1.Location = new System.Drawing.Point(265, 9);
            this.lblP1.Name = "lblP1";
            this.lblP1.Size = new System.Drawing.Size(67, 13);
            this.lblP1.TabIndex = 4;
            this.lblP1.Text = "Người chơi 1";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // FlipTimer
            // 
            this.FlipTimer.Interval = 750;
            this.FlipTimer.Tick += new System.EventHandler(this.FlipTimer_Tick);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 522);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblP2);
            this.Controls.Add(this.lblP1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblP2;
        private System.Windows.Forms.Label lblP1;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer FlipTimer;
        private System.Windows.Forms.Timer hardcoreTimer;
    }
}