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
    public partial class Kurslar : Form
    {
        Uyeler _uye;
        public Kurslar(Uyeler uye)
        {
            _uye = uye;
            InitializeComponent();
        }

        private void Uyelikbutton_Click(object sender, EventArgs e)
        {
            UyelikForm uyelikForm = new UyelikForm(_uye);
            uyelikForm.Show();
            this.Hide();
        }

        private void ProfilButton_Click(object sender, EventArgs e)
        {
            ProfilForm profilForm = new ProfilForm(_uye);
            profilForm.Show();
            this.Hide();

        }

        private void KapatButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<String> kurslar = new List<string>();
        private void Kurslar_Load(object sender, EventArgs e)
        {
            kurslar.Add("Spinning");
            kurslar.Add("Aerobik");
            kurslar.Add("Yüzme");
        }

        private void AnasafaButton_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa(_uye);
            anasayfa.Show();
            this.Hide();

        }

        UyelerManager uyelerManager = new UyelerManager();

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                uyelerManager.UpdateUyeKurs(_uye.Id,kurslar[0]);
                
            }else if (radioButton2.Checked)
            {
                uyelerManager.UpdateUyeKurs(_uye.Id, kurslar[1]);
            }
            else if (radioButton5.Checked)
            {
                uyelerManager.UpdateUyeKurs(_uye.Id, kurslar[2]);
            }
            else
            {
                MessageBox.Show("Lütfen bir Kurs Seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
