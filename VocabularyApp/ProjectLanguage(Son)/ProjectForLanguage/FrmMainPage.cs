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
    public partial class FrmMainPage : Form
    {
        public FrmMainPage()
        {
            InitializeComponent();
        }

        private void btnQuiz_Click(object sender, EventArgs e)
        {
            FrmQuiz quiz = new FrmQuiz();
            this.Hide();
            quiz.Show();
        }

        private void btnAddNewWord_Click(object sender, EventArgs e)
        {
            FrmAddWord addWord = new FrmAddWord();
            this.Hide();
            addWord.Show();
        }

        private void btnMyWords_Click(object sender, EventArgs e)
        {
            FrmWords myword = new FrmWords();
            this.Hide();
            myword.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FrmSettings settings = new FrmSettings();
            this.Hide();
            settings.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            this.Close();
            login.Show();
        }

        private void FrmMainPage_Load(object sender, EventArgs e)
        {

        }
        private void btnQuizResults_Click(object sender, EventArgs e)
        {
            QuizResults quizResults = new QuizResults();
            this.Hide();
            quizResults.Show();
        }

        private void btnWordle_Click(object sender, EventArgs e)
        {
            FrmWordle wordle = new FrmWordle();
            this.Hide();
            wordle.Show();
        }
    }
}
