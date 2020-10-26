using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aiesec.Database.Models;

namespace Aiesec.Model.Request.Administration
{
    public class Profile
    {

        public string EncryptedId { get; set; }

        [Required(ErrorMessage = "ErrNoFirstName")]
        [MaxLength(50, ErrorMessage = "ErrFirstNameMaxLength")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "ErrNoLastName")]
        [MaxLength(50, ErrorMessage = "ErrLastNameMaxLength")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "ErrNoBirthDate")]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required(ErrorMessage = "ErrNoGender")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "ErrNoCity")]
        public int CityId { get; set; }
    }
}
