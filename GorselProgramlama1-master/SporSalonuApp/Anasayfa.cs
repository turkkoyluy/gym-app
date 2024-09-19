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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SporSalonuApp
{
    public partial class Anasayfa : Form
    {
        Uyeler _uye;
        public Anasayfa(Uyeler uye)
        {
            _uye = uye;
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProfilButton_Click(object sender, EventArgs e)
        {
            ProfilForm profil = new ProfilForm(_uye);
            profil.Show();
            this.Hide();
        }
        List<String> antrenmanlarKol = new List<String>();
        List<String> antrenmanlarGogus = new List<String>();
        List<String> antrenmanlarOmuz = new List<String>();
        List<String> antrenmanlarSırt = new List<String>();
        List<String> antrenmanlarKardiyo = new List<String>();
        Random random = new Random();
        
        private void Anasayfa_Load(object sender, EventArgs e)
        {
            label2.Text = "Merhaba "+_uye.Name+", \r\nGörünüşe Göre Formdasın...\r\n";

            int kol= random.Next(0,4);
            int gogus = random.Next(0,5);
            int omuz = random.Next(0,5);
            int sırt = random.Next(0,6);
            int kardiyo = random.Next(0,9);
            int kardiyo1 = random.Next(0, 9);
            int kardiyo2 = random.Next(0, 9);
            int kardiyo3 = random.Next(0, 9);




            antrenmanlarKol.Add("Double-arm high-cable curl");
            antrenmanlarKol.Add("Dumbbell preacher curl");
            antrenmanlarKol.Add("Incline dumbbell curl");
            antrenmanlarKol.Add("Standing barbell curl");

            antrenmanlarGogus.Add("Incline barbell press");
            antrenmanlarGogus.Add("Incline dumbbell press");
            antrenmanlarGogus.Add("Cable crossover");
            antrenmanlarGogus.Add("Machine bench press");
            antrenmanlarGogus.Add("Dumbbell bench press");
            antrenmanlarGogus.Add("Incline Smith Machine Bench Press");

            antrenmanlarOmuz.Add("DB Front Raise Egzersizi");
            antrenmanlarOmuz.Add("DB Lateral Raise Hareketi");
            antrenmanlarOmuz.Add("Seated DB Shoulder Press Egzersizi");
            antrenmanlarOmuz.Add("Cable Upright Row Hareketi");
            antrenmanlarOmuz.Add("Face-Pull Hareketi");

            antrenmanlarSırt.Add("Lat Pulldown");
            antrenmanlarSırt.Add("Cable Rope Row");
            antrenmanlarSırt.Add("Ters Tutuş Barbell Row");
            antrenmanlarSırt.Add("Rack Pull");
            antrenmanlarSırt.Add("Seated Cable Row");
            antrenmanlarSırt.Add("Geniş Tutuş Barfiks");

            antrenmanlarKardiyo.Add("WALKİNG LUNGE HAREKETİ");
            antrenmanlarKardiyo.Add("HAREKETLİ ŞINAV");
            antrenmanlarKardiyo.Add("UZATMALI MEKİK");
            antrenmanlarKardiyo.Add("AĞIRLIKLA SUMO SQUAT HAREKETİ");
            antrenmanlarKardiyo.Add("RENEGADE HAREKETİ SETİ");
            antrenmanlarKardiyo.Add("DÖNEREK YAN PLANK");
            antrenmanlarKardiyo.Add("KİCKİNG LUNGE HAREKETİ");
            antrenmanlarKardiyo.Add("CROSS-CRAWL");
            antrenmanlarKardiyo.Add("WALKİNG PLANK");

            label6.Text = antrenmanlarKol[kol];
            label7.Text = antrenmanlarGogus[gogus];
            label8.Text = antrenmanlarOmuz[omuz];
            label9.Text = antrenmanlarSırt[sırt];

            label10.Text = antrenmanlarKardiyo[kardiyo];
            label11.Text = antrenmanlarKardiyo[kardiyo1];
            label12.Text = antrenmanlarKardiyo[kardiyo2];
            label13.Text = antrenmanlarKardiyo[kardiyo3];


        }
        

        private void panel6_MouseClick(object sender, MouseEventArgs e)
        {
               MessageBox.Show("Günlük Alınması Gereken Kalori: "+kalori(_uye.Boy,_uye.Kilo,_uye.Yas,_uye.Gender));
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }



        private void Uyelikbutton_Click(object sender, EventArgs e)
        {
            UyelikForm uyelikForm = new UyelikForm(_uye);
            uyelikForm.Show();
            this.Hide();
        }

        private void KurslarButton_Click(object sender, EventArgs e)
        {
            Kurslar kurlar = new Kurslar(_uye);
            kurlar.Show();
            this.Hide();
        }

        private void Kapatbutton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Uygulamadan çıkmak istiyor musunuz?", "çıkış Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void panel8_MouseClick(object sender, MouseEventArgs e)
        {
            double oran = boyKilo(Convert.ToDouble(_uye.Boy), Convert.ToDouble(_uye.Kilo));
            if (oran < 18.5)
            {
                MessageBox.Show("Boy Kilo İndeksiniz ZAYIF. Lütfen yemek programını düzgün uygulayınız.");
            }
            else if (oran < 25)
            {      
                MessageBox.Show("Boy Kilo İndeksiniz NORMAL. Lütfen yemek programını uygulamaya devam ediniz.");
            }
            else if (oran < 30)
            {
                MessageBox.Show("Boy Kilo İndeksiniz KİLOLU. Lütfen yemek programını düzgün uygulayınız.");
            }
            else
            {
                MessageBox.Show("Boy Kilo İndeksiniz OBEZ. Lütfen yemek programını düzgün uygulayınız ve bir doktora başvurunuz.");
            }
        }

        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Günde 8- 15 bardak ( 1.5- 3 litre) su tüketimi idealdir.");
        }
        private double boyKilo(double boy, double kilo)
        {
            return (Math.Pow(boy, 2) / kilo);
        }
        private double kalori(double boy,double kilo,int yas,int cinsiyet)
        {
            if (cinsiyet==1)
            {
                return (66.5+(13.75*kilo)+(5*boy)-(6.75*yas))*1.72;
            }
            else
            {
                return (655.1 + (9.56 * kilo) + (1.85 * boy) - (4.67 * yas)) * 1.72;
            }
            
        }
    }
}
