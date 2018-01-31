using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alumnus.Models.Contacts
{
    public class Contacts
    {
        public int Id { get;set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType("date")]
        public DateTime BirthDay { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        [Column("graduation_date")]
        [DataType("date")]
        public DateTime GraduationDate { get; set; }
        [Column("current_job")]
        public string CurrentJob { get; set; }
        [Column("current_position")]
        public string CurrentPosition { get; set; }
    }
}