using Model.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Aiesec.Model.Request.Administration
{
    public class User
    {
        public string EncryptedId { get; set; }

        [Required(ErrorMessage = "ErrNoUsername")]
        [RegularExpression("[a-z]{3,}_[a-z]{3,}", ErrorMessage = "ErrUsernamePolicy")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "ErrNoEmail")]
        [EmailAddress(ErrorMessage = "EmailWrongFormat")]
        public string Email { get; set; }

        [Required(ErrorMessage = "ErrNoPhoneNumber")]
        [RegularExpression("^\\d{9,10}$", ErrorMessage = "ErrPhoneNumberPolicy")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "ErrNoPassword")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,50}$", ErrorMessage = "ErrPasswordPolicy")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "ErrNoPasswordConfirm")]
        [Compare(nameof(Password), ErrorMessage = "ErrNotSamePasswordConfirm")]
        public string ConfirmPassword { get; set; }

    }
}
