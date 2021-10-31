using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using dotnet_api.Data;
using dotnet_api.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using pokedex_api.Models;

namespace pokedex_api.Controllers
{
  [ApiController]
  [Route("[controller]")]//rota requisições será nome do controlador
  public class PokemonController : ControllerBase
  {

    private PokemonContext _context;
    private IMapper _mapper;

    public PokemonController(PokemonContext context,IMapper mapper)
    {
      _mapper=mapper;
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
      if(pokemon!=null){
        ReadPokemonDto pokemonread;
        pokemonread=_mapper.Map<ReadPokemonDto>(pokemon);
        pokemonread.HoraDaConsulta=DateTime.Now;
        return Ok(pokemonread);
      }
      return NotFound();
    }

    [HttpPost]
    public IActionResult AdicionaPokemon([FromBody] CreatePokemonDto pokemonDto)
    {
      Pokemon pokemon = _mapper.Map<Pokemon>(pokemonDto);
      _context.Pokemons.Add(pokemon);
      _context.SaveChanges();
      return CreatedAtAction(nameof(RetornaPokemonId), new { id = pokemon.Id }, pokemon);
    }

    [HttpPut("{id}")]
    public IActionResult ModificaPokemon(int id,[FromBody] UpdatePokemonDto newPokemon)
    {
      Pokemon pokemon = _context.Pokemons.FirstOrDefault(pokemon => pokemon.Id == id);
      if(pokemon == null)
        return NotFound();
      _mapper.Map(newPokemon,pokemon);
      _context.SaveChanges();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaPokemon(int id)
    {
      Pokemon pokemon = _context.Pokemons.FirstOrDefault(pokemon => pokemon.Id == id);
      if(pokemon==null)
        return NotFound();
      _context.Remove(pokemon);
      _context.SaveChanges();
      return NoContent();
    }
  }
}