using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace alumnus.Models.Oportunities
{
    public class Oportunities
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Column("end_date")]
        [DataType("date")]
        public DateTime EndDate { get; set; }
        private string _typeString;
        [Column("type")]
        [JsonIgnore]
        public string TypeString {
            get => _typeString; 
            set
            {
                TypeEnum type;
                if(Enum.TryParse(value, out type))
                {
                    _typeEnum = type;
                }
                _typeString = value;
            }
        }
        private TypeEnum _typeEnum;
        [NotMapped]
        public TypeEnum Type  { 
            get => _typeEnum;
            set
            {
                _typeEnum = value;
                _typeString = value.ToString().ToLowerInvariant();
            }
        }
    }
}