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
![BXy5S-K-movie-9pvmdtvz4cb0xl37](https://github.com/user-attachments/assets/2d2f8170-1bc3-42a3-a725-87c57fbf6885)
![YxJF9NG-imdblist](https://github.com/user-attachments/assets/28dbbe0e-603c-4721-970a-734626ae79ed)

Aşağıda belirtilen adımları gerçekleştirerek bir Imdb - Film Listesi oluşturuyoruz
- Sinema Filmlerini listeleyeceğimiz bir liste oluşturalım
- Film için propertyler -> Imdb Puanı (Double) - İsmi
- Kullanıcıdan sınırsız sayıda film adı ve imdb puanı isteyip bu bilgilerle nesneler oluşturulup liste doldurulacak.
- Kullanıcıya her film eklemesinden sonra yeni bir film eklemek isteyip istemediği sorulsun. Kullanıcı evet cevabını verirse döngüde başa dönülerek yeni bir film oluşturulup ilgili listeye aktarılsın. Hayır cevabı verilirse program aşağıdaki çıktıları ayrı ayrı sunarak sonlandırılsın.

Uygulamanın sonunda

 1- Bütün filmler listelensin.
 
 2- Imdb puanı 4 ile 9 arasında olan bütün filmler listelensin.
 
 3- İsmi 'A' ile başlayan filmler ve imdb puanları listelensin.



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




