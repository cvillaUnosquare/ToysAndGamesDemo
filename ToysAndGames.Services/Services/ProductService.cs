using ToysAndGames.Bll;
using ToysAndGames.Entities.Entities;
using ToysAndGames.Entities.ViewTools;
using ToysAndGames.Model.Contexts;
using ToysAndGames.Services.Contracts;

namespace ToysAndGames.Services.Services
{
    public class ProductService : IProductService
    {
        #region vars
        private readonly ProductBl _bl;
        #endregion

        #region constructors
        public ProductService(ToysAndGamesDbContext db)
        {
            _bl = new ProductBl(db);
        }
        #endregion

        #region public services
        public IList<Product> GetProducts()
        {
            #region GetProducts
            try
            {
                return _bl.GetProducts();
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        public ValidationResponse<IList<Product>> GetProductsByCompany(string companyName)
        {
            #region GetProductsByCompany
            try
            {
                var response = new ValidationResponse<IList<Product>>();

                if (string.IsNullOrEmpty(companyName))
                {
                    response.HasError = true;
                    response.Error = "Company name is required to search products";

                    return response;
                }

                response.Entity = _bl.GetProductsByCompanyName(companyName);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        public ValidationResponse<Product> GetProduct(int productId)
        {
            #region GetProduct
            var response = new ValidationResponse<Product>();

            try
            {
                response.Entity = _bl.GetProductById(productId);
            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.ExcepcionMessage = ex.Message;
                response.Error = ex.StackTrace;
            }

            return response;
            #endregion
        }

        public ValidationResponse<Product> AddProduct(Product entity)
        {
            #region AddProduct
            try
            {
                return _bl.AddProduct(entity);
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        public ValidationResponse<Product> UpdateProduct(Product entity)
        {
            #region UpdateProduct
            try
            {
                return _bl.UpdateProduct(entity);
            }
            catch (Exception) 
            {
                throw;
            }
            #endregion
        }

        public ValidationResponse<bool> DeleteProduct(int productId)
        {
            #region UpdateProduct
            try
            {
                return _bl.DeleteProduct(productId);
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }
        #endregion

        #region private methods
        #endregion
    }
}
