# Patika+ Week5 Kapanış Uygulaması
Merhaba,
Bu proje C# ile Patika+ 5.hafta Kapanışı konuların tekrarı için yapılmış bir uygulamadır.

## 📚 Proje Hakkında
Bu proje, aşağıdaki konuları öğrenmeye yardımcı olmak için tasarlanmıştır:
- Basit bir C# programı yazmak
- C# konsol uygulamasının yapısını anlamak
- List yapısını öğrenmek
- Döngüler'i kullanmak
- Class Yapısını kullanmak
- Encapsulation yapısını kullanmak


## İstenilen Görev
Bir araba fabrikasonda araba üretiyoruz.

Araba -> Üretim Tarihi, Seri Numarası, Marka, Model, Renk, Kapı Sayısı

Yukarıdaki propertylere sahip bir Araba classı tanımlayalım.

Program akışı:

1-  Konsol ekranından kullanıcıya araba üretmek isteyip istemediğini soralım. 
  - Üretmek istiyorsa e, istemiyorsa h harfi ile yanıt versin.
  - Büyük - Küçük harf duyarlılığını ortadan kaldıralım.
  - Geçersiz bir cevap verirse, bu cevabın geçersiz olduğunu söyleyerek aynı soruyu tekrar yöneltelim.
  
2- Kullanıcının cevabı hayır programı sonlandıralım.
  - evet ise bir araba nesnesi üretip özelliklerini konsol ekranından kullanıcıya girdirelim.
    
3- Üretim Tarihi değeri araba üretilirken otomatik olarak o an olarak atanacak.
4- Kapı Sayısı için sayısal olmayan bir değer atanılmaya çalışılırsa
  - programın exception fırlatmasını engelleyelim, uyarı mesajı verelim ve kullanıcıyı yeniden o satıra yönlendirelim. (goto komutunu araştırınız.)
5- Oluşturulan araba nesnesini arabalar isimli bir listeye atayınız.
6- Kullanıcıya başka araba oluşturmak isteyip istemediğini sorunuz,
  - evet ise program akışında 2. aşamaya geri dönünüz ve yeni bir araba üretip listeye ekleyiniz.
  - Cevap hayır ise arabalar listesinin bütün elemanlarının Seri numaralarını ve markalarını yazdırınız

  





## Doğru Çalışınca Oluşan Ekran Görüntüsü
![resim](https://github.com/user-attachments/assets/0b296abb-a49d-4161-b97b-f5501a1815cb)



## Kod 
```csharp

    // Film adı ve IMDb puanını tutan sınıf özellikleri
    public class Film
    {
        public string Name { get; set; }
        public double ImdbScore { get; set; }
    }

    public class Imdb
    {
        // Filmleri saklamak için kullanılan bir List yapısı
        private List<Film> films = new List<Film>();

        // Film ekleme fonksiyonu
        public void AddFilm()
        {
            bool isContinue = true;  // Kullanıcı devam etmek istediği sürece döngü devam edecek

            while (isContinue)
            {
                Film film = new Film();   // yeni bir film nesnesi oluşturuldu Polymorphism

                Console.Write("Film Adı Gir: ");  // kullanıcıdan film adı alındı
                film.Name = Console.ReadLine();  // film'in Name Property'sine atandı

                Console.Write("IMDB Puanı Gir: ");   // imdb puanı alındı
                if (double.TryParse(Console.ReadLine(), out double score)) // TryParse ile kontrol yapıldı
                {
                    film.ImdbScore = score;  // Eğer double bir sayı ise film'in ImdbScore propertisine atanacak
                }
                else
                {
                    Console.WriteLine("Geçersiz IMDB puanı! Lütfen sayı girin."); //değilse uyarı vericek ve tekrar soraca
                    continue;
                }

                films.Add(film);  // oluşturulan film nesnesi ad ve imdb puanı alındıktan sonra films listesine eklendi

                Console.Write("Yeni Film Eklemek İstiyor Musunuz? (E / H): ");  // devam edip etmeyeceği soruluyor
                char response = char.Parse(Console.ReadLine().ToUpper());

                if (response != 'E')    // eğer E karakteri harici bişey girerse döngü false olucak ve sonlanacak
                    isContinue = false;
            }
        }

        // Bütün filmleri listeleme fonksiyonu
        public void PrintAllFilms()
        {
            foreach (var film in films)  // Foreach döngüsü ile kaydedilen films listesi içinde geziyoruz ve her birini ekrana yazdırıyoruz.
            {
                Console.WriteLine($"Film Adı: {film.Name}, IMDb Puanı: {film.ImdbScore}");
            }
        }

        // IMDb puanı 4 ile 9 arasında olan filmleri listeleme fonksiyonu
        public void PrintFilmsWithScoreBetween4And9()
        {
            var selectedFilms = films.Where(f => f.ImdbScore >= 4 && f.ImdbScore <= 9).ToList();  // Belirtilen puan arasında olan filmleri listele

            if (selectedFilms.Count == 0)    // Eğer film bulunamazsa mesaj döndürür
            {
                Console.WriteLine("Bu aralıkta film bulunamadı.");
            }
            else
            {
                foreach (var film in selectedFilms)   // uygun olan filmleri ekrana yazdırır
                {
                    Console.WriteLine($"Film Adı: {film.Name}, IMDb Puanı: {film.ImdbScore}");
                }
            }
        }

        // İsmi 'A' harfi ile başlayan filmleri listeleme fonksiyonu
        public void PrintFilmsStartingWithA()
        {
            foreach (var film in films)    // films listesinde teker teker geziyoruz
            {
                if (film.Name.StartsWith("A")|| film.Name.StartsWith("a"))  // A veya a ile başlayan varsa ekrana göstericel
                {
                    Console.WriteLine($"Film Adı: {film.Name}, IMDb Puanı: {film.ImdbScore}");
                }
            }
        }
    }
```
Class ve methodlar

```csharp
static void Main(string[] args)
{
    Imdb imdbList = new Imdb();    // yeni bir imdb listesi adında nesne ürettik
    imdbList.AddFilm();   // AddFilm methodunu çağırarak filmleri tanımladık

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\n--- Bütün Filmler ---");
    Console.ResetColor();

    imdbList.PrintAllFilms();   // Oluşturulan bütün filmleri ekranda göstericek


    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\n--- IMDb Puanı 4 ile 9 Arasında Olan Filmler ---");
    Console.ResetColor();
    imdbList.PrintFilmsWithScoreBetween4And9();  // 4 ile 9 arasında olan filmleri ekranda göstericek

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\n--- 'A' Harfi ile Başlayan Filmler ---");
    Console.ResetColor();
    imdbList.PrintFilmsStartingWithA(); // A ile başlayan filmleri ekranda göstericek

    Console.ReadKey();
}
```
main method ve nesne oluşturma




