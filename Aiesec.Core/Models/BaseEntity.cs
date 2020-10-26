using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aiesec.Database.Models
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        [NotMapped]
        public string EncryptedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Active { get; set; }
    }
}