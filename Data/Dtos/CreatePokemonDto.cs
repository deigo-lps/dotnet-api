using System.ComponentModel.DataAnnotations;

namespace dotnet_api.Data.Dtos
{
    public class CreatePokemonDto
    {
        public double Height{get;set;}
        public float Weight{get;set;}
        [Required]
        public string PokemonName{get;set;}
        public string Type{get;set;}
    }
}