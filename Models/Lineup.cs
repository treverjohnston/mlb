using mlb.Interfaces;
using System.Collections.Generic;

namespace mlb.Models
{
  public class Lineup : ILineup
  {
    public int WinPct { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public List<LineupPosition> LineupPositions { get; set; }
    public List<int> GameIdList { get; set; }
    public int TotalGames { get; set; }

    public Lineup(int winPct, int wins, int losses, List<LineupPosition> lineupPositions, List<int> games, int totalGames)
    {
      WinPct = winPct;
      Wins = wins;
      Losses = losses;
      LineupPositions = lineupPositions;
      GameIdList = games;
      TotalGames = totalGames;
    }
  }
}
