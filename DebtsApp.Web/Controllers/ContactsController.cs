using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtsApp.Web.APIModels;
using DebtsApp.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DebtsApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : BaseController
    {
        private readonly IContactRepository contactRepo;

        public ContactsController(IContactRepository contactRepo)
        {
            this.contactRepo = contactRepo;
        }
        
        [HttpGet]
        public Task<List<Contact>> Get()
        {
            return contactRepo.GetAll(UserId.Value);
        }

        [HttpPost]
        public Task Post([FromBody] Contact value)
        {
            return contactRepo.Add(UserId.Value, value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
