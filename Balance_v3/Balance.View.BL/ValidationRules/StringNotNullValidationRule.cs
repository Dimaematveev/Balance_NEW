using System.Globalization;
using System.Windows.Controls;

namespace Balance.View.ValidationRules
{
    public class StringNotNullValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool canConvert = !string.IsNullOrWhiteSpace(value as string);
            return new ValidationResult(canConvert, "Строка не должна быть пустой");
        }
    }
}
