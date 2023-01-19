using ContactsAPI.Data;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetContacts()
        {
            return View();
        }
    }
}
