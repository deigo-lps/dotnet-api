using System.ComponentModel.DataAnnotations;

namespace pokedex_api.Models
{
  public class Pokemon
  {
    [Required]
    [Key]
    public int Id { get; set; }

    [Required]
    public string PokemonName { get; set; }

    public double Height { get; set; }

    public float Weight { get; set; }

    public string Type { get; set; }
  }
}