namespace Pokedex.Models
{
    public class Pokemon
    {
        public String Name { get; set; }    
        public String Description { get; set; }    
        public String ImgUrl { get; set; }  
        public int PrimaryType { get; set; }    
        public int SecondaryType { get; set;}
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
