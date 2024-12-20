using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAlisverisSistemi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Kullanici Ahmet = new Kullanici
            {
                Isim = "Ahmet",
                Email = "ahmet@gmail.com"
            };

            Ahmet.KullaniciBilgiGoster();

            Sepet sepet = new Sepet();

            Elektronik laptop = new Elektronik
            {
                Isim = "Laptop",
                Fiyat = 15000,
                Stok = 5,
                GarantiSuresi = 2
            };

            laptop.BilgiGoster();

            sepet.UrunEkle(laptop);

            Giyim tshirt = new Giyim
            {
                Isim = "T-shirt",
                Fiyat = 200,
                Stok = 10,
                Beden = "M"
            };

            tshirt.BilgiGoster();
            sepet.UrunEkle(tshirt);

            temelUrun kalem = new temelUrun
            {
                Isim = "Kalem",
                Fiyat = 10,
                Stok = 100
            };

            sepet.UrunEkle(kalem);
            kalem.BilgiGoster();



            sepet.SepetiGoster();

            Siparis Siparis1 = new Siparis
            {
                SiparisNo = 1001,
                TeslimatAdresi = "Ankara"
            };
            Siparis1.Urunler.Add(laptop);
            Siparis1.Urunler.Add(tshirt);
            Siparis1.Urunler.Add(kalem);


            Siparis1.SiparisDetayiGoster();

            Console.ReadLine();
        }
    }
}
