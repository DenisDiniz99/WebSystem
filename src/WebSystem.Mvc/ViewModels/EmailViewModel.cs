using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebSystem.Mvc.ViewModels
{
    public class EmailViewModel
    {
        [Required(ErrorMessage = "Informe um endereço de e-mail.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O endereço de e-mail está incorreto.")]
        [DisplayName("Endereço de E-mail")]
        public string EmailAddress { get; set; }
    }
}
