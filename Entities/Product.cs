using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
  public class Product : BaseEntity
  {
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
  }
}
