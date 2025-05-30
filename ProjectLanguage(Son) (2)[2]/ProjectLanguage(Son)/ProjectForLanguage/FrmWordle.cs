using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectForLanguage
{
    public partial class FrmWordle : Form
    {
        //5 harfli kelimeleri tahmin etme oyunu 6 tekrarla oynanır.
        const int MaxRows = 6;
        const int WordLength = 5;
        Label[,] boxes = new Label[MaxRows, WordLength];
        int currentRow = 0;
        int currentColumn = 0;
        string targetWord;
        List<string> wordList = new List<string> { "APPLE", "ROUTE", "EAGLE", "HELLO", "HUMAN" };
        int wins = 0, losses = 0;
        Label scoreLabel;
        Button restartButton;

        public FrmWordle()
        {
            InitializeComponent();
            this.Size = new Size(400, 500);
            this.Load += Form1_Load;
            this.KeyPreview = true;
            this.Shown += Form1_Shown;
            this.KeyPress += Form1_KeyPress;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateGrid();
            CreateRestartButton();
            CreateScoreLabel();
            SelectRandomWord();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.Focus();
            this.Select();
        }

        private void CreateGrid()
        {
            // 5x6 kutucuk oluşturma
            int startX = 50, startY = 50;
            for (int row = 0; row < MaxRows; row++)
            {
                for (int col = 0; col < WordLength; col++)
                {
                    Label box = new Label
                    {
                        Size = new Size(50, 50),
                        Location = new Point(startX + col * 55, startY + row * 55),
                        BorderStyle = BorderStyle.FixedSingle,
                        Font = new Font("Segoe UI", 18, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = Color.White
                    };
                    this.Controls.Add(box);
                    boxes[row, col] = box;
                }
            }
        }

        private void CreateRestartButton()
        {
            //oyunu tekrar başlatma butonu
            restartButton = new Button
            {
                Text = "Restart",
                Size = new Size(100, 30),
                Location = new Point(50, 400)
            };
            restartButton.Click += RestartButton_Click;
            this.Controls.Add(restartButton);
        }

        private void CreateScoreLabel()
        {
            // kazanma ve kaybetme sayısını gösteren label
            scoreLabel = new Label
            {
                Location = new Point(170, 400),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Text = $"Wins: {wins} | Losses: {losses}"
            };
            this.Controls.Add(scoreLabel);
        }

        private void SelectRandomWord()
        {
            // rastgele kelime seçme
            Random rnd = new Random();
            string newWord;
            do
            {
                newWord = wordList[rnd.Next(wordList.Count)].ToUpper();
            }
            while (newWord == targetWord);
            targetWord = newWord;

            if (wordList.Count <= 1)
            {
                targetWord = wordList[0].ToUpper();
                return;
            }

        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Tekrar oynamak ister misiniz?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            currentRow = 0;
            currentColumn = 0;

            foreach (var box in boxes)
            {
                box.Text = "";
                box.BackColor = Color.White;
               
            }
            this.ActiveControl = null;
            this.Focus();
            SelectRandomWord();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (currentRow >= MaxRows) return;

            char upperChar = char.ToUpper(e.KeyChar);

            // Sadece harf girişi
            if (char.IsLetter(upperChar))
            {
                if (currentColumn < WordLength)
                {
                    boxes[currentRow, currentColumn].Text = upperChar.ToString();
                    currentColumn++;
                }
                e.Handled = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (currentRow >= MaxRows) return;

            // Backspace tuşuyla harf siler
            if (e.KeyCode == Keys.Back && currentColumn > 0)
            {
                currentColumn--;
                boxes[currentRow, currentColumn].Text = "";
                e.Handled = true;
            }
            // Sol ok tuşuyla bir harf geri gider
            else if (e.KeyCode == Keys.Left && currentColumn > 0)
            {
                currentColumn--;
                e.Handled = true;
            }
            // Sağ ok tuşuyla bir harf ileri gider
            else if (e.KeyCode == Keys.Right && currentColumn < WordLength)
            {
                currentColumn++;
                e.Handled = true;
            }

            // Enter tuşuyla tahmin yapar

            else if (e.KeyCode == Keys.Enter && currentColumn == WordLength)
            {
                CheckGuess();
                e.Handled = true;
            }
        }

        private void CheckGuess()
        {
            // tahmin edilen kelimeyi kontrol eder
            string guess = GetGuess();
            if (guess.Length != WordLength)
            {
                MessageBox.Show("Lütfen 5 harfli bir kelime girin.");
                return;
            }

            ApplyColorFeedback(guess);

            if (guess == targetWord)
            {
                // doğru tahmin yapıldığında
                MessageBox.Show("🎉 TEBRİKLER!");
                wins++;
                UpdateScore();
                currentRow = MaxRows;
                return;
            }

            currentRow++;
            currentColumn = 0;

            if (currentRow == MaxRows)
            {
                // yanlış tahmin yapıldığında
                MessageBox.Show($"❌ OYUN BİTTİ! Kelime: {targetWord}");
                losses++;
                UpdateScore();
            }
        }

        private string GetGuess()
        {
            // tahmin edilen kelimeyi alır
            string guess = "";
            for (int i = 0; i < WordLength; i++)
                guess += boxes[currentRow, i].Text.ToUpper();
            return guess;
        }

        private void ApplyColorFeedback(string guess)
        {
            // tahmin edilen kelimeye göre kutucukların rengini ayarlar
            bool[] matched = new bool[WordLength];
            bool[] used = new bool[WordLength];
            char[] guessArr = guess.ToCharArray();
            char[] targetArr = targetWord.ToCharArray();

            // doğru yer doğru harf ise yeşil
            for (int i = 0; i < WordLength; i++)
            {
                if (guessArr[i] == targetArr[i])
                {
                    boxes[currentRow, i].BackColor = Color.Green;
                    matched[i] = true;
                    used[i] = true;
                }
            }

            //harf doğru ama yanlış yerdeyse sarı
            for (int i = 0; i < WordLength; i++)
            {
                if (boxes[currentRow, i].BackColor == Color.Green) continue;

                for (int j = 0; j < WordLength; j++)
                {
                    if (!matched[j] && guessArr[i] == targetArr[j])
                    {
                        boxes[currentRow, i].BackColor = Color.Goldenrod;
                        matched[j] = true;
                        used[i] = true;
                        break;
                    }
                }
            }

            // harf yanlışsa gri
            for (int i = 0; i < WordLength; i++)
            {
                if (!used[i])
                    boxes[currentRow, i].BackColor = Color.Gray;
            }
        }

        private void FrmWordle_Load(object sender, EventArgs e)
        {

        }

        private void UpdateScore()
        {
            //skoru günceller ve kazanma kaybetme sayılarını yazdırır.
            scoreLabel.Text = $"Wins: {wins} | Losses: {losses}";
        }
    }   
}
