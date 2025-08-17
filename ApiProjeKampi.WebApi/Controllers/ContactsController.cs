using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Dtos.ContactDto;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ContactsController(ApiContext context) // Constructor injection for ApiContext
        {
            _context = context;// Initialize the context property
        }
        [HttpGet] // Method to get the list of contacts
        public IActionResult ContactList()// Method to get the list of contacts
        {
            var values = _context.Contacts.ToList(); // Fetch all contacts from the database
            return Ok(values);
        }
        [HttpPost]// Method to create a new contact
        public IActionResult CreateContact(CreateContactDto createContactDto) // Method to create a new contact
        {
            Contact contact = new Contact(); // Veritabanına kaydedilecek olan asıl Contact nesnesi oluşturulur.
            contact.Email = createContactDto.Email; // Gelen DTO'daki veriler, tek tek veritabanı nesnesinin ilgili alanlarına kopyalanır. Bu işleme "mapping" (haritalama) denir.
            contact.Address = createContactDto.Address;
            contact.Phone = createContactDto.Phone;
            contact.MapLocation = createContactDto.MapLocation;
            contact.OpenHours = createContactDto.OpenHours;
            _context.Contacts.Add(contact); // Hazırlanan yeni contact nesnesi, Entity Framework'e "bunu veritabanına eklemeye hazırlan" komutunu verir. Bu aşamada henüz veritabanına bir şey yazılmaz.
            _context.SaveChanges(); //Biriktirilen tüm değişiklikleri (bu durumda sadece yeni bir Contact ekleme) tek bir işlem olarak veritabanına kaydeder.
            return Ok("Ekleme işlemi başarılı"); //İşlemin başarıyla tamamlandığını belirten bir metin ve HTTP 200 OK durum kodunu istemciye döndürür.
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");

        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _context.Contacts.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact();
            contact.Email = updateContactDto.Email;
            contact.Address = updateContactDto.Address;
            contact.Phone = updateContactDto.Phone;
            contact.MapLocation = updateContactDto.MapLocation;
            contact.OpenHours = updateContactDto.OpenHours;
            contact.ContactId = updateContactDto.ContactId;
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}
