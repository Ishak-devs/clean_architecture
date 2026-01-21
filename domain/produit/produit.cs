using System.ComponentModel.DataAnnotations;

public class Produit
{
    public Produit(string nom, decimal prix, int stock)
    {
        Nom = nom;
        Prix = prix;
        Stock = stock;
    }

    public int Id { get; set; } 

    [Required]
    [StringLength(100)]
    public string Nom { get; set; } = string.Empty;

    [Range(0.01, 10000)]
    public decimal Prix { get; set; }

    public int Stock { get; set; }

    public DateTime DateCreation { get; set; } = DateTime.Now;

    public void ChangerNom(string nom)
    {
        throw new NotImplementedException();
    }

    public void ChangerPrix(decimal prix)
    {
        throw new NotImplementedException();
    }

    public void ChangerStock(int stock)
    {
        throw new NotImplementedException();
    }
}