using System.ComponentModel.DataAnnotations;

namespace WebSystem.Mvc.ViewModels
{
    public class EmailViewModel
    {
        [Required(ErrorMessage = "Informe um endereço de e-mail.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O endereço de e-mail está incorreto.")]
        public string EmailAddress { get; set; }
    }
}
