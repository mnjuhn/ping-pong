using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Configuration;
using PingPong.Models;
using System.Web.Http.Cors;

namespace PingPong.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PlayerController : ControllerBase
  {
    private readonly ILogger<PlayerController> _logger;

    public PlayerController(ILogger<PlayerController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    [Microsoft.AspNetCore.Cors.EnableCors("DevEnvironment")]
    public IEnumerable<Player> Get()
    {
      var context = new PingPongContext();
      var players = context.Players.ToList();
      return players;

    }

    [HttpGet("{Id}")]
    [Microsoft.AspNetCore.Cors.EnableCors("DevEnvironment")]
    public Player Get(int Id)
    {
      var context = new PingPongContext();
      var players = context.Players.ToList();
      var player = players.Where(i => i.Id == Id).FirstOrDefault<Player>();
      return player;
    }

    [HttpPut]
    [Microsoft.AspNetCore.Cors.EnableCors("DevEnvironment")]
    public void Put(Player player)
    {
      var context = new PingPongContext();
      var players = context.Players.ToList();
      var entity = players.Find(i => i.Id == player.Id);
      Console.WriteLine(player.Id);
      // if player to update is not found return
      if (entity == null)
      {
        Console.WriteLine("TEST2");

        return;
      }
      Console.WriteLine("TEST3");
      // save updated player
      context.Entry(entity).CurrentValues.SetValues(player);
      context.SaveChanges();

    }

    [HttpPost]
    [Microsoft.AspNetCore.Cors.EnableCors("DevEnvironment")]
    public void Post(Player player)
    {
      try
      {
        Console.WriteLine("test3");
        var context = new PingPongContext();
        Console.WriteLine("test1");
        // save new player
        context.Add(player);
        Console.WriteLine("test2");
        context.SaveChanges();
      }
      catch (Exception e)
      {
        Console.WriteLine(e.ToString());
      }
    }

    [HttpDelete("{Id}")]
    [Microsoft.AspNetCore.Cors.EnableCors("DevEnvironment")]
    public void Delete(int id)
    {
      var context = new PingPongContext();
      var player = new Player() { Id = id };
      context.Players.Attach(player);               
      context.Players.Remove(player);
      context.SaveChanges();

      /*var context = new PingPongContext();
      var player = context.Players.ToList();
      player.Find(i => i.Id == id);

      if (player != null)
      {
        context.Remove(player);
        context.SaveChanges();
      }*/
    }
  }
}

