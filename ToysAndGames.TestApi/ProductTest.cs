using System;
using System.Linq;
using ToysAndGames.Entities.Entities;
using ToysAndGames.Services.Contracts;
using ToysAndGames.Services.Services;
using ToysAndGames.TestApi.Fixtures;
using Xunit;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;
using Xunit.Microsoft.DependencyInjection.Attributes;

namespace ToysAndGames.TestApi
{
    [TestCaseOrderer("Xunit.Microsoft.DependencyInjection.TestsOrder.TestPriorityOrderer", "Xunit.Microsoft.DependencyInjection")]
    public class ProductTest : TestBed<TestProductFixture>
    {
        #region vars
        
        #endregion

        #region constructor
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ProductTest(ITestOutputHelper testOutputHelper, TestProductFixture fixture) : base (testOutputHelper, fixture)
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
        #endregion

        #region public test methods
        [Fact, TestOrder(1)]
        public void GetProducts_VerifyResponse()
        {
            #region GetProducts_VerifyResponse
            var service = _fixture.GetService<IProductService>(_testOutputHelper);
            var response = service?.GetProducts();

            //check if service generate instance correctly
            Assert.NotNull(response);

            //check if return value
            Assert.True(response?.Count > 0);
            #endregion
        }

        [Fact, TestOrder(2)]
        public void GetProductByCompany_CheckIfIsValidations()
        {
            #region GetProductByCompany_CheckIfIsValidations
            var service = _fixture.GetService<IProductService>(_testOutputHelper);
            
            var result = service?.GetProductsByCompany("");

            Assert.True(result?.HasError);
            #endregion
        }

        [Fact, TestOrder(3)]
        public void GetProductByCompany_CheckIfIgnoreCapitalCase()
        {
            #region GetProductByCompany_CheckIfIgnoreCapitalCase
            var service = _fixture.GetService<IProductService>(_testOutputHelper);
            var result = service?.GetProductsByCompany("DISNEY");

            Assert.True(result?.Entity?.Count >= 1);
            #endregion
        }

        [Fact, TestOrder(4)]
        public void GetProduct_CheckParamValue()
        {
            #region GetProduct_CheckParamValue
            var service = _fixture.GetService<IProductService>(_testOutputHelper);

            var response = service?.GetProduct(0);

            Assert.NotNull(response);
            Assert.True(response?.HasError);

            Assert.Equal("The key of product not registered!", response?.ExcepcionMessage);
            #endregion
        }

        [Fact, TestOrder(5)]
        public void GetProduct_VerifyEntityReturned()
        {
            #region GetProduct_VerifyEntityReturned
            var service = _fixture.GetService<IProductService>(_testOutputHelper);
            var productId = 1;

            var result = service?.GetProduct(productId);

            Assert.Equal(productId, result?.Entity?.Id);
            #endregion
        }

        [Fact, TestOrder(6)]
        public void AddProduct_CheckValidations()
        {
            #region AddProduct_CheckValidations
            var service = _fixture.GetService<IProductService>(_testOutputHelper);
            var messageError = "This Product name you want to add already exists for this company";

            var newProduct = new Product
            {
                Name = "Woody sheriff",
                Description = "A little of description for product",
                AgeRestriction = 3,
                Company = "Disney",
                Price = 10
            };

            var result = service?.AddProduct(newProduct);

            Assert.True(result?.HasError);
            Assert.Equal(messageError, result?.Error);
            #endregion
        }

        [Fact, TestOrder(7)]
        public void AddProduct_VerifyNewProduct()
        {
            #region AddProduct_CheckValidations

            var newProduct = new Product
            {
                Name = "Buzz Lightyear",
                Description = "Buzz Lightyear is a brawny electronic spaceman action figure.",
                AgeRestriction = 8,
                Company = "Disney",
                Price = 15
            };

            var service = _fixture.GetService<IProductService>(_testOutputHelper);
            var result = service?.AddProduct(newProduct);

            Assert.True(!result?.HasError);
            Assert.NotEqual(0, result?.Entity?.Id);

            #endregion
        }

        [Fact, TestOrder(8)]
        public void UpdateProduct_CheckValidationOfName()
        {
            #region UpdateProduct_CheckValidationOfName
            var messageError = "This Product name already exists for this company";

            var updatedProduct = new Product
            {
                Id = 2,
                Name = "Woody sheriff",
                Description = "A little of description for product",
                AgeRestriction = 3,
                Company = "Disney",
                Price = 10
            };

            var service = _fixture.GetService<IProductService>(_testOutputHelper);
            var result = service?.UpdateProduct(updatedProduct);

            Assert.True(result?.HasError);
            Assert.Equal(messageError, result?.Error);
            #endregion
        }

        [Fact, TestOrder(9)]
        public void UpdateProduct_CheckIfUpdateValue()
        {
            #region UpdateProduct_CheckIfUpdateValue
            var updatedProduct = new Product
            {
                Id = 5,
                Name = "Woody sheriffffffff",
                Description = "A little of description for product",
                AgeRestriction = 3,
                Company = "Disney",
                Price = 10
            };

            var service = _fixture.GetService<IProductService>(_testOutputHelper);
            var result = service?.UpdateProduct(updatedProduct);

            var checkUpdatedProduct = service?.GetProduct(updatedProduct.Id);

            Assert.False(result?.HasError);

            Assert.Equal(updatedProduct.Name, checkUpdatedProduct?.Entity?.Name);
            #endregion
        }

        [Fact, TestOrder(10)]
        public void DeleteProduct_CheckIfMakeValidationWithZeroKey()
        {
            #region DeleteProduct_CheckIfMakeValidations
            var messageError = "The product with this key not exists.";
            var service = _fixture.GetService<IProductService>(_testOutputHelper);
            var result = service?.DeleteProduct(0);

            Assert.True(result?.HasError);

            Assert.Equal(messageError, result?.Error);

            #endregion
        }

        [Fact, TestOrder(11)]
        public void DeleteProduct_CheckIfIsDeleted()
        {
            #region DeleteProduct_CheckIfIsDeleted
            var service = _fixture.GetService<IProductService>(_testOutputHelper);

            var listOfProducts = service?.GetProducts();
            Assert.NotNull(listOfProducts);

            var lastProduct = listOfProducts?.OrderByDescending(o => o.Id).FirstOrDefault();
            Assert.NotNull(lastProduct);

            int id = lastProduct != null ? lastProduct.Id : 0;

            var result = service?.DeleteProduct(id);

            Assert.False(result?.HasError);
            #endregion
        }
        #endregion

    }
}