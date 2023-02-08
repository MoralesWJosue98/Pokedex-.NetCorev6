using System.ComponentModel.DataAnnotations;

namespace Pokedex.Models
{
    public class Type
    {
        [Required(ErrorMessage = "Colocar Tipo del Pokemon !")]
        public String Name { get; set; }

        [Required(ErrorMessage = "**")]
        public int Id { get; set; }

        public ICollection<Pokemon> Pokemons { get; set; }


    }
}
