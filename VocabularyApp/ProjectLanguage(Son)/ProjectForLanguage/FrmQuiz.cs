using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ProjectForLanguage
{
    public partial class FrmQuiz : Form
    {
        private string connectionString;
        SqlConnection connection;
        Random rnd = new Random();
        string correctTranslation;
        int totalWords;
        int currentWordIndex = 0;
        int correctAnswers = 0;
        int wrongAnswers = 0;
        private bool answerChecked = false;
        private byte[] wordImage;
        private Timer pictureTimer;
        List<string> askedWords = new List<string>();

        public FrmQuiz()
        {
            InitializeComponent();
            connectionString = "Data Source=DESKTOP-7DT4R8K;Initial Catalog=LanguageApp;Integrated Security=True;TrustServerCertificate=True";
            connection = new SqlConnection(connectionString);
            connection = new SqlConnection(connectionString);
            this.btnA.Click += new EventHandler(button1_Click);
            this.btnB.Click += new EventHandler(button2_Click);
            this.btnC.Click += new EventHandler(button3_Click);
            this.btnD.Click += new EventHandler(button4_Click);

            
            pictureBoxWordImage.SizeMode = PictureBoxSizeMode.StretchImage;
           
            pictureTimer = new Timer();
            pictureTimer.Interval = 1000; // 1 saniye
            pictureTimer.Tick += PictureTimer_Tick;
        }



        private void FrmQuiz_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            totalWords = FrmSettings.QuizQuestionNumber; // Ayarlanan soru sayısını al
            GetNextWord();
            lblExampleSentence.Text = GetExampleSentence(lblWord.Text);
            UpdateCorrectCountLabel();
            UpdateWrongCountLabel();
        }
        private void UpdateCorrectCountLabel()
        {
            lblCorrectCount.Text =  correctAnswers.ToString();
        }
        private void UpdateWrongCountLabel()
        {
            lblWrongCount.Text =  wrongAnswers.ToString();
        }
        private void HideBothIndicators()
        {
            pictureBoxCorrect.Visible = false;
            pictureBoxWrong.Visible = false;
        }


        private void GetNextWord()
        {
            btnA.Enabled = true;
            btnB.Enabled = true;
            btnC.Enabled = true;
            btnD.Enabled = true;
            //butonları aktif hale gelir

            pictureBoxCorrect.Visible = false;
            pictureBoxCorrect.Image = null;

            pictureBoxWrong.Visible = false;
            pictureBoxWrong.Image = null;

            btnA.BackColor = SystemColors.Control;
            btnB.BackColor = SystemColors.Control;
            btnC.BackColor = SystemColors.Control;
            btnD.BackColor = SystemColors.Control;

            answerChecked = false;
            if (currentWordIndex >= totalWords)
            {
                ShowQuizResults();
                return;
            }

            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 w.EnglishWord, w.TurkishMean, w.Image FROM Words w WHERE EnglishWord NOT IN ('" + string.Join("','", askedWords) + "') ORDER BY NEWID()", connection);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                lblQuestionNumber.Text = "Soru: " + (currentWordIndex + 1).ToString();
                lblWord.Text = dr["EnglishWord"].ToString();
                correctTranslation = dr["TurkishMean"].ToString();
                wordImage = dr["Image"] as byte[];

                // Sorulan kelimeler listesine ekleyin
                askedWords.Add(lblWord.Text);
            }
            else
            {
                MessageBox.Show("Kelime bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            connection.Close();

            // Butonlara rastgele Türkçe anlamları yerleştir
            PlaceTranslations();
            lblExampleSentence.Text = "";
            lblExampleSentence.Text = GetExampleSentence(lblWord.Text);
        }

        private string GetExampleSentence(string englishWord)
        {
            string exampleSentence = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 ExampleSentences1 FROM Words WHERE EnglishWord = @EnglishWord", connection);
                    cmd.Parameters.AddWithValue("@EnglishWord", englishWord);
                    exampleSentence = cmd.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Örnek cümle alınırken bir hata oluştu: " + ex.Message);
                }
            }
            return exampleSentence;
        }

        private void PlaceTranslations()
        {
            // Türkçe anlamları depolamak için bir liste oluşturun
            List<string> turkishTranslations = new List<string>();

            // Doğru cevabı ilk olarak listeye ekleyin
            turkishTranslations.Add(correctTranslation);

            // Diğer üç cevabı farklı Türkçe anlamlarla doldurun
            while (turkishTranslations.Count < 4)
            {
                string randomTranslation = GetRandomTranslation();

                // Rastgele çekilen anlam daha önce eklenmemişse, listeye ekleyin
                if (!turkishTranslations.Contains(randomTranslation) && randomTranslation != correctTranslation)
                {
                    turkishTranslations.Add(randomTranslation);
                }
            }

            // Cevap butonlarına Türkçe anlamları yerleştirin
            btnA.Text = turkishTranslations[0];
            btnB.Text = turkishTranslations[1];
            btnC.Text = turkishTranslations[2];
            btnD.Text = turkishTranslations[3];
        }

        private string GetRandomTranslation()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 TurkishMean FROM Words ORDER BY NEWID()", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            string translation = "";
            if (dr.Read())
            {
                translation = dr["TurkishMean"].ToString();
            }
            connection.Close();
            return translation;
        }
        private void ShowQuizResults()
        {
            // Quiz sonuçlarını veritabanına kaydet
            SaveQuizResults();

            // Kullanıcıya sonuçları göster
            MessageBox.Show("Quiz tamamlandı.\nDoğru Cevap Sayısı: " + correctAnswers + "\nYanlış Cevap Sayısı: " + wrongAnswers);
            double successRate = ((double)correctAnswers / (double)totalWords) * 100;
            MessageBox.Show("Başarı Oranı: %" + successRate.ToString("0.00"));

            FrmMainPage mainPage = new FrmMainPage();
            this.Close();
            mainPage.Show();
        }
        private void CheckAnswer(string selectedTranslation, Button selectedButton)
        {
            if (answerChecked) return; // Zaten kontrol edildiyse çık
            answerChecked = true;

            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
            // Seçilen butonları devre dışı bırak
            if (selectedTranslation == correctTranslation)
            {
                selectedButton.BackColor = Color.Green;
                correctAnswers++;
                UpdateCorrectCountLabel();
                
                MessageBox.Show("Doğru Cevap!", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HideBothIndicators();
                pictureBoxCorrect.Visible = true; 
               //doğru gif ekrana gelir
               pictureBoxWrong.Visible = false; // Yanlış gif gizlenir

                // Görüntüyü gösterin ve öne getirin
                if (wordImage != null)
                {
                    using (MemoryStream ms = new MemoryStream(wordImage))
                    {
                        pictureBoxWordImage.Image = Image.FromStream(ms);
                        pictureBoxWordImage.BringToFront(); // PictureBox'ı öne getirin
                    }
                }

                // Doğru cevaplanan kelimenin doğru bilinme sayısını artır
                IncreaseCorrectCount();

                // Doğru bilinme sayısı 6'ya ulaştıysa kelimeyi sil
                if (GetCorrectCount(lblWord.Text) >= 6)
                {
                    DeleteWord(lblWord.Text);
                }
            }
            else
            {
                selectedButton.BackColor = Color.Red;
                wrongAnswers++;
                UpdateWrongCountLabel();
                MessageBox.Show("Yanlış Cevap!", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HideBothIndicators();
                pictureBoxWrong.Visible = true;//yanlış gif ekrana gelir
                pictureBoxCorrect.Visible = false;
                // Yanlış cevaplandığında, doğru bilinme sayısını sıfırla
                ResetCorrectCount();
            }

            // 1 saniye bekle ve sonra bir sonraki soruya geç
            Timer timer = new Timer();
            timer.Interval = 1000; // 1 saniye bekle
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                currentWordIndex++;
                GetNextWord();
            };
            timer.Start();
            pictureBoxWordImage.Visible = true;
            pictureTimer.Start();

        }
        private void PictureTimer_Tick(object sender, EventArgs e)
        {
            // Timer'ı durdur ve PictureBox'ı gizle
            pictureTimer.Stop();
            pictureBoxWordImage.Visible = false;
            HideBothIndicators();
        }

        private int GetCorrectCount(string englishWord)
        {
            int correctCount = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT CorrectCount FROM Words WHERE EnglishWord = @EnglishWord", connection);
                    cmd.Parameters.AddWithValue("@EnglishWord", englishWord);
                    correctCount = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doğru bilinme sayısı alınırken bir hata oluştu: " + ex.Message);
                }
            }
            return correctCount;
        }

        private void IncreaseCorrectCount()
        {
            // Veritabanında ilgili kelimenin doğru bilinme sayısını bir artır
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Words SET CorrectCount = CorrectCount + 1 WHERE EnglishWord = @EnglishWord", connection);
                    cmd.Parameters.AddWithValue("@EnglishWord", lblWord.Text);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doğru bilinme sayısı güncellenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void ResetCorrectCount()
        {
            // Veritabanında ilgili kelimenin doğru bilinme sayısını sıfırla
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Words SET CorrectCount = 0 WHERE EnglishWord = @EnglishWord", connection);
                    cmd.Parameters.AddWithValue("@EnglishWord", lblWord.Text);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doğru bilinme sayısı sıfırlanırken bir hata oluştu: " + ex.Message);
                }
            }
        }
        private void DeleteWord(string englishWord)
        {
            // Veritabanından ilgili kelimeyi sil
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Words WHERE EnglishWord = @EnglishWord", connection);
                    cmd.Parameters.AddWithValue("@EnglishWord", englishWord);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kelime silinirken bir hata oluştu: " + ex.Message);
                }
            }
        }


        private void SaveQuizResults()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO QuizResults (QuizDate, CorrectAnswers, WrongAnswers) VALUES (@QuizDate, @CorrectAnswers, @WrongAnswers)", connection);
                    cmd.Parameters.AddWithValue("@QuizDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CorrectAnswers", correctAnswers);
                    cmd.Parameters.AddWithValue("@WrongAnswers", wrongAnswers);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Quiz sonuçları kaydedilirken bir hata oluştu: " + ex.Message);
                }
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            CheckAnswer(btnA.Text, btnA);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckAnswer(btnB.Text, btnB);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckAnswer(btnC.Text, btnC);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CheckAnswer(btnD.Text, btnD);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmMainPage mainPage = new FrmMainPage();
            this.Close();
            mainPage.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}