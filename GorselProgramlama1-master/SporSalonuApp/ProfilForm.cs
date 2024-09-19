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
    public partial class ProfilForm : Form
    {
        Uyeler _uye;
        public ProfilForm(Uyeler uye)
        {
            _uye = uye;
            InitializeComponent();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }



        private void ProfilForm_Load(object sender, EventArgs e)
        {


        }
        private void Uyelikbutton_Click(object sender, EventArgs e)
        {
            UyelikForm uyelikform = new UyelikForm(_uye);   
            uyelikform.Show();
            this.Hide();

        }



        private void KurslarButton_Click(object sender, EventArgs e)
        {
            Kurslar kurslar = new Kurslar(_uye);
            kurslar.Show();
            this.Hide();
        }

        private void Kapatbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
UyelerManager UyelerManager = new UyelerManager();
        private void button6_Click(object sender, EventArgs e)
        {
            if (UyelerManager.DeleteUye(_uye.Id) == 1)
            {
                MessageBox.Show("Üyelik Silindi.Çıkış Yapılıyor");
                LoginForm login = new LoginForm();
                login.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Üyelik Silinemedi.");
            }
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            _uye.Name =textBox1.Text;
            _uye.Surname = textBox2.Text;
            _uye.Username = textBox3.Text;
            _uye.Password = textBox4.Text;
            if (UyelerManager.UpdateUye(_uye)==1)
            {
                MessageBox.Show("Üye Güncellendi.");
            }
        }

        private void AnasayfaButton_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa(_uye);
            anasayfa.Show();
            this.Hide();
        }
    }
}
