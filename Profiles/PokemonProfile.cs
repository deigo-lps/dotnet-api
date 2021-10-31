using AutoMapper;
using dotnet_api.Data.Dtos;
using pokedex_api.Models;

namespace dotnet_api.Profiles
{
    public class PokemonProfile : Profile
    {
        public PokemonProfile()
        {
            CreateMap<CreatePokemonDto, Pokemon>();
            CreateMap<Pokemon,ReadPokemonDto>();
            CreateMap<UpdatePokemonDto, Pokemon>();
        }
    }
}