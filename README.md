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



## Doğru Çalıştığında: 
![resim](https://github.com/user-attachments/assets/0b296abb-a49d-4161-b97b-f5501a1815cb)


## Kod 
```csharp

public class Car
{
    public DateTime ProductionDate {  get; set; }
    public string SerialKey { get; set; }
    public string Brand {  get; set; }  
    public string Model { get; set; }
    public string Color { get; set; }
    public int NumberOfDoors { get; set; }

}
```
Class.

```csharp
static void Main(string[] args)
{
    bool isContinue = true;  // Sonsuz Döngü kontrol için değişken
    List<Car> cars = new List<Car>();  // Oluşturulan araba nesnesini ekleyeceğimiz Liste

    //Sonsuz Döngü başlatıldı
    while (isContinue)
    {
        Console.ForegroundColor = ConsoleColor.Red; // Sorulan sorunun rengi Kırmızı ayarlandı
        Console.Write("Araba Üretmek İstiyor Musunuz ?(E- Evet / H- Hayır): ");
        Console.ResetColor();
        if (char.TryParse(Console.ReadLine().ToUpper(), out char choose)) // E veya H cevabı alınırsa İf Bloğuna giriyor. Büyük harf yapıyor otomatik
        {
            if (choose == 'E') // Eğer seçim e ise ;
            {

                Car car = new Car(); // Araba Class'ından araba nesnesini oluşturdu
                Console.Write("Arabanın Seri Numarası: ");  // seri numarası kullanıcıya soruldu
                car.SerialKey = Console.ReadLine(); // kullanıcının girdiği değer Araba nesnesinin SerialKey prop'una atandı

                Console.Write("Arabanın Markası: ");
                car.Brand = Console.ReadLine();  // marka atandı

                Console.Write("Arabanın Modeli: ");
                car.Model = Console.ReadLine(); // model atandı

                Console.Write("Arabanın Rengi: ");
                car.Color = Console.ReadLine(); // Renk atandı

            EnterNumberOfDoors:    // Goto için anahtar kelime tanımlandı. KapıNumarasıGir:
                Console.Write("Kapı Sayısı: ");
                if (!int.TryParse(Console.ReadLine(), out int doors) || doors < 2 || doors > 5) // Eğer Girilen değer 2'den küçük VEYA 5'den büyük VEYA Sayı değilse
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Geçersiz Giriş! Lütfen 2 ile 5 Arasında Bir Sayı Girin"); // Hata ver
                    Console.ResetColor();
                    goto EnterNumberOfDoors; // goto ile tekrardan soruyu soracak
                }
                car.NumberOfDoors = doors; // geçerli girişş yapılınca girilen değer properties'e atandı.

                car.ProductionDate = DateTime.Now; // Tarih alındı

                cars.Add(car);  // Oluşturulan nesne  cars listesine eklendi
            }
            else if (choose == 'H')  // eğer girilen değer H ise;
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Programdan Çıkılıyor\r\n");  // Mesaj göster
                Console.ResetColor();


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\r\n----- ÜRETİLEN ARABA/ARABALAR -----");
                Console.ResetColor();

                foreach (var car in cars)
                {
                    Console.WriteLine($"" +
                    $"Seri Numarası: {car.SerialKey}, " +
                    $"Marka: {car.Brand}, " +
                    $"Model: {car.Model}, " +
                    $"Renk: {car.Color}, " +
                    $"Kapı Sayısı: {car.NumberOfDoors}, " +
                    $"Üretim Tarihi: {car.ProductionDate}");
                }
                Environment.Exit(0);
            }
        }
        else
        {
            Console.WriteLine("Hatalı Seçim yaptınız tekrar deneyin");
        }
    }

    Console.Read();
}
```





