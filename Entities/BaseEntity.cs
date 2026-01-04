using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
  public class BaseEntity
  {
    public int Id { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsDeleted { get; set; } //Aktif - Silinmiş bilgisi
  }
}
