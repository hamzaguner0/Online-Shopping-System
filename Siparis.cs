using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineAlisverisSistemi
{
    public sealed class SiparisKalemi
    {
        internal SiparisKalemi(Urun urun)
        {
            Isim = urun.Isim;
            BirimFiyat = urun.Fiyat;
        }

        public string Isim { get; }
        public decimal BirimFiyat { get; }
    }

    public class Siparis
    {
        // Orders are created through the cart so the stock reservation flow cannot be bypassed.
        internal Siparis(int siparisNo, string teslimatAdresi, IEnumerable<Urun> urunler)
        {
            if (siparisNo <= 0) throw new ArgumentOutOfRangeException(nameof(siparisNo));
            if (string.IsNullOrWhiteSpace(teslimatAdresi)) throw new ArgumentException("Teslimat adresi gereklidir.", nameof(teslimatAdresi));
            if (urunler == null) throw new ArgumentNullException(nameof(urunler));
            var kalemler = urunler.Select(urun => new SiparisKalemi(urun)).ToList();
            if (kalemler.Count == 0) throw new InvalidOperationException("Boş sepetten sipariş oluşturulamaz.");
            SiparisNo = siparisNo;
            TeslimatAdresi = teslimatAdresi.Trim();
            Urunler = kalemler.AsReadOnly();
            ToplamFiyat = kalemler.Sum(kalem => kalem.BirimFiyat);
        }

        public int SiparisNo { get; }
        public string TeslimatAdresi { get; }
        public IReadOnlyList<SiparisKalemi> Urunler { get; }
        public decimal ToplamFiyat { get; }

        public void SiparisDetayiGoster()
        {
            Console.WriteLine($"\n--- Sipariş {SiparisNo} ---");
            foreach (var kalem in Urunler) Console.WriteLine($"- {kalem.Isim}: {kalem.BirimFiyat:N2} TL");
            Console.WriteLine($"Toplam: {ToplamFiyat:N2} TL");
            Console.WriteLine($"Teslimat: {TeslimatAdresi}");
        }
    }
}
