using PizzaDelivery_V2.BLL.Interfaces;
using PizzaDelivery_V2.DAL.Repositories;
using PizzaDelivery_V2.DAL.Repositories.Interfaces;
using PizzaDelivery_V2.Domain.Entities;
using PizzaDelivery_V2.Domain.Enum;
using PizzaDelivery_V2.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery_V2.BLL.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IBaseResponse<IEnumerable<Product>>> GetProducts()
        {
            var baseResponse = new BaseResponse<IEnumerable<Product>>();
            try
            {
                var products = await _productRepository.GetEntity();
                if (products == null)
                {
                    baseResponse.Description = "Found 0 elements";
                    baseResponse.statusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = products;
                baseResponse.statusCode = StatusCode.OK;
                return baseResponse;
            } 
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Product>>()
                {
                    Description = $"[GetProducts] : {ex.Message}"
                };
            }            
        }
    }
}
