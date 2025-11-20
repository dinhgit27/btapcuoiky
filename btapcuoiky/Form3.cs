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
        // Biến cơ bản
        private int timeLeft;
        private int totalCards;
        private int gameMode;
        private int currentPlayer = 1;

        // --- BIẾN HARDCORE (ANIMATION) ---
        private int hardcoreMode; // 0=Tắt, 1=X2, 2=X3

        // Các biến phục vụ hoạt hình bay lượn
        private bool isAnimating = false;       // Đang trong quá trình bay?
        private Button animCard1;               // Lá bài 1 đang bay
        private Button animCard2;               // Lá bài 2 đang bay
        private Point animDest1;                // Đích đến của lá 1
        private Point animDest2;                // Đích đến của lá 2
        private int shuffleCount = 0;           // Đếm số lần đã tráo
        private int moveSpeed = 20;             // Tốc độ bay (pixels/tick)
        // ---------------------------------

        private Button firstClicked = null;
        private Button secondClicked = null;
        private int cardRows; // Số hàng bài
        private int cardCols; // Số cột bài

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
            UpdatePlayerLabels();

            if (gameMode == 1) lblP2.Visible = false;

            lblTime.Text = FormatTime(timeLeft);

            // ĐẢM BẢO GAMETIMER CHẠY
            gameTimer.Interval = 1000;
            // Gán sự kiện tick thủ công (phòng trường hợp Designer lỗi)
            // gameTimer.Tick += gameTimer_Tick;
            gameTimer.Start();

            FlipTimer.Interval = 750;

            // Timer Hardcore dùng để vẽ chuyển động (Animation Loop)
            // Cần chạy rất nhanh để tạo cảm giác mượt (khoảng 60fps -> 16ms)
            hardcoreTimer.Interval = 15;
            hardcoreTimer.Tick += HardcoreTimer_Tick;
            ApplyMysticalForestTheme();
        }

        private void SetupGame()
        {
            // 1. Tạo danh sách key hình ảnh cần thiết và xáo trộn
            int pairsNeeded = totalCards / 2;
            List<string> currentImageKeys = new List<string>();

            for (int i = 0; i < pairsNeeded; i++)
            {
                currentImageKeys.Add(imageKeys[i]);
                currentImageKeys.Add(imageKeys[i]);
            }

            Shuffle(currentImageKeys);

            pnlCards.Controls.Clear();

            // --- BẠN CẦN THÊM ĐOẠN NÀY VÀO ĐÂY ---
            // Tắt chế độ tự động neo vào góc trái, để code tính toán vị trí hoạt động đúng
            pnlCards.Anchor = AnchorStyles.None;
            // -------------------------------------

            // 2. LƯU LẠI số hàng và số cột vào biến toàn cục
            if (totalCards <= 20)
            {
                cardRows = 4;
                cardCols = 5;
            }
            else if (totalCards <= 30)
            {
                cardRows = 5;
                cardCols = 6;
            }
            else if (totalCards <= 40)
            {
                cardRows = 5;
                cardCols = 8;
            }
            else if (totalCards <= 54)
            {
                cardRows = 6;
                cardCols = 9;
            }
            else
            {
                cardRows = 6;
                cardCols = 10;
            }

            // 3. VẼ CÁC NÚT (KHÔNG CÓ KÍCH THƯỚC)
            for (int i = 0; i < totalCards; i++)
            {
                Button btn = new Button();

                // Gán key hình ảnh (Item1) và vị trí ban đầu (Item2) vào Tag
                btn.Tag = new Tuple<string, int>(currentImageKeys[i], i);

                // --- CHÈN HÌNH MẶT SAU ---
                btn.BackgroundImage = Properties.Resources.cardback;
                btn.BackgroundImageLayout = ImageLayout.Stretch;

                btn.Text = "";
                btn.Font = new Font("Arial", 1);
                btn.BackColor = Color.LightGray;
                btn.ForeColor = Color.LightGray;
                btn.Click += Card_Click;

                pnlCards.Controls.Add(btn);
            }

            // 4. Gọi hàm điều chỉnh layout lần đầu tiên để thiết lập vị trí/kích thước ban đầu
            AdjustCardLayout();
            StyleAllCards();
        }

        private void Shuffle(List<string> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            if (FlipTimer.Enabled || hardcoreTimer.Enabled) return;

            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                if (clickedButton.ForeColor == Color.Black) return;

                // Lấy key hình ảnh từ Tag
                Tuple<string, int> tagInfo = (Tuple<string, int>)clickedButton.Tag;
                string imageKey = tagInfo.Item1;

                // --- HIỆN HÌNH MẶT TRƯỚC ---
                Image frontImage = (Image)Properties.Resources.ResourceManager.GetObject(imageKey);

                if (frontImage != null)
                {
                    clickedButton.BackgroundImage = frontImage;
                    clickedButton.BackgroundImageLayout = ImageLayout.Stretch;

                    clickedButton.ForeColor = Color.Black;
                    clickedButton.Text = "";
                }

                if (hardcoreMode > 0)
                {
                    // Logic Hardcore (Animation) giữ nguyên
                    moveSpeed = (hardcoreMode == 1) ? 10 : 25;
                    shuffleCount = 0;
                    isAnimating = false;
                    animCard1 = clickedButton;
                    hardcoreTimer.Start();
                }
                else
                {
                    ProcessCardSelection(clickedButton);
                }
            }
        }

        private void HardcoreTimer_Tick(object sender, EventArgs e)
        {
            // --- GIAI ĐOẠN 1: Setup cặp bài (GIỮ NGUYÊN) ---
            if (!isAnimating)
            {
                int limit = (hardcoreMode == 1) ? 4 : 10;
                if (shuffleCount >= limit)
                {
                    hardcoreTimer.Stop();
                    ProcessCardSelection(animCard1);
                    return;
                }

                Random rng = new Random();
                do
                {
                    int idx = rng.Next(pnlCards.Controls.Count);
                    animCard2 = (Button)pnlCards.Controls[idx];
                } while (animCard2 == animCard1 || !animCard2.Visible);

                animDest1 = animCard2.Location;
                animDest2 = animCard1.Location;

                animCard1.BringToFront();
                animCard2.BringToFront();

                isAnimating = true;
                shuffleCount++;
            }
            // --- GIAI ĐOẠN 2: Di chuyển và Cập nhật Logic (SỬA ĐỔI) ---
            else
            {
                bool reached1 = MoveTowards(animCard1, animDest1, moveSpeed);
                bool reached2 = MoveTowards(animCard2, animDest2, moveSpeed);

                if (reached1 && reached2)
                {
                    animCard1.Location = animDest1;
                    animCard2.Location = animDest2;

                    // --- CẬP NHẬT LOGIC: TRÁO ĐỔI TAG (INDEX) ---
                    // Để khi Resize, các lá bài giữ nguyên vị trí mới này chứ không bay về chỗ cũ

                    Tuple<string, int> tag1 = (Tuple<string, int>)animCard1.Tag;
                    Tuple<string, int> tag2 = (Tuple<string, int>)animCard2.Tag;

                    // Tạo Tuple mới với Index đã tráo đổi (Item1 là Key hình giữ nguyên, Item2 là Index đổi cho nhau)
                    animCard1.Tag = new Tuple<string, int>(tag1.Item1, tag2.Item2);
                    animCard2.Tag = new Tuple<string, int>(tag2.Item1, tag1.Item2);

                    isAnimating = false;
                }
            }
        }

        // Hàm hỗ trợ di chuyển Button về phía đích
        private bool MoveTowards(Button btn, Point dest, int speed)
        {
            int dx = dest.X - btn.Left;
            int dy = dest.Y - btn.Top;

            // Tính khoảng cách
            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (distance <= speed)
            {
                return true; // Đã đến nơi (hoặc rất gần)
            }

            // Tính tỉ lệ di chuyển
            double ratio = speed / distance;
            btn.Left += (int)(dx * ratio);
            btn.Top += (int)(dy * ratio);

            return false; // Chưa đến
        }

        private void ProcessCardSelection(Button clickedButton)
        {
            if (firstClicked == null)
            {
                firstClicked = clickedButton;
                return;
            }

            secondClicked = clickedButton;
            FlipTimer.Start();
        }

        private void FlipTimer_Tick(object sender, EventArgs e)
        {
            FlipTimer.Stop();

            if (firstClicked == null || secondClicked == null) return;

            // Lấy Key hình ảnh từ Tag (Item1) để so sánh
            Tuple<string, int> tag1 = (Tuple<string, int>)firstClicked.Tag;
            Tuple<string, int> tag2 = (Tuple<string, int>)secondClicked.Tag;

            if (tag1.Item1 == tag2.Item1) // So sánh key hình ảnh
            {
                // Khớp: Ẩn lá bài
                firstClicked.Visible = false;
                secondClicked.Visible = false;
                CheckVictory();
            }
            else
            {
                // Không khớp: Đặt lại hình ảnh mặt sau
                firstClicked.BackgroundImage = Properties.Resources.cardback;
                secondClicked.BackgroundImage = Properties.Resources.cardback;

                // Đặt lại trạng thái "chưa lật"
                firstClicked.ForeColor = firstClicked.BackColor;
                secondClicked.ForeColor = secondClicked.BackColor;
                firstClicked.Text = "";
                secondClicked.Text = "";

                if (gameMode == 2)
                {
                    currentPlayer = (currentPlayer == 1) ? 2 : 1;
                    UpdatePlayerLabels();
                }
            }

            firstClicked = null;
            secondClicked = null;
        }

        private void CheckVictory()
        {
            bool remaining = false;
            foreach (Control c in pnlCards.Controls)
            {
                if (c.Visible) { remaining = true; break; }
            }

            if (!remaining)
            {
                gameTimer.Stop();
                hardcoreTimer.Stop();
                MessageBox.Show("Hoàn thành!", "Chúc mừng");
                this.Close();
            }
        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            // Cập nhật lại vị trí label
            const int top = 15;
            lblTime.Left = 20;
            lblTime.Top = top;

            if (gameMode == 2)
            {
                int center = this.ClientSize.Width / 2;
                lblP1.Top = top;
                lblP2.Top = top;
                lblP1.Left = center - lblP1.Width - 40;
                lblP2.Left = center + 40;
            }

            // QUAN TRỌNG: Không được return nếu đang animating nữa!
            // Vì nếu đang bay thì vẫn phải cập nhật vị trí panel + label
            // Chỉ không cập nhật vị trí từng lá bài thôi
            if (isAnimating) return; // vẫn giữ dòng này

            AdjustCardLayout();
        }

        private void UpdatePlayerLabels()
        {
            if (gameMode == 2)
            {
                if (currentPlayer == 1)
                {
                    lblP1.Font = new Font(lblP1.Font, FontStyle.Bold);
                    lblP1.ForeColor = Color.Black;
                    lblP2.Font = new Font(lblP2.Font, FontStyle.Regular);
                    lblP2.ForeColor = Color.Gray;
                }
                else
                {
                    lblP1.Font = new Font(lblP1.Font, FontStyle.Regular);
                    lblP1.ForeColor = Color.Gray;
                    lblP2.Font = new Font(lblP2.Font, FontStyle.Bold);
                    lblP2.ForeColor = Color.Black;
                }
            }
            else
            {
                lblP1.Font = new Font(lblP1.Font, FontStyle.Bold);
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // ĐIỀU CHỈNH LOGIC ĐẾM NGƯỢC: Kiểm tra trước khi trừ
            // 1. Kiểm tra xem đã hết giờ chưa
            if (timeLeft <= 0)
            {
                gameTimer.Stop();
                hardcoreTimer.Stop();
                // Đảm bảo Label hiển thị 00:00 trước khi báo lỗi
                lblTime.Text = FormatTime(0);
                MessageBox.Show("Hết giờ", "Thất bại");
                this.Close();
                return; // Quan trọng: dừng hàm để không chạy tiếp
            }

            // 2. Trừ thời gian đi 1 giây
            timeLeft--;

            // 3. Cập nhật hiển thị thời gian còn lại
            lblTime.Text = FormatTime(timeLeft);
        }

        private string FormatTime(int seconds)
        {
            TimeSpan t = TimeSpan.FromSeconds(seconds);
            return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
        }
        private void AdjustCardLayout()
        {
            if (pnlCards.Controls.Count == 0 || cardCols == 0 || cardRows == 0) return;

            // === KÍCH THƯỚC CỐ ĐỊNH THEO YÊU CẦU CỦA BẠN ===
            const int CARD_WIDTH = 100;   // chiều rộng
            const int CARD_HEIGHT = 150;   // chiều cao
            const int GAP = 15;    // khoảng cách giữa các lá bài (có thể chỉnh)

            // Tính kích thước panel dựa trên kích thước cố định
            int panelWidth = cardCols * CARD_WIDTH + (cardCols + 1) * GAP;
            int panelHeight = cardRows * CARD_HEIGHT + (cardRows + 1) * GAP;

            pnlCards.Width = panelWidth;
            pnlCards.Height = panelHeight;

            // Căn giữa panel trong form
            pnlCards.Left = (this.ClientSize.Width - panelWidth) / 2;
            pnlCards.Top = (this.ClientSize.Height - panelHeight) / 2;

            // Đặt vị trí + bo tròn cho từng lá bài
            int index = 0;
            foreach (Control c in pnlCards.Controls)
            {
                if (c is Button btn)
                {
                    int row = index / cardCols;
                    int col = index % cardCols;

                    btn.Width = CARD_WIDTH;
                    btn.Height = CARD_HEIGHT;

                    btn.Left = GAP + col * (CARD_WIDTH + GAP);
                    btn.Top = GAP + row * (CARD_HEIGHT + GAP);

                    // Bo tròn 4 góc (20px) – vẫn đẹp với hình chữ nhật
                    var path = new System.Drawing.Drawing2D.GraphicsPath();
                    int radius = 20;
                    var rect = new Rectangle(0, 0, btn.Width, btn.Height);

                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
                    path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
                    path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
                    path.CloseAllFigures();

                    btn.Region = new Region(path);

                    index++;
                }
            }

            // Nếu bạn muốn panel luôn ở giữa ngay cả khi resize
            pnlCards.Anchor = AnchorStyles.None;
        }
        
        private void ApplyMysticalForestTheme()
        {
            // 1. Nền Form - Rừng sâu huyền bí
            this.BackgroundImage = Properties.Resources.backgroud_cd2; // bạn thêm ảnh này vào Resources nhé!
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackColor = Color.FromArgb(15, 40, 25);

            // 2. Panel chứa bài - trong suốt + viền phát sáng nhẹ
            pnlCards.BackColor = Color.FromArgb(80, 0, 30, 0); // gần trong suốt
            pnlCards.BorderStyle = BorderStyle.None;

            // Tạo hiệu ứng glow viền cho panel
            pnlCards.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, pnlCards.ClientRectangle,
                    Color.FromArgb(100, 150, 255, 150), 2, ButtonBorderStyle.Solid,
                    Color.FromArgb(100, 150, 255, 150), 2, ButtonBorderStyle.Solid,
                    Color.FromArgb(120, 100, 255, 100), 4, ButtonBorderStyle.Solid,
                    Color.FromArgb(120, 100, 255, 100), 4, ButtonBorderStyle.Solid);
            };

            // 3. Các Label (Thời gian + Người chơi) - Font fantasy + bóng đổ + glow
            Font fantasyFont = new Font("Segoe UI", 14F, FontStyle.Bold);
            Font timeFont = new Font("Consolas", 22F, FontStyle.Bold);

            lblTime.Font = timeFont;
            lblTime.ForeColor = Color.LimeGreen;
            lblTime.BackColor = Color.FromArgb(100, 0, 0, 0);
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            lblTime.Padding = new Padding(10);
            lblTime.BorderStyle = BorderStyle.None;

            // Glow cho thời gian
            lblTime.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(80, 0, 255, 0), 4),
                    new Rectangle(0, 0, lblTime.Width - 1, lblTime.Height - 1));
            };

            lblP1.Font = fantasyFont;
            lblP2.Font = fantasyFont;
            lblP1.ForeColor = Color.PaleGreen;
            lblP2.ForeColor = Color.PaleGreen;
            lblP1.BackColor = Color.FromArgb(120, 0, 40, 20);
            lblP2.BackColor = Color.FromArgb(120, 0, 40, 20);
            lblP1.Padding = new Padding(15, 8, 15, 8);
            lblP2.Padding = new Padding(15, 8, 15, 8);

            // Bo góc cho label người chơi
            lblP1.Region = CreateRoundedRegion(lblP1.ClientRectangle, 20);
            lblP2.Region = CreateRoundedRegion(lblP2.ClientRectangle, 20);
        }

        // Hàm tạo vùng bo tròn (dùng cho label)
        private Region CreateRoundedRegion(Rectangle rect, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return new Region(path);
        }

        // 4. Trang trí từng lá bài (gọi sau khi tạo các Button trong SetupGame())
        private void StyleAllCards()
        {
            foreach (Control c in pnlCards.Controls)
            {
                if (c is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = Color.FromArgb(40, 100, 60);

                    // Hover phát sáng xanh
                    btn.MouseEnter += (s, e) => {
                        btn.BackColor = Color.FromArgb(100, 150, 255, 150);
                        btn.FlatAppearance.BorderSize = 4;
                        btn.FlatAppearance.BorderColor = Color.LimeGreen;
                    };
                    btn.MouseLeave += (s, e) => {
                        btn.BackColor = Color.FromArgb(40, 100, 60);
                        btn.FlatAppearance.BorderSize = 0;
                    };

                    // Mặt sau
                    if (Properties.Resources.ResourceManager.GetObject("cardback_forest") is Image img)
                        btn.BackgroundImage = img;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
