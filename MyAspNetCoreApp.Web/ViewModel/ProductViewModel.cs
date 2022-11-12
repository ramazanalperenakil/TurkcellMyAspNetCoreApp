

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyAspNetCoreApp.Web.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        //[Remote(action: "HasProductName",controller: "Products")]
        [Required(ErrorMessage ="Bu Alan Boş Olamaz")]
        [StringLength(500,ErrorMessage ="Maksimum 500 karaktet")]
        [MinLength(3,ErrorMessage ="Min 3 karaktet")]
        public string? Name { get; set; }

        //[RegularExpression(@"^[0-9]+(\.[0-9]{1.2})", ErrorMessage = "Format hataso")]
        [Required(ErrorMessage = "Bu Alan Boş Olamaz")]
        [Range(1, 1000, ErrorMessage = "Fiyat 1 ila 1000 arasında olmalı")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Olamaz")]
        [Range(1,200,ErrorMessage = "Değer 1 ila 200 arasında olmalı")]
        public int? Stock { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Olamaz")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Olamaz")]
        [StringLength(500, ErrorMessage = "Maksimum 500 karaktet")]
        [MinLength(3, ErrorMessage = "Min 3 karaktet")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Olamaz")]
        public DateTime? PublishDate { get; set; }
        

        public bool IsPublish { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Olamaz")]
        public int? Expire { get; set; }

        //[EmailAddress(ErrorMessage ="Eposta İstenilen Formatta olmalı")]
        //public string? Email { get; set; }
    }
}
