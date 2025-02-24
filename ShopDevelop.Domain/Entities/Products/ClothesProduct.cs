namespace ShopDevelop.Domain.Entities.Products;

public class ClothesProduct
{
    public Guid Id { get; set; }
    public Neckline? Neckline { get; set; }
    
    public TheCut? TheCut { get; set; }
    public TypeOfPockets? TypeOfPockets { get; set; }
    public Gender? Gender { get; set; }
    public Season? Season { get; set; }
    public string? TakingCareOfThings { get; set; }
    public IEnumerable<ClothesSizes> Sizes { get; set; }
    public Product Product { get; set; }
    public Guid ProductId { get; set; }
}