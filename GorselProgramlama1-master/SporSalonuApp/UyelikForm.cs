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
    public partial class UyelikForm : Form
    {
        DatabaseSqlConnection db;
        Uyeler _uye;
        public UyelikForm(Uyeler uye)
        {
            _uye = uye;
            InitializeComponent();
            db = new DatabaseSqlConnection();
        }

        private void ProfilButton_Click(object sender, EventArgs e)
        {
            ProfilForm profilForm = new ProfilForm(_uye);
            profilForm.Show();
            this.Hide();

        }

        private void Kurslarbutton_Click(object sender, EventArgs e)
        {
            Kurslar kurslar = new Kurslar(_uye);
            kurslar.Show();
            this.Hide();

        }

        private void Kapatbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        UyelerManager uyelerManager = new UyelerManager();
        private void UyelikForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate=DateTime.Now;
            dateTimePicker2.MinDate = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result = uyelerManager.UpdateUyelik(_uye.Id,dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString(),comboBox1.SelectedItem.ToString());
            if (result==1)
            {
                MessageBox.Show("Üyelik Güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
