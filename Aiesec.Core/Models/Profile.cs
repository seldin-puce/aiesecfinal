using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aiesec.Database.Models
{
    public class Profile : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public string Biography { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public List<ProfileTeam> ProfileTeam { get; set; }
        public int ProfileTeamId { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}