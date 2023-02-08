namespace Pokedex.Models
{
    public class Region
    {

        public String Name { get; set; }    
        public String Description { get; set; }
        public int Id { get; set; } 
        
        public ICollection<Pokemon> Pokemons { get; set; } 

    }
}
