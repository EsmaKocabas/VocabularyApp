using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectForLanguage
{
    public partial class FrmWords : Form
    {
        public FrmWords()
        {
            InitializeComponent();
        }

        private string connectionString = "Data Source=DESKTOP-7DT4R8K\\SQLEXPRESS02;Initial Catalog=LanguageApp;Integrated Security=True;TrustServerCertificate=True";

        private void FrmWords_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // "ExampleSentences3" sütununu sorgudan kaldırdık
                    string query = "SELECT EnglishWord, TurkishMean, ExampleSentences1, ExampleSentences2 FROM Words";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // DataGridView'e verileri yükle
                    dataGridView.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmMainPage mainPage = new FrmMainPage();
            this.Close();
            mainPage.Show();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
