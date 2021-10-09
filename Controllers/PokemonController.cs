using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pokedex_api.Models;

namespace pokedex_api.Controllers
{
  [ApiController]
  [Route("[controller]")]//rota das requisições serão feitas no nome do controlador
  public class PokemonController : ControllerBase
  {
    public static List<Pokemon> pokedex = new List<Pokemon>();
    public static int id = 1;

    [HttpGet]
    public IActionResult RetornaPokemon()
    {
      return Ok(pokedex);
    }

    [HttpGet("{id}")]
    public IActionResult RetornaPokemonId(int id)
    {
      Pokemon pokemon = pokedex.FirstOrDefault(pokemon => pokemon.Id == id);
      if (pokemon == null) return NotFound();
      return Ok(pokemon);
    }

    [HttpPost]
    public IActionResult AdicionaPokemon([FromBody] Pokemon pokemon)
    {
      pokemon.Id = id++;
      pokedex.Add(pokemon);
      return CreatedAtAction(nameof(RetornaPokemonId), new{id=pokemon.Id},pokemon);
    }
  }
}