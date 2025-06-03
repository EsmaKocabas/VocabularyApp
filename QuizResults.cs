using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectForLanguage
{
    public partial class QuizResults : Form
    {
        private string connectionString = "Data Source=DESKTOP-7DT4R8K\\SQLEXPRESS02;Initial Catalog=LanguageApp;Integrated Security=True;TrustServerCertificate=True";

        public QuizResults()
        {
            InitializeComponent();
        }

        private void QuizResults_Load(object sender, EventArgs e)
        {
            LoadQuizResults();
        }

        private void LoadQuizResults()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM QuizResults ORDER BY QuizDate DESC", connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // İstatistik sütunu ekle
                    dataTable.Columns.Add("Statistics", typeof(string));

                    // İstatistik verilerini hesapla ve tabloya ekle
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int correctAnswers = Convert.ToInt32(row["CorrectAnswers"]);
                        int wrongAnswers = Convert.ToInt32(row["WrongAnswers"]);
                        double successRate = CalculateSuccessRate(correctAnswers, wrongAnswers);

                        // İstatistik verisini formatla ve tabloya ekle
                        string statistics = string.Format("Başarı Oranı: %{0:0.00}", successRate);
                        row["Statistics"] = statistics;

                    }

                    // DataGridView'e verileri aktar
                    dataGridViewResults.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Quiz sonuçları yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }
        private double CalculateSuccessRate(int correctAnswers, int wrongAnswers)
        {
            double successRate = 0.0;
            if (correctAnswers + wrongAnswers > 0)
            {
                successRate = ((double)correctAnswers / (correctAnswers + wrongAnswers)) * 100;
            }
            return successRate;
        }


        // QuizResults formunda btnBack_Click olay yöneticisi
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Geri dönüş butonuna tıklandığında FrmMainPage formunu oluşturun ve QuizResults formunu gizleyin
            FrmMainPage mainPage = new FrmMainPage();
            this.Hide();
            mainPage.Show();
        }

        private void dataGridViewResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
