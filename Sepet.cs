using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAlisverisSistemi
{
    public class Sepet
    {
        private List<Urun> urunler = new List<Urun>();

        public void UrunEkle(Urun urun)
        {
            if (urun.Stok > 0)
            {
                urunler.Add(urun);
                urun.Stok--;  
                Console.WriteLine($"{urun.Isim} sepete eklendi.");
            }
            else
            {
                Console.WriteLine($"{urun.Isim} stokta yok!");
            }
        }

        public void SepetiGoster()
        {
            Console.WriteLine("Sepetiniz:");
            foreach (var urun in urunler)
            {
                Console.WriteLine($"- {urun.Isim}, Fiyat: {urun.Fiyat} TL");
            }
        }
    }

}
