using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace alumnus.Models.Contacts
{
    public class Contacts
    {
        public int Id { get;set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Column("graduation_date")]
        public DateTime GraduationDate { get; set; }
        [Column("current_job")]
        public string CurrentJob { get; set; }
        [Column("current_position")]
        public string CurrentPosition { get; set; }
    }
}