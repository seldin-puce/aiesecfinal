﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Aiesec.Database.Models
{
    public class ApplicationUserToken : BaseEntity<int>
    {
        [ForeignKey(nameof(User))] 
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public TokenType TokenType { get; set; }
        public string Value { get; set; }
    }

    public enum TokenType
    {
        AccountActivation,
        PasswordReset,
        VerifyPhoneNumber
    }
}