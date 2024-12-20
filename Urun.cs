using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAlisverisSistemi
{
    public class Urun
    {
        public string Isim;
        public double Fiyat;
        public int Stok;

        public virtual void BilgiGoster()
        {
            Console.WriteLine($"Ürün: {Isim}, Fiyat: {Fiyat} TL, Stok: {Stok} adet");
        }
    }
}
