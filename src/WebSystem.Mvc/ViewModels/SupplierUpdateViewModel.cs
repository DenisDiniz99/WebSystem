using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebSystem.Mvc.ViewModels
{
    public class SupplierUpdateViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do fornecedor.")]
        [StringLength(100, ErrorMessage = "O nome do fornecedor deve conter entre {0} e {2} caracteres.", MinimumLength = 2)]
        [DisplayName("Nome do Fornecedor")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe a razão social do fornecedor.")]
        [StringLength(100, ErrorMessage = "A razão social do fornecedor deve conter entre {0} e {2} caracteres.", MinimumLength = 2)]
        [DisplayName("Razão Social")]
        public string CorporateName { get; set; }

        [Required(ErrorMessage = "Informe uma descrição para o fornecedor.")]
        [StringLength(255, ErrorMessage = "A descrição do fornecedor deve conter entre {0} e {2} caracteres.", MinimumLength = 2)]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Informe o telefone do fornecedor.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "O telefone está inválido.")]
        [DisplayName("Telefone")]
        public string Phone { get; set; }

        [StringLength(50, ErrorMessage = "O contato do fornecedor deve conter entre {0} e {2} caracteres.", MinimumLength = 2)]
        [DisplayName("Contato")]
        public string Contact { get; set; }

        public DocumentViewModel Document { get; set; }

        public EmailViewModel Email { get; set; }
    }
}
