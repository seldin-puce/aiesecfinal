using Model.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Aiesec.Model.Update.Administration
{
    public class User
    {
        [Required(ErrorMessage = "ErrNoUsername")]
        [RegularExpression("[a-z]{3,}_[a-z]{3,}", ErrorMessage= "ErrUsernamePolicy")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "ErrNoPhoneNumber")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "ErrNoEmail")]
        [RegularExpression("^\\d{9,10}$", ErrorMessage = "ErrTypePhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        public bool TwoFactorEnabled { get; set; }
    }
}
 