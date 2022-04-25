using ToysAndGames.Entities.Entities;
using ToysAndGames.Entities.ViewTools;

namespace ToysAndGames.Services.Contracts
{
    public interface IProductService
    {
        IList<Product> GetProducts();
        ValidationResponse<IList<Product>> GetProductsByCompany(string companyName);
        ValidationResponse<Product> GetProduct(int productId);
        ValidationResponse<Product> AddProduct(Product entity);
        ValidationResponse<Product> UpdateProduct(Product entity);
        ValidationResponse<bool> DeleteProduct(int productId);
    }
}
