using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mlb.Interfaces
{
  public interface IPlayer
  {
    string Name { get; set; }
    int Id { get; set; }
  }
}
