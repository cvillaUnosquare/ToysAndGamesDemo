using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToysAndGames.Entities.Entities;
using ToysAndGames.Entities.ViewTools;
using ToysAndGames.Model.Contexts;

namespace ToysAndGames.Dal
{
    public class ProductDal
    {
        #region vars
        private readonly ToysAndGamesDbContext _db;
        #endregion

        #region constructors
        public ProductDal(ToysAndGamesDbContext db)
        {
            _db = db;
        }

        #endregion

        #region public methods
        public List<Product> GetProducts()
        {
            #region GetProducts
            try
            {
                return _db.Products.AsNoTracking().OrderBy(o => o.Name).ToList();
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
                #pragma warning disable CS8602 // Dereference of a possibly null reference.
                return _db.Products
                    .AsNoTracking()
                    .Where(predicate: w => w.Company.Trim().ToUpper().Contains(companyName.Trim().ToUpper()))
                    .ToList();
                #pragma warning restore CS8602 // Dereference of a possibly null reference.
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
                var product = _db.Products.AsNoTracking().Where(w => w.Id == Id).FirstOrDefault();

                if (product == null)
                    throw new ArgumentException("The key of product not registered!");

                return product;
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        public Product AddProduct(Product entity)
        {
            #region AddProduct
            try
            {
                _db.Products.Add(entity);
                _db.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        public Product UpdateProduct(Product entity)
        {
            #region UpdateProduct
            try
            {
                _db.Products.Update(entity);
                _db.SaveChanges();

                return entity;
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
                var product = _db.Products.Where(w => w.Id == productId).FirstOrDefault();

                if (product == null)
                {
                    response.HasError = true;
                    response.Error = "The product with this key not exists.";

                    return response;
                }

                _ = _db.Products.Remove(product);
                _db.SaveChanges();
                
                return response;
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        public bool Validate(Expression<Func<Product, bool>> expression)
        {
            #region Validate
            try
            {
                return _db.Products.Any(expression);
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        public void DisposeConn() => _db.Dispose();
        #endregion

        #region private methods
        #endregion
    }
}
