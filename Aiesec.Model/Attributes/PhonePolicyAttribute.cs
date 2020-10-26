using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Model.Attributes
{
    class PhonePolicyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Regex regex = new Regex("[0-9]{9,10}");
            if (!regex.IsMatch(value.ToString())) return new ValidationResult(string.Format(CultureInfo.CurrentCulture, ErrorMessageString));
            return ValidationResult.Success;
        }
    }
}
