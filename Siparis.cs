using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAlisverisSistemi
{
    public class Siparis
    {
        public int SiparisNo { get; set; }
        public List<Urun> Urunler { get; set; } = new List<Urun>();
        public double ToplamFiyat
        {
            get
            {
                double toplam = 0;
                foreach (var urun in Urunler)
                {
                    toplam += urun.Fiyat;
                }
                return toplam;
            }
        }


        public string TeslimatAdresi { get; set; }


        public void SiparisDetayiGoster()
        {
            Console.WriteLine("\n--- Online Sipariş Detayları ---");
            Console.WriteLine($"Sipariş No: {SiparisNo}");
            Console.WriteLine("Ürünler:");
            foreach (var urun in Urunler)
            {
                urun.BilgiGoster();
            }
            Console.WriteLine($"Toplam Fiyat: {ToplamFiyat} TL");


            Console.WriteLine($"Teslimat Adresi: {TeslimatAdresi}");
            
        }
    }
}
