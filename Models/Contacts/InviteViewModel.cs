using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace alumnus.Models.Contacts
{
    public class InviteViewModel
    {
        [Required]
        public IList<string> Emails { get; set; }
        public List<SelectListItem> Contacts { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        public bool Sent { get; set; }
    }
}