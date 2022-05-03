using System.ComponentModel.DataAnnotations;

namespace WebSystem.Mvc.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria.")]
        [StringLength(100, ErrorMessage = "O nome da categoria deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Name { get; set; }
    }
}
