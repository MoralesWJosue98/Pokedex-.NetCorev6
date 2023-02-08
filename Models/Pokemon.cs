using System.ComponentModel.DataAnnotations;

namespace Pokedex.Models
{
    public class Pokemon
    {
        [Required(ErrorMessage = "Colocar Nombre del Pokemon !")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Debe colocar la descripción del pokemon !")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Debe colocar la URL del pokemon !")]
        public String ImgUrl { get; set; }

        [Required(ErrorMessage = "**")]
        public int PrimaryType { get; set; }    
        public int SecondaryType { get; set;}

        [Required(ErrorMessage = "**")]
        public int RegionID { get; set; }
        public int Id { get; set; } 

        // Properties to use in navigation
        public Region pokemonRegion { get; set; }
        public Type pokemonType { get; set; }   

        public static explicit operator Pokemon(Task<Pokemon> v)
        {
            throw new NotImplementedException();
        }
        



    }
}
