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
using System.Data.Common;

namespace ProjectForLanguage
{
    public partial class FrmForgotcs : Form
    {
        public FrmForgotcs()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-7DT4R8K\\SQLEXPRESS02;Initial Catalog=LanguageApp;Integrated Security=True;TrustServerCertificate=True");

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (passwordControl() && mailControl())
            {
                try
                {
                    connection.Open();

                    // E-posta adresine göre kullanıcıyı bulma
                    SqlCommand selectCommand = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE userMail=@userMail", connection);
                    selectCommand.Parameters.AddWithValue("@userMail", txtEmail.Text);
                    int count = (int)selectCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        // Kullanıcı bulundu, şifreyi güncelle
                        SqlCommand updateCommand = new SqlCommand("UPDATE [User] SET userPassword=@userPassword WHERE userMail=@userMail", connection);
                        updateCommand.Parameters.AddWithValue("@userPassword", txtPassword.Text);
                        updateCommand.Parameters.AddWithValue("@userMail", txtEmail.Text);
                        updateCommand.ExecuteNonQuery();
                        MessageBox.Show("Şifre Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private bool mailControl()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("* E-posta alanı boş bırakılamaz.");
                return false;
            }
            else
            {
                Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                if (!reg.IsMatch(txtEmail.Text))
                {
                    MessageBox.Show("* E-Posta adresi geçerli değil.");
                    return false;
                }
            }
            return true;
        }

        private bool passwordControl()
        {
            string password = txtPassword.Text.Trim(); // Boşlukları temizle
            string password2 = txtPassword2.Text.Trim();

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Şifre Bölümü Boş Bırakılamaz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(password2))
            {
                MessageBox.Show("Şifre Onaylama Bölümü Boş Bırakılamaz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (password != password2)
            {
                MessageBox.Show("Şifreler eşleşmiyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            this.Close();
            login.Show();
        }

        private void FrmForgotcs_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
