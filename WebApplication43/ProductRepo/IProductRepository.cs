using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication43.Entities;

namespace WebApplication43.ProductRepo
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts(string userPermision);

        Task<Product> GetProduct(int? productId);

        Task<int> AddProduct(Product product);

        Task<int> DeleteProduct(int? productId);

        Task UpdateProduct(Product product);
    }
}
