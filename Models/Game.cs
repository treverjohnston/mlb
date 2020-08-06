using System;
using System.Collections.Generic;
using System.Linq;
using mlb.Interfaces;

namespace mlb.Models
{
  public class Game : IGame
  {
    public int Id { get; set; }
    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }
    public int WinnerId { get; set; }
    public DateTime Date { get; set; }
    public Lineup HomeLineup { get; set; }
    public Lineup AwayLineup { get; set; }


    public Game(int id, int homeTeamId, int awayTeamId, int winnerId, DateTime date, Lineup homeLineup, Lineup awayLineup)
    {
      Id = id;
      HomeTeamId = homeTeamId;
      AwayTeamId = awayTeamId;
      WinnerId = winnerId;
      Date = date;
      HomeLineup = homeLineup;
      AwayLineup = awayLineup;

    }
  }
}
