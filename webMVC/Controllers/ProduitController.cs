using Application.DTOs;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace webMVC.Controllers
{
    public class ProduitController : Controller
    {
        private readonly ProduitService _service;

        public ProduitController(ProduitService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var produits = await _service.GetAllAsync();
            return View(produits);
        }

        public async Task<IActionResult> Details(int id)
        {
            var produit = await _service.GetByIdAsync(id);
            if (produit == null) return NotFound();
            return View(produit);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProduitDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProduitDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            await _service.CreerAsync(dto);
            return RedirectToAction("Index");
        }
    }
}