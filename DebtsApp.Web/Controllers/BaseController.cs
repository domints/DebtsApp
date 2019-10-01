using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DebtsApp.Web.Controllers
{
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
        public long? UserId => User?.Claims?.Where(c => c.Type == ClaimTypes.Sid).Select(c => long.Parse(c.Value)).FirstOrDefault();
    }
}