using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtsApp.Web.APIModels;
using DebtsApp.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DebtsApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtsController : BaseRESTController<Debt>
    {


        public DebtsController(IDebtRepository debtRepo)
            : base(debtRepo)
        {
        }
    }
}
