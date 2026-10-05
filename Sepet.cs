using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineAlisverisSistemi
{
    /// <summary>Single-threaded demo: adding reserves stock; removal restores it.</summary>
    public class Sepet
    {
        private readonly List<Urun> urunler = new List<Urun>();

        public IReadOnlyList<Urun> Urunler => urunler.AsReadOnly();
        public decimal ToplamFiyat => urunler.Sum(urun => urun.Fiyat);

        public bool UrunEkle(Urun urun)
        {
            if (urun == null) throw new ArgumentNullException(nameof(urun));
            if (!urun.StokAyir()) return false;
            urunler.Add(urun);
            return true;
        }

        public bool UrunCikar(Urun urun)
        {
            if (urun == null) throw new ArgumentNullException(nameof(urun));
            if (!urunler.Remove(urun)) return false;
            urun.StokIade();
            return true;
        }

        public void Temizle()
        {
            foreach (var urun in urunler) urun.StokIade();
            urunler.Clear();
        }

        public Siparis SiparisOlustur(int siparisNo, string teslimatAdresi)
        {
            // Validate and snapshot before changing cart state; failures preserve reservations.
            var siparis = new Siparis(siparisNo, teslimatAdresi, urunler);
            urunler.Clear();
            return siparis;
        }

        public void SepetiGoster()
        {
            Console.WriteLine("Sepetiniz:");
            foreach (var urun in urunler) Console.WriteLine($"- {urun.Isim}, Fiyat: {urun.Fiyat:N2} TL");
            Console.WriteLine($"Sepet toplamı: {ToplamFiyat:N2} TL");
        }
    }
}
