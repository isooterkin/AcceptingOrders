using AcceptingOrders.Attributes.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        [BindRequired]
        public int Weight { get; set; }



        [Display(Name = "Дата забора груза")]
        [Required(ErrorMessage = "Укажите дату забора груза.")]
        [BindRequired]
        [Date]
        public DateTime Date { get; set; }



        [Address]
        [Display(Name = "Адрес отправителя")]
        [Required(ErrorMessage = "Укажите адрес отправителя.")]
        [BindRequired]
        public string SenderAddress { get; set; }



        [Address]
        [Display(Name = "Адрес получателя")]
        [Required(ErrorMessage = "Укажите адрес получателя.")]
        [BindRequired]
        public string AddresseeAddress { get; set; }
    }
}