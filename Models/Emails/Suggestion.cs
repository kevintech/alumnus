using System.ComponentModel.DataAnnotations;

namespace alumnus.Models.Emails
{
    public class Suggestion
    {
        [Required]
        public string FullName { get; set; }
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}