using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikasi_bus_express
{
    public class Penumpang
    {
        public Penumpang()
        {
            Kursi = new List<int>();
        }

        public string NamaPenumpang { get; set; }
        public string NoTelepon { get; set; }
        public List<int> Kursi { get; set; }
        public double Price 
        {
            get
            {
                return Kursi.Count; 
            }
        }
        public override string ToString()
        {
            return this.NamaPenumpang;
        }
    }
}


