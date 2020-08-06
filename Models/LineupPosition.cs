using mlb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mlb.Models
{
  public class LineupPosition : ILineupPosition
  {
    public int Placement { get; set; }
    public int Position { get; set; }
    public Guid Id { get; set; }
    public int PlayerId { get; set; }

    public LineupPosition(int placement, int position, Guid id, int playerId)
    {
      Placement = placement;
      Position = position;
      Id = id;
      PlayerId = playerId;
    }
  }
}
