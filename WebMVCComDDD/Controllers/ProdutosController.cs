using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVCComDDD.Application.Helpers;
using WebMVCComDDD.Application.Interfaces;
using WebMVCComDDD.Application.ViewModels;
using WebMVCComDDD.Data;

namespace WebMVCComDDD.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly IProdutoApplication _produtoApplication;

        private readonly IEmailApplication _emailApplication;

        public ProdutosController(IProdutoApplication produtoApplication, IEmailApplication emailApplication)
        {
            _produtoApplication = produtoApplication;
            _emailApplication = emailApplication;
        }

        public async Task<IActionResult> Index()
        {
            return View(_produtoApplication.GetAll());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(_produtoApplication.GetById(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            _produtoApplication.Insert(produtoViewModel);

            string body = "<h1>Novo produto cadastrado: " + produtoViewModel.Nome + "</h1>";
            var emailRequest = new EmailRequest
            {
                Body = body,
                Subject = "Cadastro de produto",
                ToEmail = "santoswemerson30@gmail.com"
            };
            await _emailApplication.SendEmailAsync(emailRequest);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(_produtoApplication.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdutoViewModel produtoViewModel)
        {
            _produtoApplication.Update(produtoViewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(_produtoApplication.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _produtoApplication.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}