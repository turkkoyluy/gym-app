using BunifuAnimatorNS;
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
    public partial class LoginForm : Form
    {
        UyelerManager uyelerManager;
        public LoginForm()
        {
            uyelerManager = new UyelerManager();
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void GirisButton_Click(object sender, EventArgs e)
        {
            try
            {
                var uye = uyelerManager.Login(textBox1.Text, textBox2.Text);

                Anasayfa anasayfa = new Anasayfa(uye);
                anasayfa.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Kullanıcı adı veya şifre yalnış", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = String.Empty;
            }
        }

        private void KaydolButton_Click(object sender, EventArgs e)
        {
            KaydolmaForm kaydolmaForm = new KaydolmaForm();
            kaydolmaForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Uygulamadan çıkmak istiyor musunuz?", "çıkış Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else { 
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
