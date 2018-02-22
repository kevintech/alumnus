using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alumnus.Models.Contacts
{
    public class Contacts
    {
        public int Id { get;set; }
        [Required]
        public string Collegiate { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Dpi { get; set; }
        [Required]
        [DataType("date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDay { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [DataType("date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column("graduation_date")]
        public DateTime GraduationDate { get; set; }
        [Column("current_job")]
        public string CurrentJob { get; set; }
        [Column("current_position")]
        public string CurrentPosition { get; set; }
        [Column("current_degree")]
        public string CurrentDegree { get; set; }
        [Column("other_courses")]
        public string OtherCourses { get; set; }
    }
}