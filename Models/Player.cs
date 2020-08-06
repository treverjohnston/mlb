using mlb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mlb.Models
{
  public class Player : IPlayer
  {
    public string Name { get; set; }
    public int Id { get; set; }
    public Player(string name, int id)
    {
      Name = name;
      Id = id;
    }
  }
}
