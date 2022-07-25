using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8603

namespace AcceptingOrders.Attributes.Validation
{
    public class DateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            DateTime? dateTime = (DateTime?)value;
            
            if (dateTime.HasValue && DateTime.Now.AddDays(1).CompareTo(dateTime) > 0 && DateTime.Now.AddYears(1).CompareTo(value) < 0)
                return ValidationResult.Success;

            return new ValidationResult("Date must be within the last six years!");
        }
    }
}