namespace Pokedex.Models
{
    public class Type
    {
        public String Name { get; set; }    
        public int Id { get; set; }

        public ICollection<Pokemon> Pokemons { get; set; }


    }
}
