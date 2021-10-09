using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pokedex_api.Models;

namespace pokedex_api.Controllers
{
  [ApiController]
  [Route("[controller]")]//rota requisições será nome do controlador
  public class PokemonController : ControllerBase
  {
    public static Dictionary<int, Pokemon> pokedex = new Dictionary<int, Pokemon>();
    public static int id = 1;

    [HttpGet]
    public IActionResult RetornaPokemon()
    {
      return Ok(pokedex);
    }

    [HttpGet("{id}")]
    public IActionResult RetornaPokemonId(int id)
    {
      Pokemon pokemon;
      try
      {
        pokemon = pokedex[id];
      }
      catch (KeyNotFoundException)
      {
        pokemon = null;
      }
      if (pokemon == null) return NotFound();
      return Ok(pokemon);
    }

    [HttpPost]
    public IActionResult AdicionaPokemon([FromBody] Pokemon pokemon)
    {
      pokemon.Id = id;
      pokedex.Add(id, pokemon);
      id++;
      return CreatedAtAction(nameof(RetornaPokemonId), new { id = pokemon.Id }, pokemon);
    }

    [HttpPut("{id}")]
    public IActionResult ModificaPokemon(int id,[FromBody] Pokemon pokemon)
    {
      if(pokedex.ContainsKey(id)){
        pokemon.Id=id;
        pokedex[id]=pokemon;
        return CreatedAtAction(nameof(RetornaPokemonId),new{id=pokemon.Id},pokemon);
      }
      else
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaPokemon(int id)
    {
      if(pokedex.ContainsKey(id)){
        pokedex.Remove(id);
        return Ok("id "+id+" deleted.");
      }
      return NotFound();
    }
  }
}