using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Mini_Order_System
{
  public class ProductManager
  {
    private readonly ProductRepository _repo;
    public ProductManager(ProductRepository repo)
    {
      _repo = repo;
    }

    public void Add(string name, decimal price, int stock )
    {
      if(string.IsNullOrWhiteSpace(name))
      {
        throw new Exception("Ürün adı boş geçilemez.");
      }
      if(price <= 0)
      {
        throw new Exception("Fiyat 0 veya negatif olamaz.");
      }
      if(stock < 0)
      {
        throw new Exception("Ürün stoğu negatif olamaz.");
      }
      Product product = new()
      {
        Name = name,
        Price = price,
        Stock = stock
      };
      _repo.Add(product);
    }

    public List<Product> GetAll()
    {
      return _repo.GetAll();
    }

    public Product? GetById(int id)
    {
      if(id <= 0)
      {
        throw new Exception("Lütfen geçerli bir ID değeri giriniz.");
      }
      return _repo.GetById(id);
    }
    public void Update(int id, string name, decimal price, int stock)
    {
      if(id <= 0)
      {
        throw new Exception("Lütfen geçerli bir ID değeri giriniz.");
      }

      if(string.IsNullOrWhiteSpace(name))
      {
        throw new Exception("Ürün ismi boş girilemez.");
      }

      if(price <= 0)
      {
        throw new Exception("Ürün fiyatı 0 veya negatif olamaz.");
      }

      if(stock < 0)
      {
        throw new Exception("Ürün stoğu negatif olamaz.");
      }

      _repo.Update(id, name, price, stock);
    }

    public void Delete(int id)
    {
      if(id <= 0)
      {
        throw new Exception("ID değeri 0 veya negatif olamaz.");
      }
      bool result = _repo.Delete(id);
      if(!result)
      {
        throw new Exception("Ürün bulunamadı.");
      }
    }
  }
}
