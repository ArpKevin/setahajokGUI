using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace setahajokGUI
{
    internal class Hajo
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int PassengerCapacity { get; set; }
        public int FeePrice { get; set; }

        public Hajo(string sor)
        {
            var x = sor.Split(',');

            Number = int.Parse(x[0]);
            Name = x[1];
            Type = x[2];
            PassengerCapacity = int.Parse(x[3]);
            FeePrice = int.Parse(x[4]);
        }

        public override string ToString()
        {
            return $"Sorszám: {Number}, Név: {Name}, Típus: {Type}, Utaskapacitás: {PassengerCapacity} fő, Bérleti díj: {FeePrice} FT";
        }
    }

    
}
