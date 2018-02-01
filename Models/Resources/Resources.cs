using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace alumnus.Models.Resources
{
    public class Resources
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Url]
        public string Url { get; set; }
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