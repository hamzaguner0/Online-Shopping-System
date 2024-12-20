using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAlisverisSistemi
{
    public class temelUrun: Urun
    {
        public override void BilgiGoster()
        {
            Console.WriteLine($"Temel Ürün: {Isim}, Fiyat: {Fiyat} TL, Stok: {Stok} adet");
        }
    }
}
