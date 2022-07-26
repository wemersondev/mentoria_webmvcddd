using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVCComDDD.Domain.Entities;

namespace WebMVCComDDD.Infra.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetAll();
        void Insert(Produto produto);
        Produto GetById(int id);
        void Update(Produto produto);
        void Delete(Produto produto);
    }
}
