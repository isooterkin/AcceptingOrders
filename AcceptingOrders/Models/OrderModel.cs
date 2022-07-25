using AcceptingOrders.Attributes.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618

namespace AcceptingOrders.Models
{
    [Display(Name = "Заказ")]   
    public class OrderModel
    {
        [Key]
        [Display(Name = "Номер")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        [Display(Name = "Вес груза (грамм)")]
        [Required(ErrorMessage = "Укажите вес груза (в граммах).")]
        [Range(1, 100000, ErrorMessage = "Недопустимый вес груза")]
        public int Weight { get; set; }



        [Display(Name = "Дата забора груза")]
        [Required(ErrorMessage = "Укажите дату забора груза.")]
        [Date]
        public DateTime Date { get; set; }



        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Укажите адрес.")]
        public AddressModel Address { get; set; }
    }
}