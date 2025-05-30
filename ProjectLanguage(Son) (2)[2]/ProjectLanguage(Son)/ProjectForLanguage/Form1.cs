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
using System.Globalization;

namespace ProjectForLanguage
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        

        void passwordControl()
        {
            string sifre = txtPassword.Text.Trim(); // Boşlukları temizle

            if (string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Şifre Bölümü Boş Bırakılamaz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                    return; // Geçersiz e-posta adresi durumunda işlemi sonlandır
                }

                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-7DT4R8K\\SQLEXPRESS02;Initial Catalog=LanguageApp;Integrated Security=True;TrustServerCertificate=True"))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("select count(*) from [User] where userMail=@p1 and userPassword=@p2", connection);
                        command.Parameters.AddWithValue("@p1", txtEmail.Text);
                        command.Parameters.AddWithValue("@p2", txtPassword.Text);
                        int count = (int)command.ExecuteScalar();
                        if (count > 0)
                        {
                            FrmMainPage mainPage = new FrmMainPage();
                            this.Hide(); // Ana formu gizle
                            mainPage.Show();
                        }
                        else
                        {
                            MessageBox.Show("Girdiğiniz Bilgileri Lütfen Kontrol Ediniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else // Eğer e-posta alanı boşsa
            {
                MessageBox.Show("* Email alanı boş bırakılamaz.");
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            mailControl();
            passwordControl();
        }

        private void lnkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegister register = new FrmRegister();
            FrmLogin login = new FrmLogin();
            login.Close();
            register.Show();
        }

        private void lnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmForgotcs forgot=new FrmForgotcs();
            FrmLogin login = new FrmLogin();
            login.Close();
            forgot.Show();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       
        
    }
}
