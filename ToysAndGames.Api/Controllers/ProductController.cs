<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
=======
﻿using Microsoft.AspNetCore.Mvc;
>>>>>>> 0aaa84207e6491bd2412b80bd7b243f04156015b
using ToysAndGames.Entities.Entities;
using ToysAndGames.Services.Contracts;

namespace ToysAndGames.Api.Controllers
{
<<<<<<< HEAD
    [EnableCors("_ToysPolicy")]
=======
>>>>>>> 0aaa84207e6491bd2412b80bd7b243f04156015b
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        #region vars
        private readonly IProductService _serv;
        #endregion

        #region constructors
        public ProductController(IProductService service)
        {
            _serv = service;
        }

        #endregion

        #region public methods

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            #region GetProducts
            try
            {
                return Ok(_serv.GetProducts());
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        [HttpGet("GetProductsByCompany")]
        public IActionResult GetProducts(string companyName)
        {
            #region GetProducts
            try
            {
                return Ok(_serv.GetProductsByCompany(companyName));
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int productId)
        {
            #region GetProducts
            try
            {
                return Ok(_serv.GetProduct(productId));
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        [HttpPost("Create")]
        public IActionResult CreateProduct([FromBody]Product entity)
        {
            #region CreateProduct
            try
            {
<<<<<<< HEAD
                ModelState.Remove("Id");

=======
>>>>>>> 0aaa84207e6491bd2412b80bd7b243f04156015b
                if(!ModelState.IsValid)
                    return BadRequest(entity);

                return Ok(_serv.AddProduct(entity));
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        [HttpPut("Update")]
        public IActionResult UpdateProduct([FromBody]Product entity)
        {
            #region UpdateProduct
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(entity);

                return Ok(_serv.UpdateProduct(entity));
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteProduct(int productId)
        {
            #region DeleteProduct
            try
            {
                return Ok(_serv.DeleteProduct(productId));
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
