using System;
using System.Globalization;

namespace OnlineAlisverisSistemi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("tr-TR");
            var kullanici = new Kullanici { Isim = "Örnek Kullanıcı", Email = "demo@example.com" };
            kullanici.KullaniciBilgiGoster();
            var sepet = new Sepet();
            Urun[] urunler = {
                new Elektronik("Laptop", 15000m, 5, 2),
                new Giyim("T-shirt", 200m, 10, "M"),
                new temelUrun("Kalem", 10m, 100)
            };
            foreach (var urun in urunler)
            {
                urun.BilgiGoster();
                if (!sepet.UrunEkle(urun)) Console.WriteLine($"{urun.Isim} stokta yok.");
            }
            sepet.SepetiGoster();
            var siparis = sepet.SiparisOlustur(1001, "Örnek teslimat adresi");
            siparis.SiparisDetayiGoster();
            if (!Console.IsInputRedirected && Array.IndexOf(args, "--non-interactive") < 0) Console.ReadLine();
        }
    }
}
