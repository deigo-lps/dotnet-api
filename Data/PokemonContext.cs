using Microsoft.EntityFrameworkCore;
using pokedex_api.Models;

namespace dotnet_api.Data
{
    public class PokemonContext : DbContext
    {
        //construtor que recebe opt
        public PokemonContext(DbContextOptions<PokemonContext> opt) : base(opt)
        {

        }
        public DbSet<Pokemon> Pokemons{get;set;}
    }
}