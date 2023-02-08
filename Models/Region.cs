using System.ComponentModel.DataAnnotations;

namespace Pokedex.Models
{
    public class Region
    {
        [Required(ErrorMessage = "Colocar Region del Pokemon !")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Colocar descripción de la región !")]
        public String Description { get; set; }

        [Required(ErrorMessage = "**")]
        public int Id { get; set; } 
        
        public ICollection<Pokemon> Pokemons { get; set; } 

    }
}
