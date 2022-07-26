using System.ComponentModel.DataAnnotations;

namespace WebMVCComDDD.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Marca { get; set; }
    }
}