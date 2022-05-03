using System.ComponentModel.DataAnnotations;

namespace WebSystem.Mvc.ViewModels
{
    public class SupplierViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do fornecedor.")]
        [StringLength(2, ErrorMessage = "O nome do fornecedor deve conter entre {0} e {2} caracteres.", MinimumLength = 100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe a razão social do fornecedor.")]
        [StringLength(2, ErrorMessage = "A razão social do fornecedor deve conter entre {0} e {2} caracteres.", MinimumLength = 100)]
        public string CorporateName { get; set; }

        [Required(ErrorMessage = "Informe uma descrição para o fornecedor.")]
        [StringLength(2, ErrorMessage = "A descrição do fornecedor deve conter entre {0} e {2} caracteres.", MinimumLength = 255)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Informe o telefone do fornecedor.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "O telefone está inválido.")]
        public string Phone { get; set; }

        [StringLength(2, ErrorMessage = "O contato do fornecedor deve conter entre {0} e {2} caracteres.", MinimumLength = 50)]
        public string Contact { get; set; }

        public DocumentViewModel Document { get; set; }

        public EmailViewModel Email { get; set; }

        public AddressViewModel Address { get; set; }
    }
}
