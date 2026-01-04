using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
  public class ProductRepository
  {
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context)
    {
      _context = context;
    }
    public void Add( Product p )
    {
      _context.Products.Add(p);
      _context.SaveChanges();
    }
    public List<Product> GetAll()
    {
      return _context.Products
        .Where(u => !u.IsDeleted)
        .ToList();
    }
    public Product? GetById(int id)
    {
      return _context.Products
        .Where(u => u.Id == id && !u.IsDeleted)
        .FirstOrDefault();
    }
    public bool Delete(int id)
    {
      Product? product = _context.Products
        .FirstOrDefault(u => u.Id == id && !u.IsDeleted);
      if(product != null)
      {
      product.IsDeleted = true;
      _context.SaveChanges();
        return true;
      }
      return false;

    }
    public void Update(int id, string name, decimal price, int stock)
    {
      Product? product = _context.Products
        .FirstOrDefault(u => u.Id == id && !u.IsDeleted);
      if(product != null )
      {
        product.Name = name;
        product.Price = price;
        product.Stock = stock;
        _context.SaveChanges();
      }
    }
  }
}
