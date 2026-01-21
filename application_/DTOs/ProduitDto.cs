namespace Application.DTOs;

public class ProduitDto
{
    public string Nom { get; set; } = string.Empty;
    public decimal Prix { get; set; }

    public int Stock { get; set; }
    public int Id { get; internal set; }
}