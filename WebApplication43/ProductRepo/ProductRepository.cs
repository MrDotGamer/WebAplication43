using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication43.Contexts;
using WebApplication43.Entities;

namespace WebApplication43.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext productContext;
        public ProductRepository(ProductContext _productContext)
        {
            productContext = _productContext;
        }
        public async Task<int> AddProduct(Product product)
        {
            if (productContext != null)
            {
                await productContext.Products.AddAsync(product);
                await productContext.SaveChangesAsync();
                return product.ProductID;
            }
            return 0;
        }
        public async Task<int> DeleteProduct(int? productId)
        {
            int result = 0;
            if (productContext != null)
            {
                var product = await productContext.Products.FirstOrDefaultAsync(x => x.ProductID == productId);
                if (product != null)
                {
                    productContext.Products.Remove(product);
                    result = await productContext.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        public async Task<Product> GetProduct(int? productId)
        {
            if (productContext != null)
            {
                return await productContext.Products.Where(x => x.ProductID == productId)
                    .Select(x => new Product
                    {
                        ProductID = x.ProductID,
                        Price = x.Price,
                        ProductPicture = x.ProductPicture,
                        Category = x.Category,
                        Description = x.Description,
                        Name = x.Name,
                        ProductPictureUrl = x.ProductPictureUrl,
                        Section = x.Section
                    })
                    .FirstOrDefaultAsync();
            }
            return null;
        }
        public async Task<List<Product>> GetProducts(string userPermision)
        {
            if (productContext != null)
            {
                var d = await productContext.Products
                    .Where(p => p.Section == userPermision)
                    .Select(x => x)
                    .ToListAsync();
                return d;
            }
            return null;
        }
        public async Task UpdateProduct(Product product)
        {
            if (productContext != null)
            {
                productContext.Products.Update(product);
                await productContext.SaveChangesAsync();
            }
        }
    }
}
