using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication43.ViewModels
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "Įveskite produkto pavadinimą")]
        [DisplayName("Produkto pavadinimas")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Įveskite aprašymą")]
        [DisplayName("Produkto aprasymas")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Pasirinkite sėkciją")]
        [HiddenInput(DisplayValue = false)]
        [DisplayName("Sėkcija")]
        [MaxLength(20)]
        public string Section { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Įveskite kainą")]
        [DisplayName("Kaina")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Įveskite kategoriją")]
        [DisplayName("Produkto kategorija")]
        [MaxLength(20)]
        public string Category { get; set; }

    }
}
