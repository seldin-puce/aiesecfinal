﻿using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace Model.Attributes
{
    public class PasswordPolicyAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var PasswordOptions = validationContext.GetService<IOptions<PasswordOptions>>().Value;
            if (value == null || (PasswordOptions.RequireDigit && !value.ToString().Any(char.IsDigit)) ||
                (PasswordOptions.RequireLowercase && !value.ToString().Any(char.IsLower)) ||
                (PasswordOptions.RequireUppercase && !value.ToString().Any(char.IsUpper)) ||
                PasswordOptions.RequireNonAlphanumeric && value.ToString().All(char.IsLetterOrDigit)
                && PasswordOptions.RequiredLength > value.ToString().Length)
                return new ValidationResult(string.Format((IFormatProvider)CultureInfo.CurrentCulture, ErrorMessageString));
            return ValidationResult.Success;
        }
    }
}
