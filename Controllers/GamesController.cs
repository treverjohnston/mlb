using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mlb.Interfaces;
using mlb.Models;
using webhunt.Services;

namespace mlb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GamesService _gamesService;

        // GET api/games
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            if (_gamesService.Games.Count < 1)
            {
                return BadRequest("No Games Found");
            }
            return Ok(_gamesService.Games);
        }
        [HttpGet("today")]
        public async Task<List<Game>> GetTodayGames()
        {
             var res = await _gamesService.GetGamesForToday();
             return res;
        }

    // GET api/games/guid
    [HttpGet("{id}")]
        public ActionResult<IGame> Get(string id)
        {
            var game = _gamesService.FindGameById(id);
            if (game == null)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(game);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<IGame> Post()
        {
      // return Ok(_gamesService.CreateGame(user.Name));
      return null;
        }

        // PUT api/games/gameId
        [HttpPut("{id}")]
        public ActionResult<IGame> Put()
        {
      //try
      //{

      //    var game = _gamesService.FindGameById(id);
      //    if (game == null)
      //    {
      //        return BadRequest("Invalid Id");
      //    }
      //    game.Message = game.ProcessInput(userInput);
      //    return Ok(game);
      //}
      //catch (Exception e)
      //{
      //    return BadRequest(e.Message);
      //}
      return null;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
    {

    }

        public GamesController(GamesService gs)
        {
            _gamesService = gs;
        }

    }
}
