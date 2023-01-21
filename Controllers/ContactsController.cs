using ContactsAPI.Data;
using Microsoft.AspNetCore.Mvc;
using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Controllers
{
    [ApiController] //prvo anotacija da je api controller a ne mvc cntrlr
    [Route("api/[controller]")]//ubacuje ime ovog kontrolera unutra
    public class ContactsController : Controller
    {
        private readonly ContactsAPIDbContext dbContext;

        public ContactsController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]//za swagger
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)// zbog asynca iaction wrapovan u task
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Adress = addContactRequest.Adress,
                Email = addContactRequest.Email,
                FullName = addContactRequest.FullName,
                Phone = addContactRequest.Phone

            };

            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();

            return Ok(contact);
        }

    }
}
