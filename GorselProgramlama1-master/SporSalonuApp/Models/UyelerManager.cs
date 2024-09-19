using SporSalonuApp.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonuApp.Models
{
    public class UyelerManager
    {
        DatabaseSqlConnection db;
        public int InsertUye(Uyeler uye)
        {
            db = new DatabaseSqlConnection();
            string query = $"INSERT INTO Uyeler (Name,Surname,Gender,Username,Email,Password,Boy,Kilo,Yas) VALUES ('{uye.Name}', '{uye.Surname}', '{uye.Gender}', '{uye.Username}', '{uye.Email}', '{uye.Password}', '{uye.Boy}', '{uye.Kilo}', '{uye.Yas}')";
            int result = db.ExecuteQueries(query);
            return result;
        }

        public int UpdateUye(Uyeler uye)
        {
            MessageBox.Show("Üye Güncellendi."+ uye.Name+ uye.Surname+ uye.Username+ uye.Password+" id "+uye.Id);
            db = new DatabaseSqlConnection();
            string query = $"UPDATE Uyeler SET Name='{uye.Name}',Surname='{uye.Surname}',Username='{uye.Username}',Password='{uye.Password}' WHERE Id='{uye.Id}'";
            int result = db.ExecuteQueries(query);
            Console.Write(query);
            return result;
        }
        public int UpdateUyeKurs(int id,String kurs)
        {
            db = new DatabaseSqlConnection();
            string query = $"UPDATE Uyeler SET Kurs='{kurs}'WHERE Id='{id}'";
            int result = db.ExecuteQueries(query);
            return result;
        }
        public int UpdateUyelik(int id,String baslangic,String bitis,String uyelik) {

            db = new DatabaseSqlConnection();
            string query = $"UPDATE Uyeler SET BaslangicTarihi='{baslangic}',BitisTarihi='{bitis}',UyeTipi='{uyelik}' WHERE Id='{id}'";
            int result = db.ExecuteQueries(query);
            return result;
        }

        public int DeleteUye(int uyeId)
        {
            db = new DatabaseSqlConnection();
            string query = $"delete FROM Uyeler WHERE Id='{uyeId}'";
            int result = db.ExecuteQueries(query);
            return result;
        }

        public DataTable GetAllUyeler()
        {
            db = new DatabaseSqlConnection();
            string query = "SELECT * FROM Uyeler";
            var uyeler = db.ShowDataInGridView(query);
            List<Uyeler> uyeList = new List<Uyeler>();

            for (int i = 0; i < uyeler.Rows.Count; i++)
            {
                Uyeler uye = new Uyeler
                {
                    Id = Convert.ToInt32(uyeler.Rows[i][0]),
                    Name = uyeler.Rows[0][1].ToString(),
                    Surname = uyeler.Rows[0][2].ToString(),
                    Gender = Convert.ToInt32(uyeler.Rows[0][3]),
                    Username = uyeler.Rows[0][4].ToString(),
                    Email = uyeler.Rows[0][5].ToString(),
                    Password = uyeler.Rows[0][6].ToString(),
                    Boy = Convert.ToDouble(uyeler.Rows[0][7]),
                    Kilo = Convert.ToDouble(uyeler.Rows[0][8]),
                    Yas = Convert.ToInt32(uyeler.Rows[0][9])
                };
                uyeList.Add(uye);
            }

            // LINQ
            // uyeList.Select(u => u.Name == "Ahmet").ToList();
            //uyeList.Where(x => x.Id == 1);
            //uyeList.FirstOrDefault();
            //uyeList.Any(x => x.Gender == 1); // herhangi bir erkek varsa true
            //uyeList.All(x => x.Gender == 1); // tüm kayıtlar erkekse true

            
            return uyeler;
        }

        public Uyeler GetUyeById(int id)
        {
            db = new DatabaseSqlConnection();
            string query = $"SELECT * FROM Uyeler WHERE Id = {id}";
            var uyeFromDb = db.ShowDataInGridView(query);
            Uyeler uye = new Uyeler
            {
                Id = Convert.ToInt32(uyeFromDb.Rows[0][0]),
                Name = uyeFromDb.Rows[0][1].ToString(),
                Surname = uyeFromDb.Rows[0][2].ToString(),
                Gender = Convert.ToInt32(uyeFromDb.Rows[0][3]),
                Username = uyeFromDb.Rows[0][4].ToString(),
                Email = uyeFromDb.Rows[0][5].ToString(),
                Password = uyeFromDb.Rows[0][6].ToString(),
                Boy = Convert.ToDouble(uyeFromDb.Rows[0][7]),
                Kilo = Convert.ToDouble(uyeFromDb.Rows[0][8]),
                Yas = Convert.ToInt32(uyeFromDb.Rows[0][9])
            };
            return uye;
        }

        public Uyeler Login(string username, string password)
        {
            Uyeler result;
            try
            {
                db = new DatabaseSqlConnection();
                string query = $"SELECT * FROM Uyeler WHERE Username = '{username}' AND Password = '{password}'";
                var uyeFromDb = db.ShowDataInGridView(query);
                result = new Uyeler
                {
                    Id = Convert.ToInt32(uyeFromDb.Rows[0][0]),
                    Name = uyeFromDb.Rows[0][1].ToString(),
                    Surname = uyeFromDb.Rows[0][2].ToString(),
                    Gender = Convert.ToInt32(uyeFromDb.Rows[0][3]),
                    Username = uyeFromDb.Rows[0][4].ToString(),
                    Email = uyeFromDb.Rows[0][5].ToString(),
                    Password = uyeFromDb.Rows[0][6].ToString(),
                    Boy = Convert.ToDouble(uyeFromDb.Rows[0][7]),
                    Kilo = Convert.ToDouble(uyeFromDb.Rows[0][8]),
                    Yas = Convert.ToInt32(uyeFromDb.Rows[0][9])
                };
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
