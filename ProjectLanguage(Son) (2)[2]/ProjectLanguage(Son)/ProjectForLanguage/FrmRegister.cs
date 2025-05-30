using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ProjectForLanguage
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        SqlConnection connection=new SqlConnection("Data Source=DESKTOP-7DT4R8K\\SQLEXPRESS02;Initial Catalog=LanguageApp;Integrated Security=True;TrustServerCertificate=True");



        void usernameControl()
        {
            string username = txtName.Text.Trim(); // Boşlukları temizle

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("İsim Bölümü Boş Bırakılamaz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void passwordControl()
        {
            string sifre = txtPassword.Text.Trim(); // Boşlukları temizle

            if (string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Şifre Bölümü Boş Bırakılamaz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void passwordMatch()
        {
            connection.Open();
            string password = txtPassword.Text.Trim();
            string password2 = txtPassword2.Text.Trim(); 
            if (password== password2)
            {
                SqlCommand command = new SqlCommand("insert into [User] (userName,userMail,userPassword) values(@P1,@P2,@P3)",connection);
                command.Parameters.AddWithValue("@P1", txtName.Text);
                command.Parameters.AddWithValue("@P2",txtEmail.Text);
                command.Parameters.AddWithValue("@P3", txtPassword.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı Başarıyla Oluşturuldu","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Şifreler Eşleşmedi","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            connection.Close();
        }

        void mailControl()
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

                // Girilen e-posta adresi, Regex ifadesiyle eşleşmiyorsa
                if (!reg.IsMatch(txtEmail.Text))
                {
                    MessageBox.Show("* E-Posta adresi geçerli değil.");
                }
            }
            else // Eğer e-posta alanı boşsa
            {
                MessageBox.Show("* Email alanı boş bırakılamaz.");
            }

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked)
            {
                txtPassword2.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
            }
            else
            {
                //Şifre Görüntüleme
                txtPassword2.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
            }
        }

        private void cbShowHide_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowHide.Checked)
            {
                txtPassword.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
            }
            else
            {
                //Şifre Görüntüleme
                txtPassword.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
            }
        }


        private void btnSignup_Click(object sender, EventArgs e)
        {
            mailControl();
            passwordControl();
            usernameControl();
            passwordMatch();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            this.Close();
            login.Show();
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
 