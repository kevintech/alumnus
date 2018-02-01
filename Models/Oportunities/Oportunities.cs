using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace alumnus.Models.Oportunities
{
    public class Oportunities
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [DataType("date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column("end_date")]
        public DateTime EndDate { get; set; }
        [Column("type")]
        public string TypeString { get; set; }
        private TypeEnum _typeEnum;
        [NotMapped]
        public TypeEnum Type  { 
            get
            {
                TypeEnum type;
                if(Enum.TryParse(TypeString, true, out type))
                {
                    return type;
                }
                
                return _typeEnum;
            }
            set
            {
                _typeEnum = value;
                TypeString = value.ToString().ToLowerInvariant();
            }
        }
    }
}