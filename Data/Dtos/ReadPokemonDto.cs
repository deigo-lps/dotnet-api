using System;

namespace dotnet_api.Data.Dtos
{
  public class ReadPokemonDto
  {
    public int Id { get; set; }
    public string PokemonName { get; set; }
    public double Height { get; set; }
    public float Weight { get; set; }
    public string Type { get; set; }
    public DateTime HoraDaConsulta {get;set;}
  }
}