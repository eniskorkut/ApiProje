using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator; // validation için FluentValidation kullanıyoruz ve bu validator'ı constructor injection ile alıyoruz
        private readonly ApiContext _context;

        public ProductsController(IValidator<Product> validator, ApiContext context)
        {
            _validator = validator;
            _context = context;
        }
        [HttpGet]
        public IActionResult ProductList() // ürün listesini döndüren bir endpoint
        {
            var values = _context.Products.ToList(); // ApiContext üzerinden Products DbSet'ini alıyoruz ve listeye çeviriyoruz
            return Ok(values);
        }
        [HttpPost] // burda endpointi POST olarak tanımlıyoruz ve belirlenen validasyon kurallarına göre ürün ekliyoruz
        // validasyon kurallarını ProductValidator sınıfında tanımladık ve böyle kullanıyoruz
        public IActionResult CreateProduct(Product product) // yeni bir ürün ekleyen endpoint
        {
            var validationResult = _validator.Validate(product); // ürünün doğrulamasını yapıyoruz
            if (!validationResult.IsValid) // eğer doğrulama başarısız olduysa
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage)); // hata mesajlarını döndürüyoruz
            }
            else
            {
                _context.Products.Add(product); // ürün ekliyoruz
                _context.SaveChanges(); // değişiklikleri kaydediyoruz
                return Ok(new { Message = "Ürün başarıyla eklendi.", data = product }); // doğrulama başarılıysa ürünü ekliyoruz ve başarı mesajı ile birlikte ürünü döndürüyoruz
            }

        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id); // silinecek ürünü buluyoruz
            _context.Products.Remove(value); // ürünü siliyoruz
            _context.SaveChanges(); // değişiklikleri kaydediyoruz
            return Ok(new { Message = "Ürün başarıyla silindi." }); // başarı mesajı döndürüyoruz
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _context.Products.Find(id); // id'si verilen ürünü buluyoruz
            return Ok(value); // ürünü döndürüyoruz
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validationResult = _validator.Validate(product); // ürünün doğrulamasını yapıyoruz
            if (!validationResult.IsValid) // eğer doğrulama başarısız olduysa
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage)); // hata mesajlarını döndürüyoruz
            }
            else
            {
                _context.Products.Update(product); // ürün ekliyoruz
                _context.SaveChanges(); // değişiklikleri kaydediyoruz
                return Ok(new { Message = "Ürün güncelleme işlemi başarılı.", data = product }); // doğrulama başarılıysa ürünü ekliyoruz ve başarı mesajı ile birlikte ürünü döndürüyoruz
            }
        }    
    }
}
