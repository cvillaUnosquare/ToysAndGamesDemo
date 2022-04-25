using ToysAndGames.Dal;
using ToysAndGames.Entities.Entities;
using ToysAndGames.Entities.ViewTools;
using ToysAndGames.Model.Contexts;

namespace ToysAndGames.Bll
{
    public class ProductBl
    {
        #region vars
        private readonly ProductDal _dal;
        #endregion

        #region constructos
        public ProductBl(ToysAndGamesDbContext db)
        {
            _dal = new ProductDal(db);
        }
        #endregion

        #region public methods
        public List<Product> GetProducts()
        {
            #region GetProducts
            try
            {
                return _dal.GetProducts();
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        public List<Product> GetProductsByCompanyName(string companyName)
        {
            #region GetProductsByCompanyName
            try
            {
                return _dal.GetProductsByCompanyName(companyName);
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        public Product GetProductById(int Id)
        {
            #region GetProductById
            try
            {
                return _dal.GetProductById(Id);
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        public ValidationResponse<Product> AddProduct(Product entity)
        {
            #region AddProduct
            try
            {
                var response = new ValidationResponse<Product>();
                response.Entity = entity;

                response = this.MakeValidationsOfProduct(response, true);

                if (!response.HasError)
                    response.Entity = _dal.AddProduct(entity);

                return response;
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
                var response = new ValidationResponse<Product>();
                response.Entity = entity;

                response = this.MakeValidationsOfProduct(response, false);

                if (!response.HasError)
                    response.Entity = _dal.UpdateProduct(entity);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        public ValidationResponse<bool> DeleteProduct(int productId)
        {
            #region DeleteProduct
            try
            {
                var response = new ValidationResponse<bool>();

                //TODO: Make validations

                if(!response.HasError)
                    response = _dal.DeleteProduct(productId);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }
        #endregion

        #region private methods
        private ValidationResponse<Product> MakeValidationsOfProduct(ValidationResponse<Product> objectProduct, bool isAddAction)
        {
            #region MakeValidationsOfProduct
            try
            {
                var entityObject = objectProduct.Entity;
                //validation of name in add action
                #pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (_dal.Validate(x => x.Name == entityObject.Name && x.Company == entityObject.Company) && isAddAction)
                {
                    objectProduct.HasError = true;
                    objectProduct.Error = "This Product name you want to add already exists for this company";
                }

                //validation of name in update action
                if (_dal.Validate(x => x.Id != entityObject.Id && x.Name == entityObject.Name && x.Company == entityObject.Company) && !isAddAction)
                {
                    objectProduct.HasError = true;
                    objectProduct.Error = "This Product name already exists for this company";    
                }
                #pragma warning restore CS8602 // Dereference of a possibly null reference.

                return objectProduct;
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }
        #endregion
    }
}
