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
            return produits.Select(p => new ProduitDto
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
            var produit = new Produit(dto.Nom, dto.Prix, dto.Stock); 

            await _repo.AddAsync(produit);
            await _repo.SaveChangesAsync();

            return produit.Id;
        }

        public async Task<bool> UpdateAsync(int id, ProduitDto dto)
        {
            var produit = await _repo.GetByIdAsync(id);
            if (produit == null) return false;

            produit.ChangerNom(dto.Nom);
            produit.ChangerPrix(dto.Prix); 
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
