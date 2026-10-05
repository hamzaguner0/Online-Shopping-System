# Online Shopping System · C# OOP Demo

C# ve .NET Framework 4.7.2 ile yazılmış konsol uygulaması. Ürün, sepet ve sipariş nesneleri üzerinden kapsülleme, kalıtım ve polimorfizm pratiği yapar. Üretim e-ticaret sistemi veya web API değildir.

## Model ve davranış

- `Urun`: doğrulanan ad/fiyat/stok; fiyat `decimal`, stok dışarıdan doğrudan değiştirilemez.
- `Elektronik`, `Giyim`, `temelUrun`: türetilmiş ürünler ve `BilgiGoster()` override'ları.
- `Sepet`: her ekleme bir adet stok ayırır; çıkarma/temizleme ayrılan stokları iade eder. Stoksuz ürün eklenmez.
- `Siparis`: sepetten oluşturulur; ad ve fiyatı değişmez sipariş kalemlerine kopyalar. Sonraki ürün fiyatı değişiklikleri geçmiş sipariş tutarını değiştirmez. Başarılı sipariş sepeti boşaltır; aynı sepet ikinci kez siparişe dönüşmez.

Bu stok akışı tek süreç/tek iş parçacığı için eğitim modelidir. Veritabanı işlemi, eşzamanlı kullanıcı, rezervasyon süresi, gerçek ödeme, oturum açma veya vergi/kargo hesaplaması içermez.

## Çalıştırma ve kontroller

Windows, .NET Framework 4.7.2 targeting pack ve uyumlu MSBuild/.NET SDK gerekir. Visual Studio ile çözümü açabilir veya şu komutları kullanabilirsiniz:

```powershell
git clone https://github.com/hamzaguner0/Online-Shopping-System.git
cd Online-Shopping-System
dotnet build OnlineAlisverisSistemi.csproj --configuration Release
.\bin\Release\OnlineAlisverisSistemi.exe --non-interactive
dotnet build tests/DomainTests.csproj --configuration Release
.\tests\bin\Release\DomainTests.exe
```

Bağımsız konsol test koşucusu 11 davranış senaryosunu kontrol eder: parasal hassasiyet, son stok, stok iadesi, siparişin fiyatı sabitlemesi, hatalı siparişte sepetin korunması ve geçersiz girdiler. Bu koşucu `dotnet test` test adaptörü kullanmaz; başarısızlıkta sıfırdan farklı çıkış kodu döndürür.

Örnek kullanıcı/sipariş verileri kurmacadır. `bin/`, `obj/`, `.vs/` ve kişisel ayarlar Git dışında tutulur.

## Geliştirme geçmişi

İlk sürüm temel OOP öğrenme örneğiydi. 5 Ekim 2026 düzenlemesi doğrulama, parasal `decimal` kullanımı, sepet stok iadesi, değişmez sipariş tutarı ve davranış kontrollerini ekledi.
