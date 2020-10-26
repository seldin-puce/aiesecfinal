using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Model.Attributes
{
    public class UsernamePolicy : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Regex regex = new Regex("[a-z]{3,}_[a-z]{3,}");
            if (!regex.IsMatch(value.ToString())) return new ValidationResult(string.Format(CultureInfo.CurrentCulture, ErrorMessage));
            return ValidationResult.Success;
        }
    }
}
