using System;

using System.ComponentModel.DataAnnotations;
namespace BoutiqueShopTest.Models
{
    public class ShopEntity
    {
        
        public int ShopID { get; set; }

        [Required(ErrorMessage = "Dress name is Requried")]
        public string  DressName { get; set; }

        [Required(ErrorMessage = "Price Must be entered")]
        public double  Price { get; set; }

        [Required(ErrorMessage = "Colors Must be Give")]
        public string Color { get; set; }
    }
}