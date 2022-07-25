using Dadata;
using Dadata.Model;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8603

namespace AcceptingOrders.Attributes.Validation
{
    public class AddressAttribute : ValidationAttribute
    {
        private static CleanClient _cleanClient = new("491bad81fdc4febee92a3339f0f8c4917405b0ed", "c2af29002683f8c344a7887c5b60ca0696d3b84b");



        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            string? addressString = (string?)value;

            if (addressString == null)
                return new ValidationResult("Необходимо вести адрес.");

            Address address = _cleanClient.Clean<Address>(addressString);

            if (address.city == null)
                return new ValidationResult("Не удалось определить город.");

            if (address.street == null)
                return new ValidationResult("Не удалось распознать улицу.");

            if (address.house == null)
                return new ValidationResult("Не удалось определить дом.");

            return ValidationResult.Success;
        }
    }
}