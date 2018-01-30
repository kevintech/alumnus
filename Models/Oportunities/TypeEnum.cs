using System.ComponentModel.DataAnnotations;

namespace alumnus.Models.Oportunities
{
    public enum TypeEnum
    {
        [Display(Name = "Oferta de Trabajo")]
        Job = 1,
        EPS,
        [Display(Name = "Práctica Supervisada")]
        Internship
    }
}