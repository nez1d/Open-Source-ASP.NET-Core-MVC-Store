using ShopDevelop.Application.Repository;

namespace ShopDevelop.Application.Services.Seller;

public class SellerService : ISellerService
{
    private readonly ISellerRepository sellerRepository;

    public SellerService(ISellerRepository sellerRepository) =>
        this.sellerRepository= sellerRepository;
    
    public async Task<Guid> CreateSellerAsync(
        string name, string description,
        string imagePath, string imageFooterPath)
    {
        var seller = new Domain.Models.Seller
        {
            Name = name,
            Description = description,
            ImagePath = imagePath,
            ImageFooterPath = imageFooterPath
        };

        var result = await sellerRepository.Create(seller);

        return seller.Id;
    }

    public Task<Guid> CreateSellerAsync(Domain.Models.Seller seller)
    {
        throw new NotImplementedException();
    }

    public async Task EditSellerAsync(Domain.Models.Seller seller)
    {
        var model = await sellerRepository.GetById(seller.Id);
        await sellerRepository.Update(seller);
    }

    public async Task DeleteSellerAsync(Guid id)
    {
        var result = await sellerRepository.GetById(id);
        if (result != null)
        {
            await sellerRepository.Delete(id);   
        }
    }
    
    public Task<IEnumerable<Domain.Models.Seller>> GetAllSellerAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Domain.Models.Seller> GetSellerByIdAsync(Guid id)
    {
        return await sellerRepository.GetById(id);
    }
}