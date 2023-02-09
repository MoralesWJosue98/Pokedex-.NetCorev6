using System.ComponentModel.DataAnnotations;

namespace Pokedex.Models.ViewModels
{
    public class SaveTypeViewModel
    {
        [Required(ErrorMessage = "Debe Colocar el Tipo !")]
        public String Name { get; set; }

        [Required(ErrorMessage = "**")]
        public int Id { get; set; }
    }
}
