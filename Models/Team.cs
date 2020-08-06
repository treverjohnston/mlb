using mlb.Interfaces;
using System.Collections.Generic;

namespace mlb.Models
{
  public class Team : ITeam
  {
    public int Id { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public List<int> LineupIdList { get; set; }
    public List<int> PlayerIdList { get; set; }
    public List<int> GameIdList { get; set; }
    
    public Team(int id, int wins, int losses, List<int> lineups, List<int> players, List<int> games)
    {
      Id = id;
      Wins = wins;
      Losses = losses;
      LineupIdList = lineups;
      PlayerIdList = players;
      GameIdList = games;
    }
  }
}
