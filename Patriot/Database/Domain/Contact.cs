using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patriot.Database.Domain
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR(150)")]
        public string FullName { get; set; }
        [Column(TypeName = "VARCHAR(150)")]
        public string Email { get; set; }
        [Column(TypeName = "VARCHAR(50)")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "VARCHAR(1000)")]
        public string Message { get; set; }
        public DateTime Created { get; set; }
    }
}
