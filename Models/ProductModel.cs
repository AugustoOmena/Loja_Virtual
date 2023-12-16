using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models
{
    public class Product    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é requerido")]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string? UrlImage { get; set; }
        [NotMapped]
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
