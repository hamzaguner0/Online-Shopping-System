using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAlisverisSistemi
{
    public class Kullanici
    {
        public string Isim { get; set; }
        public string Email { get; set; }

        
        public virtual void KullaniciBilgiGoster()
        {
            Console.WriteLine($"Kullanıcı: {Isim}, Email: {Email}");
        }
    }
}
