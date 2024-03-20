using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp_query
{
    ETicaretContext context = new();

    #region AsNoTracking Metodu
    //Context üzerinden gelen tüm datalar Change Tracker mekanizması tarafından takip edilmektedir.

    //Change Tracker, takip ettiği nesnelerin sayısıyla doğru orantılı olacak şekilde bir maliyete sahiptir. O yüzden üzerinde işlem yapılmayacak verilerin takip edilmesi bizlere lüzumsuz yere bir maliyet ortaya çıkaracaktır.

    //AsNoTracking metodu, context üzerinden sorgu neticesinde gelecek olan verilerin Change Tracker tarafından takip edilmesini engeller.

    //AsNoTracking metodu ile Change Tracker'ın ihtiyaç olmayan verilerdeki maliyetini törpülemiş oluruz.

    //AsNoTracking fonksiyonu ile yapılan sorgulamalarda, verileri elde edebilir, bu verileri istenilen
    //noktalarda kullanabilir lakin veriler üzerinde herhangi bir değişiklik/update işlemi yapamayız.

    var kullanicilar = await context.Kullanicilar.AsNoTracking().ToListAsync();
    foreach (var kullanici in kullanicilar)
    {
        Console.WriteLine(kullanici.Adi);
        kullanici.Adi = $"yeni-{kullanici.Adi}";
        context.Kullanicilar.Update(kullanici);
    }
    await context.SaveChangesAsync();
    #endregion
}
