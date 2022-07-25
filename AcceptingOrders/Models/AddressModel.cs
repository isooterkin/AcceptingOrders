using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618

namespace AcceptingOrders.Models
{
    public class AddressModel
    {
        [Display(Name = "Город")]
        [Required(ErrorMessage = "Укажите город.")]
        public string City { get; set; }



        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Укажите адрес.")]
        public string Address { get; set; }
    }
}