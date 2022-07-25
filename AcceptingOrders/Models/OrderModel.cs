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



        //[Display(Name = "Город отправителя")]
        //[Required(ErrorMessage = "Укажите город отправителя.")]
        //public string SenderCity { get; set; }



        //[Address]
        [Display(Name = "Адрес отправителя")]
        [Required(ErrorMessage = "Укажите адрес отправителя.")]
        public string SenderAddress { get; set; }



        //[Display(Name = "Город получателя")]
        //[Required(ErrorMessage = "Укажите город получателя.")]
        //public string AddresseeCity { get; set; }



        //[Address]
        [Display(Name = "Адрес получателя")]
        [Required(ErrorMessage = "Укажите адрес получателя.")]
        public string AddresseeAddress { get; set; }



        //[NotMapped]
        //public string AddressSender => $"г. {SenderCity}, {SenderAddress}";



        //[NotMapped]
        //public string AddressAddressee => $"г. {AddresseeCity}, {AddresseeAddress}";
    }
}