using WebMVCComDDD.Application.Interfaces;
using WebMVCComDDD.Application.ViewModels;
using WebMVCComDDD.Domain.Entities;
using WebMVCComDDD.Infra.Interfaces;

namespace WebMVCComDDD.Application.Applications
{
    public class ProdutoApplication : IProdutoApplication
    {
        IProdutoRepository _produtoRepository;

        public ProdutoApplication(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void Delete(int id)
        {
            var produto = _produtoRepository.GetById(id);
            if (produto != null)
                _produtoRepository.Delete(produto);
        }

        public IEnumerable<ProdutoViewModel> GetAll()
        {
            var produtos = _produtoRepository.GetAll();
            var produtosViewModel = produtos.Select(produto => new ProdutoViewModel
            {
                Marca = produto.Marca,
                Nome = produto.Nome,
                Id = produto.Id
            });
            return produtosViewModel;
        }

        public ProdutoViewModel GetById(int id)
        {
            var produto = _produtoRepository.GetById(id);
            return new ProdutoViewModel
            {
                Id = produto.Id,
                Marca = produto.Marca,
                Nome = produto.Nome
            };
        }

        public void Insert(ProdutoViewModel produtoViewModel)
        {
            var produto = new Produto
            {
                Marca = produtoViewModel.Marca,
                Nome = produtoViewModel.Nome,
            };
            _produtoRepository.Insert(produto);
        }

        public void Update(ProdutoViewModel produtoViewModel)
        {
            var produto = _produtoRepository.GetById(produtoViewModel.Id);
            produto.Marca = produtoViewModel.Marca;
            produto.Nome = produtoViewModel.Nome;
            _produtoRepository.Update(produto);
        }
    }
}
