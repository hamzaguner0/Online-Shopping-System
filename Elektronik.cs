using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAlisverisSistemi
{
    public class Elektronik: Urun
    {
        public int GarantiSuresi { get; set; } 

        public override void BilgiGoster()
        {
            Console.WriteLine($"Elektronik Ürün: {Isim}, Fiyat: {Fiyat} TL, Stok: {Stok} adet, Garanti Süresi: {GarantiSuresi} yıl");
        }
    }
}
