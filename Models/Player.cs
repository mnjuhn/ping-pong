using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PingPong.Models
{
  public class Player
  {
    public enum Level
    {
      Beginner,
      Intermediate,
      Advanced,
      Expert
    }
    public int Id { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string FirstName { get; set; }
    public short? Age { get; set; }
    [Required]
    public int SkillLevel { get; set; }
    [Required]
    public string email { get; set; }

  }
}
