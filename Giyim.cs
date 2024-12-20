using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAlisverisSistemi
{
    public class Giyim: Urun
    {
        public string Beden { get; set; } 

        public override void BilgiGoster()
        {
            Console.WriteLine($"Giyim Ürün: {Isim}, Fiyat: {Fiyat} TL, Stok: {Stok} adet, Beden: {Beden}");
        }
    }
}
