using AcceptingOrders.Tools;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8603

namespace AcceptingOrders.Attributes.Validation
{
    public class AddressAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            string? addressForVerification = (string?)value;

            if (addressForVerification == null || addressForVerification == string.Empty)
                return new ValidationResult("Неверно введен адресс!");

            AddressValidation addressValidation = new(addressForVerification);

            if (addressValidation.IsCorrect)
            {
                try
                {
                    validationContext.ObjectType
                        .GetProperty(validationContext.MemberName!)?
                        .SetValue(validationContext.ObjectInstance, addressValidation.CorrectAddress, null);
                }
                catch (Exception)
                {
                    return new ValidationResult("Не удалось изменить адрес.");
                }
            }
            else return new ValidationResult("Не удалось определить адрес.");

            return ValidationResult.Success;
        }
    }
}