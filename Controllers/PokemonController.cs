using System.Collections.Generic;
using System.Linq;
using dotnet_api.Data;
using Microsoft.AspNetCore.Mvc;
using pokedex_api.Models;

namespace pokedex_api.Controllers
{
  [ApiController]
  [Route("[controller]")]//rota requisições será nome do controlador
  public class PokemonController : ControllerBase
  {

    private PokemonContext _context;

    public PokemonController(PokemonContext context)
    {
      _context=context;
    }

    [HttpGet]
    public IActionResult RetornaPokemon()
    {
      return Ok(_context.Pokemons);
    }

    [HttpGet("{id}")]
    public IActionResult RetornaPokemonId(int id)
    {
      Pokemon pokemon = _context.Pokemons.FirstOrDefault(pokemon => pokemon.Id == id);
      if(pokemon!=null)
        return Ok(pokemon);
      return NotFound();
    }

    [HttpPost]
    public IActionResult AdicionaPokemon([FromBody] Pokemon pokemon)
    {
      _context.Pokemons.Add(pokemon);
      _context.SaveChanges();
      return CreatedAtAction(nameof(RetornaPokemonId), new { id = pokemon.Id }, pokemon);
    }

    // [HttpPut("{id}")]
    // public IActionResult ModificaPokemon(int id,[FromBody] Pokemon pokemon)
    // {
    //   if(pokedex.ContainsKey(id)){
    //     pokemon.Id=id;
    //     pokedex[id]=pokemon;
    //     return CreatedAtAction(nameof(RetornaPokemonId),new{id=pokemon.Id},pokemon);
    //   }
    //   else
    //     return NotFound();
    // }

    // [HttpDelete("{id}")]
    // public IActionResult DeletaPokemon(int id)
    // {
    //   if(pokedex.ContainsKey(id)){
    //     pokedex.Remove(id);
    //     return Ok("id "+id+" deleted.");
    //   }
    //   return NotFound();
    // }
  }
}