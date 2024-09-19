using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporSalonuApp.Models
{
    public class Uyeler
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Gender { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double Boy { get; set; }
        public double Kilo { get; set; }

        public int Yas { get; set; }
        public String BaslangicTarihi { get; set; }

        public String BitisTarihi { get; set; }


    }
}
