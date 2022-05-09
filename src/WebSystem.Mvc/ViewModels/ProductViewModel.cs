using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebSystem.Mvc.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto.")]
        [StringLength(100, ErrorMessage = "O nome do produto deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        [DisplayName("Produto")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe a descrição do produto.")]
        [StringLength(255, ErrorMessage = "A descrição do produto deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto.")]
        [DisplayName("Preço")]
        public decimal Price { get; set; }

        [DisplayName("Imagem")]
        public IFormFile ImageUpload { get; set; }
        public string Image { get; set; }

        [DisplayName("Situação")]
        public bool Active { get; set; }
        
        [DisplayName("Data de cadastro")]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Informe uma categoria.")]
        [DisplayName("Categoria")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Informe um fornecedor.")]
        [DisplayName("Fornecedor")]
        public Guid SupplierId { get; set; }

        public IEnumerable<SupplierViewModel> Suppliers { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
