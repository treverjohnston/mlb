using mlb.Helpers;
using mlb.Interfaces;
using mlb.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace webhunt.Services
{
  public class GamesService
  {
    //Maybe move this to startup?
    public List<Game> Games = new List<Game>();
    private static readonly HttpClient client = new HttpClient();
    JsonHelpers _jsonHelpers = new JsonHelpers();


    public async Task<List<Game>> GetGamesForToday()
    {
      try
      {
        Games.Clear();
        var today = DateTime.Now;
        //TODO: Use today date below
        var jsonObj = await _jsonHelpers.MakeRequestAndParseToJson(client, $"https://statsapi.mlb.com/api/v1/schedule?sportId=1&date={today.Month}%2F{today.Day}%2F{today.Year}");

        var dates = jsonObj.SelectToken("dates");
        var games = dates.FirstOrDefault().SelectToken("games");
        foreach (var game in games)
        {
          var gameId = (int)game.SelectToken("gamePk");
          var gameDate = (DateTime)game.SelectToken("gameDate");
          var awayTeam = game.SelectToken("teams").SelectToken("away");
          var homeTeam = game.SelectToken("teams").SelectToken("home");
          var awayId = (int)awayTeam.SelectToken("team").SelectToken("id");
          var homeId = (int)homeTeam.SelectToken("team").SelectToken("id");

          var isComplete = true;
          if(homeTeam.SelectToken("isWinner") == null && awayTeam.SelectToken("isWinner") == null)
          {
            isComplete = false;
          }
          //If game either got postponed or hasn't been finished yet, set it to -1
          var winnerId = isComplete ? ((bool)homeTeam.SelectToken("isWinner") ? homeId : awayId) : -1;

          var gameLineups = await GetLineupsForGame(gameId);
          var newGame = new Game(gameId, homeId, awayId, winnerId, gameDate, gameLineups[homeId], gameLineups[awayId]);
          if(newGame != null)
          {
            AddGame(newGame);
          }
        }
        return Games;

      }
      catch (Exception ex)
      {
        throw ex;
      }
     }

    public async Task<Dictionary<int, Lineup>> GetLineupsForGame(int gameId)
    {
      try
      {
        var LineupsDictionary = new Dictionary<int, ILineup>();
        var jsonObj = await _jsonHelpers.MakeRequestAndParseToJson(client, $"http://statsapi.mlb.com:80/api/v1/game/{gameId}/boxscore");

        var teamsObj = jsonObj.SelectToken("teams");
        var homeTeam = teamsObj.SelectToken("home");
        var awayTeam = teamsObj.SelectToken("away");
        var homeOrder = homeTeam.SelectToken("battingOrder");
        var awayOrder = awayTeam.SelectToken("battingOrder");
        var homeLineupPositionList = CreateLineupPositions(homeTeam, homeOrder);
        var awayLineupPositionList = CreateLineupPositions(awayTeam, awayOrder);

        //If lineup doesn't exist
        var homeLineup = new Lineup(0,0,0, homeLineupPositionList, new List<int>(gameId), 1);
        var awayLineup = new Lineup(0, 0, 0, awayLineupPositionList, new List<int>(gameId), 1);

        //TODO: else -- update lineup


        var returnObj = new Dictionary<int, Lineup>();
        returnObj.Add((int)homeTeam.SelectToken("team").SelectToken("id"), homeLineup);
        returnObj.Add((int)awayTeam.SelectToken("team").SelectToken("id"), awayLineup);

        return returnObj;

      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
      
    }

    private List<LineupPosition> CreateLineupPositions(JToken team, JToken order)
    {
      try
      {
        //Lineup has not been posted yet for the day
        if (!order.Any())
        {
          return new List<LineupPosition>();
        }
        //TODO: Add in a way to check if this lineupPosition already exists
        var lineupPositionList = new List<LineupPosition>();
        for (int i = 0; i < 9; i++)
        {
          var playerId = (int)order[i];
          var placement = i + 1;
          var id = Guid.NewGuid();
          var position = (int)team.SelectToken("players").SelectToken($"ID{playerId}").SelectToken("position").SelectToken("code");
          var lineupPos = new LineupPosition(placement, position, id, playerId);
          lineupPositionList.Add(lineupPos);
        }
        return lineupPositionList;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }      
    }

    public IGame FindGameById(string id)
    {
      //Need to grab from DB
      //Games.TryGetValue(id, out IGame game);
      return null;
    }

    public Game AddGame(Game game)
    {
      //TODO: Need to add to db
      Games.Add(game);
      //System.Console.WriteLine("Created Gaem" + game);
      return game;
    }

  }

}
