using System.ComponentModel.DataAnnotations;

namespace WebSystem.Mvc.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto.")]
        [StringLength(100, ErrorMessage = "O nome do produto deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe a descrição do produto.")]
        [StringLength(255, ErrorMessage = "A descrição do produto deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto.")]
        public decimal Price { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "Informe uma categoria.")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Informe um fornecedor.")]
        public Guid SupplierId { get; set; }
    }
}
