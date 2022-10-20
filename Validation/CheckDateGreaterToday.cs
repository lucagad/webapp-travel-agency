using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Validation;

public class CheckDateGreaterToday: ValidationAttribute {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
        DateTime dt = (DateTime)value;
        if (dt >= DateTime.UtcNow) {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "Verifica che la data inserita sia uguale o maggiore ad oggi");
    }

}