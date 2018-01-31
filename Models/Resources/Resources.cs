using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace alumnus.Models.Resources
{
    public class Resources
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        [Column("type")]
        [JsonIgnore]
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