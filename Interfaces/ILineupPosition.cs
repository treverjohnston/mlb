using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mlb.Interfaces
{
  public interface ILineupPosition
  {
    //From 1-9. -- Batting Order, inc
    int Placement { get; set; }
    //From 1-10 -- Pitcher, Catcher, 1b, etc.. 10 is DH
    int Position { get; set; }
    Guid Id { get; set; }
    int PlayerId { get; set; }
  }
}
