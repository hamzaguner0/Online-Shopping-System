# Online Shopping System · C# OOP Demo

C# ve .NET Framework 4.7.2 ile yazılmış **konsol uygulaması**. Ürün, kullanıcı, sepet ve sipariş nesneleri üzerinden nesne yönelimli programlama pratiği yapar.

- `Urun` taban sınıfı; `Elektronik`, `Giyim` ve `temelUrun` ürün türleri.
- Kalıtım ve `BilgiGoster()` override'larıyla polimorfizm.
- `Kullanici`, `Sepet` ve `Siparis` üzerinden örnek alışveriş akışı.

Web mağazası, gerçek ödeme, hesap doğrulama, kalıcı veritabanı veya üretim e-ticaret sistemi içermez. Ürün alanları doğrudan açık olduğu için tam kapsülleme örneği olarak tanımlanmaz.

## Çalıştırma

Windows'ta Visual Studio ve .NET Framework 4.7.2 targeting pack ile `OnlineAlisverisSistemi.sln` dosyasını açın ve çalıştırın. Uygun MSBuild/.NET SDK kurulmuşsa:

```powershell
dotnet build OnlineAlisverisSistemi.csproj --configuration Release
.\bin\Release\OnlineAlisverisSistemi.exe
```

Örnek kullanıcı ve sipariş verileri kurmacadır. `bin/`, `obj/`, `.vs/` ve kişisel IDE ayarları kaynak kontrolü dışında tutulur. Temiz derleme için framework targeting pack gerekir.
