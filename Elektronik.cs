using System;

namespace OnlineAlisverisSistemi
{
    public class Elektronik : Urun
    {
        public Elektronik(string isim, decimal fiyat, int stok, int garantiSuresi)
            : base(isim, fiyat, stok)
        {
            if (garantiSuresi < 0) throw new ArgumentOutOfRangeException(nameof(garantiSuresi));
            GarantiSuresi = garantiSuresi;
        }

        public int GarantiSuresi { get; }

        public override void BilgiGoster()
        {
            Console.WriteLine($"Elektronik: {Isim}, Fiyat: {Fiyat:N2} TL, Stok: {Stok}, Garanti: {GarantiSuresi} yıl");
        }
    }
}
