using System.ComponentModel.DataAnnotations;

namespace WebSystem.Mvc.ViewModels
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = "Informe o nome da rua.")]
        [StringLength(100, ErrorMessage = "O nome da rua deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Street { get; set; }

        [Required(ErrorMessage = "Informe o número do endereço.")]
        [StringLength(1, ErrorMessage = "O número do endereço deve conter entre {2} e {1} caracteres.", MinimumLength = 10)]
        public string Number { get; set; }

        [Required(ErrorMessage = "Informe o nome do bairro.")]
        [StringLength(2, ErrorMessage = "O nome do bairro deve conter entre {2} e {1} caracteres.", MinimumLength = 100)]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "Informe o nome da cidade.")]
        [StringLength(1, ErrorMessage = "O nome da cidade deve conter entre {2} e {1} caracteres.", MinimumLength = 100)]
        public string City { get; set; }

        [Required(ErrorMessage = "Informe a sigla do estado.")]
        [StringLength(2, ErrorMessage = "O estado deve conter entre {1} caracteres.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Informe o Cep do endereço.")]
        [StringLength(8, ErrorMessage = "O Cep do endereço deve conter {1} caracteres.")]
        public string ZipCode { get; set; }
    }
}
