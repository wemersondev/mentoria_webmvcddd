using System.ComponentModel.DataAnnotations;

namespace WebMVCComDDD.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Nome")]
        [MaxLength(30, ErrorMessage = "Tamanho máximo de 30 caracteres")]
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo de 20 caracteres")]
        public string Marca { get; set; }
    }
}
