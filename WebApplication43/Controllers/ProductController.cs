using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication43.Entities;
using WebApplication43.ImageWriter.Handler;
using WebApplication43.ProductRepo;
using WebApplication43.URLHelper;
using WebApplication43.ViewModels;

namespace WebApplication43.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IImageHandler _imageHandler;
        public ProductController(IProductRepository _productRepository, IImageHandler imageHandler)
        {
            productRepository = _productRepository;
            _imageHandler = imageHandler;
        }
        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var userPermision = User.Claims.Where(x => x.Type == "permission").Select(x => x.Value).FirstOrDefault();
                var products = await productRepository.GetProducts(userPermision);
                if (products == null)
                    return NotFound();
                return Ok(products);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> GetProduct(int? productId)
        {
            try
            {
                var product = await productRepository.GetProduct(productId);
                if (product == null)
                    return NotFound();
                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int? productId)
        {
            if (productId == null)
                return BadRequest();
            try
            {
                var result = await productRepository.DeleteProduct(productId);
                if (result == 0)
                    return NotFound();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("AddProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [RequestFormLimits(ValueLengthLimit = 8388608)]
        public async Task<IActionResult> AddProduct([FromForm] ProductViewModelApi model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IFormFile image;
                    byte[] imageBytes = Convert.FromBase64String(model.ProductImage);
                    MemoryStream ms = null;
                    ms = new MemoryStream(imageBytes);
                    image = new FormFile(ms, 0, imageBytes.Length, model.Name, model.Name);
                    Product product = new Product()
                    {
                        Name = model.Name,
                        Price = model.Price,
                        Description = model.Description,
                        Section = model.Section,
                        Category = model.Category,
                        ProductPictureUrl = UrlHelper.GetUrl(image.FileName),
                        ProductPicture = await _imageHandler.UploadImage(image)
                    };
                    await productRepository.AddProduct(product);
                    if (ms != null)
                    {
                        ms.Dispose();
                    }
                }
                catch (Exception e)
                {
                    return Ok(e.Message);
                }
            }
            else
            {
                return BadRequest(new { message = "Ctoto poshlo ne tak" });
            }
            return Ok(1);
        }
    }
}
