using System;

namespace OnlineAlisverisSistemi
{
    public class Urun
    {
        public Urun(string isim, decimal fiyat, int stok)
        {
            if (string.IsNullOrWhiteSpace(isim)) throw new ArgumentException("Ürün adı gereklidir.", nameof(isim));
            if (stok < 0) throw new ArgumentOutOfRangeException(nameof(stok));
            Isim = isim.Trim();
            FiyatGuncelle(fiyat);
            Stok = stok;
        }

        public string Isim { get; }
        public decimal Fiyat { get; private set; }
        public int Stok { get; private set; }

        public void FiyatGuncelle(decimal fiyat)
        {
            if (fiyat < 0) throw new ArgumentOutOfRangeException(nameof(fiyat));
            Fiyat = fiyat;
        }

        internal bool StokAyir()
        {
            if (Stok == 0) return false;
            Stok--;
            return true;
        }

        internal void StokIade()
        {
            checked { Stok++; }
        }

        public virtual void BilgiGoster()
        {
            Console.WriteLine($"Ürün: {Isim}, Fiyat: {Fiyat:N2} TL, Stok: {Stok} adet");
        }
    }
}
