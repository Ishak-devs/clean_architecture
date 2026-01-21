using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Service
{
    public class ProduitService
    {
        private readonly IProduitRepository _repo;

        public ProduitService(IProduitRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ProduitDto>> GetAllAsync()
        {
            var produits = await _repo.GetAllAsync();
            return produits.Select(static p => new ProduitDto
            {
                Id = p.Id,
                Nom = p.Nom,
                Prix = p.Prix,
                Stock = p.Stock
            });
        }

        public async Task<ProduitDto> GetByIdAsync(int id)
        {
            var produit = await _repo.GetByIdAsync(id);
            if (produit == null) return null;

            return new ProduitDto
            {
                Id = produit.Id,
                Nom = produit.Nom,
                Prix = produit.Prix,
                Stock = produit.Stock
            };
        }

        public async Task<int> CreerAsync(ProduitDto dto)
        {
            var prix = Convert.ToDecimal(dto.Prix, CultureInfo.GetCultureInfo("fr-FR"));
            var produit = new Produit(dto.Nom, prix, dto.Stock);

            await _repo.AddAsync(produit);
            await _repo.SaveChangesAsync();

            return produit.Id;
        }

        public async Task<bool> UpdateAsync(int id, ProduitDto dto)
        {
            var produit = await _repo.GetByIdAsync(id);
            if (produit == null) return false;

            var prix = Convert.ToDecimal(dto.Prix, CultureInfo.GetCultureInfo("fr-FR"));

            produit.ChangerNom(dto.Nom);
            produit.ChangerPrix(prix);
            produit.ChangerStock(dto.Stock);

            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SupprimerAsync(int id)
        {
            var produit = await _repo.GetByIdAsync(id);
            if (produit == null) return false;

            await _repo.DeleteAsync(produit);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}