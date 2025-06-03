using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectForLanguage
{
    public partial class FrmAddWord : Form
    {
        public FrmAddWord()
        {
            InitializeComponent();
        }

        private string connectionString = "Data Source=DESKTOP-7DT4R8K\\SQLEXPRESS02;Initial Catalog=LanguageApp;Integrated Security=True";

        void clean()
        {
            txtEnglishWord.Text = " ";
            txtTurkishMean.Text = " ";
            txtExampleSentences1.Text = " ";
            txtExampleSentences2.Text = " ";
            pictureBox.Image = null;
        }

        private void btnAddNewWord_Click(object sender, EventArgs e)
        {
            // Kullanıcı tarafından girilen bilgileri al
            string englishWord = txtEnglishWord.Text;
            string turkishMean = txtTurkishMean.Text;
            string exampleSentence1 = txtExampleSentences1.Text;
            string exampleSentence2 = txtExampleSentences2.Text;
            // Resmi al
            Image image = pictureBox.Image;

            // Bilgilerin boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(englishWord) || string.IsNullOrWhiteSpace(turkishMean) ||
                string.IsNullOrWhiteSpace(exampleSentence1) || string.IsNullOrWhiteSpace(exampleSentence2) || image == null)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            // Veritabanında kelimenin veya örnek cümlelerin var olup olmadığını kontrol etme
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Words WHERE EnglishWord = @EnglishWord OR " +
                                   "ExampleSentences1 = @ExampleSentences1 OR ExampleSentences2 = @ExampleSentences2";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EnglishWord", englishWord);
                    command.Parameters.AddWithValue("@ExampleSentences1", exampleSentence1);
                    command.Parameters.AddWithValue("@ExampleSentences2", exampleSentence2);
                    int wordCount = (int)command.ExecuteScalar();
                    if (wordCount > 0)
                    {
                        MessageBox.Show("Bu kelime veya örnek cümleler zaten veritabanında bulunmaktadır.");
                        return;
                    }

                    // Kelime veya örnek cümleler veritabanında bulunmuyorsa, yeni kelimeyi veritabanına ekleme
                    query = "INSERT INTO Words (EnglishWord, TurkishMean, ExampleSentences1, ExampleSentences2, Image) " +
                            "VALUES (@EnglishWord, @TurkishMean, @ExampleSentences1, @ExampleSentences2, @Image)";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EnglishWord", englishWord);
                    command.Parameters.AddWithValue("@TurkishMean", turkishMean);
                    command.Parameters.AddWithValue("@ExampleSentences1", exampleSentence1);
                    command.Parameters.AddWithValue("@ExampleSentences2", exampleSentence2);
                    // Resmi veritabanına binary olarak kaydetmek için MemoryStream kullan
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        image.Save(ms, image.RawFormat);
                        command.Parameters.AddWithValue("@Image", ms.GetBuffer());
                    }
                    // Sorguyu çalıştır
                    command.ExecuteNonQuery();
                    clean();
                    MessageBox.Show("Kelime başarıyla eklendi.");
                    // Formu kapat

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanına veri eklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            // Resim seçme iletişim kutusunu göster
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen resmi pictureBox'a yükle
                pictureBox.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmMainPage mainPage = new FrmMainPage();
            this.Close();
            mainPage.Show();
        }

        private void FrmAddWord_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
