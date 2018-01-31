using System.ComponentModel.DataAnnotations;

namespace alumnus.Models.Resources
{
    public enum TypeEnum
    {
        [Display(Name = "Enlace web")]
        Link = 1,
        [Display(Name = "Documento")]
        Document,
        [Display(Name = "Noticia")]
        News,
        [Display(Name = "Otro")]
        Entry
    }
}