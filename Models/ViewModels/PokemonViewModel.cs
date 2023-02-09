namespace Pokedex.Models.ViewModels
{
    public class PokemonViewModel
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String ImgUrl { get; set; }
        public int PrimaryType { get; set; }
        public int SecondaryType { get; set; }
        public int RegionId { get; set; }
        public int Id { get; set; }
    }
}
