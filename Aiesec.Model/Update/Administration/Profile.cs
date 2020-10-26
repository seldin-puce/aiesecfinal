using Aiesec.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aiesec.Model.Update.Administration
{
    public class Profile
    {
        [Required(ErrorMessage = "ErrNoFirstName")]
        [MaxLength(50, ErrorMessage = "ErrFirstNameMaxLength")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "ErrNoLastName")]
        [MaxLength(50, ErrorMessage = "ErrLastNameMaxLength")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "ErrNoBirthDate")]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [Required(ErrorMessage = "ErrNoGender")]
        public Gender Gender { get; set; }

        [MaxLength(500, ErrorMessage = "ErrBiographyMaxLengthPolicy")]
        public string Biography { get; set; }

        [Required(ErrorMessage = "ErrNoCity")]
        public int CityId { get; set; }
    }
}
