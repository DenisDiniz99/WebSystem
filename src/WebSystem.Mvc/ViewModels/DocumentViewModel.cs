using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebSystem.Mvc.ViewModels
{
    public class DocumentViewModel
    {
        [Required(ErrorMessage = "Informe um tipo de documento válido.")]
        [DisplayName("Tipo do Documento")]
        public int Type { get; set; }

        [Required(ErrorMessage = "Informe o número do documento de acordo com seu tipo.")]
        [MaxLength(14, ErrorMessage = "O número do documento deve conter até {1} caracteres (Caso seja CNPJ).")]
        [DisplayName("Número do Documento")]
        public string Number { get; set; }
    }
}
