using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace alumnus.Models.Oportunities
{
    public class Oportunities
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Column("end_date")]
        public DateTime EndDate { get; set; }
        public string Type { get; set; }
    }
}