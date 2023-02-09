using System.ComponentModel.DataAnnotations;

namespace Pokedex.Models.ViewModels
{
    public class SaveRegionViewModel
    {
        [Required(ErrorMessage = "Debe Colocar Nombre de la Región !")]
        public String Name { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe Colocar una Descripción !")]
        public String Description { get; set; }
    }
}
