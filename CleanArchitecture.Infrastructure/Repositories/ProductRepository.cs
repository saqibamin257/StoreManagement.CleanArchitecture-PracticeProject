using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.IRepositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly StoreContext storeContext;
        private readonly IMapper mapper;
        public ProductRepository(StoreContext _storeContext, IMapper _mapper) 
        {
            this.storeContext = _storeContext;
            this.mapper = _mapper;
        }
        public ProductResponse CreateProduct(CreateProductRequest request)
        {
            var product = this.mapper.Map<Product>(request);
            product.Stock = 0;
            product.CreatedAt = product.UpdatedAt = DateTime.Now;

            this.storeContext.Products.Add(product);
            this.storeContext.SaveChanges();

            return this.mapper.Map<ProductResponse>(product);
        }

        public void DeleteProductById(int productId)
        {
            var product = this.storeContext.Products.Find(productId);
            if (product != null)
            {
                this.storeContext.Products.Remove(product);
                this.storeContext.SaveChanges();
            }
            else
            {
                // throw new NotFoundException();
            }
        }

        public ProductResponse GetProductById(int productId)
        {
            var product = this.storeContext.Products.Find(productId);
            if (product != null)
            {
                return this.mapper.Map<ProductResponse>(product);
            }
            return null;            
        }

        public List<ProductResponse> GetAllProducts()
        {
            return this.storeContext.Products.Select(p => this.mapper.Map<ProductResponse>(p)).ToList();
        }

        public ProductResponse UpdateProduct(int productId, UpdateProductRequest request)
        {
            var product = this.storeContext.Products.Find(productId);
            if (product != null)
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                product.Stock = request.Stock;
                product.UpdatedAt = DateTime.Now; //DateUtil.GetCurrentDate();

                this.storeContext.Products.Update(product);
                this.storeContext.SaveChanges();

                return this.mapper.Map<ProductResponse>(product);
            }

            return null;            
        }

        public ProductResponse UpdateProduct(UpdateProductRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
