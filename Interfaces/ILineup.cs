using mlb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mlb.Interfaces
{
  public interface ILineup
  {
    int WinPct { get; set; }
    int Wins { get; set; }
    int Losses { get; set; }
    List<LineupPosition> LineupPositions { get; set; }
    List<int> GameIdList { get; set; }
    int TotalGames { get; set; }
  }
}
