public interface IProduitRepository
{
    Task<Produit> GetByIdAsync(int id);
    Task<IEnumerable<Produit>> GetAllAsync();
    Task AddAsync(Produit produit);
    Task DeleteAsync(Produit produit);
    Task SaveChangesAsync();
}
