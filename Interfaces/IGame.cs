using mlb.Models;
using System;

namespace mlb.Interfaces
{
  public interface IGame
  {
    int Id { get; set; }
    int HomeTeamId { get; set; }
    int AwayTeamId { get; set; }
    int WinnerId { get; set; }
    DateTime Date { get; set; }
    Lineup HomeLineup { get; set; }
    Lineup AwayLineup { get; set; }

  }

}
