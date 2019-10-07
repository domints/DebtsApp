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
    public class ContactsController : BaseRESTController<Contact>
    {

        public ContactsController(IContactRepository contactRepo)
            : base(contactRepo)
        {
        }        
    }
}
