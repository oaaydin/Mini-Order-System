using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Mini_Order_System;

//CS Oku
var configuration = new ConfigurationBuilder()
  .SetBasePath(Directory.GetCurrentDirectory())
  .AddJsonFile("appsettings.json", optional: false)
  .Build();
string connectionString = configuration.GetConnectionString("DefaultConnection");
var options = new DbContextOptionsBuilder<AppDbContext>()
  .UseSqlServer(connectionString)
  .Options;

AppDbContext context = new AppDbContext(options);

ProductRepository productRepository = new ProductRepository(context);

ProductManager manager = new ProductManager(productRepository);

while(true)
{
  Console.WriteLine("---Ürün Yönetimi---");
  Console.WriteLine("1 - Ürün Ekle");
  Console.WriteLine("2 - Ürünleri Listele");
  Console.WriteLine("3 - Ürün Bul");
  Console.WriteLine("4 - Ürün Güncelle");
  Console.WriteLine("5 - Ürün Sil");
  Console.WriteLine("0 - Çıkış");
  Console.Write("Seçim: ");
  string choice = Console.ReadLine();

  switch(choice)
  {
    case "1":
      Console.Write("Ürün adı: ");
      string name = Console.ReadLine();
      decimal price;
      do
      {
      Console.Write("Fiyat: ");
      string input = Console.ReadLine();
        if(!decimal.TryParse(input, out price))
        {
          Console.WriteLine("Geçersiz fiyat girdiniz.");
          continue;
        }
        break;
      } while(true);
      Console.Write("Stok: ");
      int stock = int.Parse(Console.ReadLine());
      manager.Add(name, price, stock);
      break;
    case "2":
      foreach(var item in manager.GetAll())
      {
        Console.WriteLine($"* Id: {item.Id} -- İsim: {item.Name} -- Fiyat: {item.Price} TL -- Stok: {item.Stock}");
      }
      break;
    case "3":
      Console.Write("Id Girin:");
      int findId = int.Parse(Console.ReadLine());
      Product? product = manager.GetById(findId);
      if(product == null)
      {
        Console.WriteLine("Ürün bulunamadı.");
      }
      else
      {
        Console.WriteLine($"* Id: {product.Id} -- İsim: {product.Name} -- Fiyat: {product.Price} -- Stok: {product.Stock}");
      }
      break;
    case "4":
      foreach(var item in manager.GetAll())
      {
        Console.WriteLine($"* Id: {item.Id} -- İsim: {item.Name} -- Fiyat: {item.Price} TL -- Stok: {item.Stock}");
      }
      Console.Write("Güncellenecek ürünün ID'si:");
      int id = int.Parse(Console.ReadLine());
      Console.Write("Ürün adı: ");
      string n = Console.ReadLine();
      Console.Write("Fiyat: ");
      decimal p = decimal.Parse(Console.ReadLine());
      Console.Write("Stok: ");
      int s = int.Parse(Console.ReadLine());
      manager.Update(id, n, p, s);
      Console.WriteLine("Güncelleme başarılı.");
      break;
    case "5":
      foreach(var item in manager.GetAll())
      {
        Console.WriteLine($"* Id: {item.Id} -- İsim: {item.Name} -- Fiyat: {item.Price} TL -- Stok: {item.Stock}");
      }
      Console.Write("Silinecek ürünün ID'si:");
      int deleteId = int.Parse(Console.ReadLine());
      manager.Delete(deleteId);
      Console.WriteLine("Ürün silindi.");
      break;
    case "0":
      return;
    default:
      Console.WriteLine("Geçersiz seçim..");
      break;
  }
}