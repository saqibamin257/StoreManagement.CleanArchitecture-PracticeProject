using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository _productRepository) 
        {
            this.productRepository = _productRepository;
        }
        [HttpGet]
        public ActionResult<List<ProductResponse>> GetProducts()
        {
            return Ok(this.productRepository.GetAllProducts());
        }
        [HttpGet("{id}")]
        public ActionResult GetProductById(int id)
        {
            try
            {
                var product = this.productRepository.GetProductById(id);
                return Ok(product);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost]
        public ActionResult Create(CreateProductRequest request)
        {
            var product = this.productRepository.CreateProduct(request);
            return Ok(product);
        }
        [HttpPut("{id}")]
        public ActionResult Update(UpdateProductRequest request)
        {
            try
            {
                var product = this.productRepository.UpdateProduct(request);
                return Ok(product);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                this.productRepository.DeleteProductById(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
