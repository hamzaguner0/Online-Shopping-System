using System;
using OnlineAlisverisSistemi;

internal static class DomainTests
{
    private static int passed;
    private static void Equal<T>(T expected, T actual)
    {
        if (!object.Equals(expected, actual)) throw new Exception($"Expected {expected}, got {actual}");
    }
    private static void Throws<T>(Action action) where T : Exception
    {
        try { action(); } catch (T) { return; }
        throw new Exception("Expected " + typeof(T).Name);
    }
    private static void Test(string name, Action action)
    {
        action(); passed++; Console.WriteLine("PASS " + name);
    }
    public static int Main()
    {
        try
        {
            Test("Invalid product values rejected", () => {
                Throws<ArgumentException>(() => new Urun(" ", 1m, 1));
                Throws<ArgumentOutOfRangeException>(() => new Urun("Test", -1m, 1));
                Throws<ArgumentOutOfRangeException>(() => new Urun("Test", 1m, -1));
                Throws<ArgumentOutOfRangeException>(() => new Elektronik("Test", 1m, 1, -1));
                Throws<ArgumentException>(() => new Giyim("Test", 1m, 1, " "));
            });
            Test("Money retains decimal precision", () => {
                var sepet = new Sepet(); sepet.UrunEkle(new Urun("A", 0.10m, 1)); sepet.UrunEkle(new Urun("B", 0.20m, 1));
                Equal(0.30m, sepet.ToplamFiyat); Equal(0.30m, sepet.SiparisOlustur(1, "Demo").ToplamFiyat);
            });
            Test("Last stock cannot be oversold", () => {
                var urun = new Urun("A", 1m, 1); var first = new Sepet(); var second = new Sepet();
                Equal(true, first.UrunEkle(urun)); Equal(false, second.UrunEkle(urun)); Equal(0, urun.Stok); Equal(0, second.Urunler.Count);
            });
            Test("Removal restores one reservation", () => {
                var urun = new Urun("A", 1m, 2); var sepet = new Sepet(); sepet.UrunEkle(urun); sepet.UrunEkle(urun);
                Equal(true, sepet.UrunCikar(urun)); Equal(1, urun.Stok); Equal(1, sepet.Urunler.Count);
            });
            Test("Absent removal does not change stock", () => {
                var urun = new Urun("A", 1m, 2); Equal(false, new Sepet().UrunCikar(urun)); Equal(2, urun.Stok);
            });
            Test("Clear restores all reserved units once", () => {
                var urun = new Urun("A", 1m, 2); var sepet = new Sepet(); sepet.UrunEkle(urun); sepet.UrunEkle(urun);
                sepet.Temizle(); sepet.Temizle(); Equal(2, urun.Stok); Equal(0m, sepet.ToplamFiyat);
            });
            Test("Checkout empties cart without restoring sold stock", () => {
                var urun = new Urun("A", 1m, 2); var sepet = new Sepet(); sepet.UrunEkle(urun); sepet.UrunEkle(urun);
                var siparis = sepet.SiparisOlustur(1, "Demo"); sepet.Temizle(); Equal(0, urun.Stok); Equal(0, sepet.Urunler.Count); Equal(2, siparis.Urunler.Count);
            });
            Test("Order snapshots price independently from product", () => {
                var urun = new Urun("A", 2.50m, 1); var sepet = new Sepet(); sepet.UrunEkle(urun); var siparis = sepet.SiparisOlustur(1, "Demo");
                urun.FiyatGuncelle(99m); Equal(2.50m, siparis.ToplamFiyat); Equal(2.50m, siparis.Urunler[0].BirimFiyat);
            });
            Test("Invalid checkout preserves cart and reservation", () => {
                var urun = new Urun("A", 1m, 1); var sepet = new Sepet(); sepet.UrunEkle(urun);
                Throws<ArgumentOutOfRangeException>(() => sepet.SiparisOlustur(0, "Demo"));
                Throws<ArgumentException>(() => sepet.SiparisOlustur(1, " ")); Equal(1, sepet.Urunler.Count); Equal(0, urun.Stok);
            });
            Test("Empty and repeated checkout rejected", () => {
                var sepet = new Sepet(); Throws<InvalidOperationException>(() => sepet.SiparisOlustur(1, "Demo"));
                sepet.UrunEkle(new Urun("A", 1m, 1)); sepet.SiparisOlustur(1, "Demo"); Throws<InvalidOperationException>(() => sepet.SiparisOlustur(2, "Demo"));
            });
            Test("Null products and negative repricing rejected", () => {
                var sepet = new Sepet(); Throws<ArgumentNullException>(() => sepet.UrunEkle(null)); Throws<ArgumentNullException>(() => sepet.UrunCikar(null));
                var urun = new Urun("A", 1m, 1); Throws<ArgumentOutOfRangeException>(() => urun.FiyatGuncelle(-1m)); Equal(1m, urun.Fiyat);
            });
            Console.WriteLine($"All {passed} domain scenarios passed."); return 0;
        }
        catch (Exception ex) { Console.Error.WriteLine(ex); return 1; }
    }
}
