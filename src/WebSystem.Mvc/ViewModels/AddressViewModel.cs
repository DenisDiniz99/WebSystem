using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebSystem.Mvc.ViewModels
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = "Informe o nome da rua.")]
        [StringLength(100, ErrorMessage = "O nome da rua deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        [DisplayName("Rua")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Informe o número do endereço.")]
        [StringLength(10, ErrorMessage = "O número do endereço deve conter entre {2} e {1} caracteres.", MinimumLength = 1)]
        [DisplayName("Número")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Informe o nome do bairro.")]
        [StringLength(100, ErrorMessage = "O nome do bairro deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        [DisplayName("Bairro")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "Informe o nome da cidade.")]
        [StringLength(100, ErrorMessage = "O nome da cidade deve conter entre {2} e {1} caracteres.", MinimumLength = 1)]
        [DisplayName("Cidade")]
        public string City { get; set; }

        [Required(ErrorMessage = "Informe a sigla do estado.")]
        [StringLength(2, ErrorMessage = "O estado deve conter entre {1} caracteres.")]
        [DisplayName("Estado")]
        public string State { get; set; }

        [Required(ErrorMessage = "Informe o Cep do endereço.")]
        [StringLength(8, ErrorMessage = "O Cep do endereço deve conter {1} caracteres.")]
        [DisplayName("CEP")]
        public string ZipCode { get; set; }
    }
}
