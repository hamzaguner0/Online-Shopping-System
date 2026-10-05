using System;

namespace OnlineAlisverisSistemi
{
    public class Giyim : Urun
    {
        public Giyim(string isim, decimal fiyat, int stok, string beden)
            : base(isim, fiyat, stok)
        {
            if (string.IsNullOrWhiteSpace(beden)) throw new ArgumentException("Beden gereklidir.", nameof(beden));
            Beden = beden.Trim();
        }

        public string Beden { get; }

        public override void BilgiGoster()
        {
            Console.WriteLine($"Giyim: {Isim}, Fiyat: {Fiyat:N2} TL, Stok: {Stok}, Beden: {Beden}");
        }
    }
}
