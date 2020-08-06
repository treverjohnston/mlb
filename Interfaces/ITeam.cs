using System.Collections.Generic;

namespace mlb.Interfaces
{
  public interface ITeam
  {
    int Id { get; set; }
    int Wins { get; set; }
    int Losses { get; set; }
    List<int> LineupIdList { get; set; }
    List<int> PlayerIdList { get; set; }
    List<int> GameIdList { get; set; }
  }
}
