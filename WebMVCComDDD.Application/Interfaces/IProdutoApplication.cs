using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVCComDDD.Application.ViewModels;

namespace WebMVCComDDD.Application.Interfaces
{
    public interface IProdutoApplication
    {
        IEnumerable<ProdutoViewModel> GetAll();
        void Insert(ProdutoViewModel produtoViewModel);
        ProdutoViewModel GetById(int id);
        void Update(ProdutoViewModel produtoViewModel);
        void Delete(int id);
    }
}
