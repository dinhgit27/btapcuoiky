using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace btapcuoiky
{
    public partial class Form3 : Form
    {
            
            private int timeLeft;
            private int totalCards;
            private int gameMode;
            private int currentPlayer = 1;

            
            private int hardcoreMode; 

            
            private bool isAnimating = false;       
            private Button animCard1;              
            private Button animCard2;              
            private Point animDest1;               
            private Point animDest2;               
            private int shuffleCount = 0;           
            private int moveSpeed = 20;             
                                                   

            private Button firstClicked = null;
            private Button secondClicked = null;
            private int cardRows; 
            private int cardCols; 

            private List<string> imageKeys = new List<string>()
{
    "image1", "image2", "image3", "image4", "image5", "image6", "image7", "image8", "image9", "image10",
    "image11", "image12", "image13", "image14", "image15", "image16", "image17", "image18", "image19", "image20"
};
        public Form3(int time, int cards, int mode, int hardcore)
        {
            InitializeComponent();
            this.timeLeft = time;
            this.totalCards = cards;
            this.gameMode = mode;
            this.hardcoreMode = hardcore;

            SetupUI();
            SetupGame();
        }
        private void SetupUI()
        {
            lblP1.Text = "Người chơi 1";
            lblP2.Text = "Người chơi 2";
            //UpdatePlayerLabels();

            if (gameMode == 1) lblP2.Visible = false;

            //blTime.Text = FormatTime(timeLeft);

            
            //gameTimer.Interval = 1000;
          
         //   gameTimer.Start();

           // FlipTimer.Interval = 750;

         
            //hardcoreTimer.Interval = 15;
            //hardcoreTimer.Tick += HardcoreTimer_Tick;
        }
        private void SetupGame()
        {
            
            int pairsNeeded = totalCards / 2;
            List<string> currentImageKeys = new List<string>();

            for (int i = 0; i < pairsNeeded; i++)
            {
                currentImageKeys.Add(imageKeys[i]);
                currentImageKeys.Add(imageKeys[i]);
            }

            //Shuffle(currentImageKeys);

            pnlCards.Controls.Clear();

            
            cardRows = 4; cardCols = 5;
            if (totalCards == 30) { cardCols = 6; cardRows = 5; }
            else if (totalCards == 40) { cardCols = 8; cardRows = 5; }

            // 3. VẼ CÁC NÚT (KHÔNG CÓ KÍCH THƯỚC)
            for (int i = 0; i < totalCards; i++)
            {
                Button btn = new Button();

               
                btn.Tag = new Tuple<string, int>(currentImageKeys[i], i);

               
                btn.BackgroundImage = Properties.Resources.cardback;
                btn.BackgroundImageLayout = ImageLayout.Stretch;

                btn.Text = "";
                btn.Font = new Font("Arial", 1);
                btn.BackColor = Color.LightGray;
                btn.ForeColor = Color.LightGray;
               // btn.Click += Card_Click;

                pnlCards.Controls.Add(btn);
            }

            //AdjustCardLayout();
        }
    }
}
