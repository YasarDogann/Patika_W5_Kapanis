namespace patika_w5_Kapanis
{
    internal class Program
    {
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
    }
}
