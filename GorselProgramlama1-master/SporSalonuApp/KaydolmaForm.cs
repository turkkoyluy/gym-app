using SporSalonuApp.Database;
using SporSalonuApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonuApp
{
    public partial class KaydolmaForm : Form
    {
        UyelerManager uyelerManager;
        public KaydolmaForm()
        {
            uyelerManager = new UyelerManager();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Uygulamadan çıkmak istiyor musunuz?", "çıkış Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void KaydolButton_Click(object sender, EventArgs e)
        {
            //kullanıcı adı kontrolü yap. -> aynı kullanıcı adı olmasın
            //email kontrolü yap. -> aynı email olmasın
            DatabaseSqlConnection db = new DatabaseSqlConnection();
            int gender = 0;
            if (radioButton1.Checked)
            {
                gender = 1;
            }
            else if (radioButton2.Checked)
            {
                gender = 2;
            }
            else
            {
                MessageBox.Show("Lütfen bir cinsiyet seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Uyeler uye = new Uyeler
            {
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                Gender = gender,
                Username = txtUsername.Text,
                Boy = Convert.ToDouble(txtBoy.Text),
                Kilo = Convert.ToDouble(txtKilo.Text),
                Yas = Convert.ToInt32(txtYas.Text)
            };
            int result = uyelerManager.InsertUye(uye);
            if (result == 1)
            {
                MessageBox.Show("Üyelik tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            db.CloseConnection();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

    }
}
