using System.ComponentModel.DataAnnotations;

namespace WebApplication43.ViewModels
{
    public class ProductViewModelApi : ProductViewModel
    {
        [Required(ErrorMessage = "Pasirinkite nuotrauką")]
        [Display(Name = "Product picture")]
        public string ProductImage { get; set; }
    }
}
