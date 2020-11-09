using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication43.Entities
{
    public class Product
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Produkto pavadinimas")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please specify a Section")]
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Sekcija")]
        public string Section { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        [DisplayName("Kaina")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please specify a category")]
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Produkto kategorija")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Produkto aprasymas")]
        public string Description { get; set; }

        [DisplayName("Produkto nuotrauka")]
        [Required(ErrorMessage = "Please choose product image")]
        public string ProductPicture { get; set; }
        [Display(Name = "Paveiksliuko Url")]
        public string ProductPictureUrl { get; set; }
    }
}
