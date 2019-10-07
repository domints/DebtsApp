using System.Collections.Generic;
using System.Threading.Tasks;
using DebtsApp.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DebtsApp.Web.Controllers
{
    public abstract class BaseRESTController<T> : BaseController
    {
        protected readonly IBaseRepository<T> repo;

        public BaseRESTController(IBaseRepository<T> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public Task<List<T>> Get()
        {
            return repo.GetAll(UserId.Value);
        }

        [HttpPost]
        public Task Post([FromBody] T value)
        {
            return repo.Add(UserId.Value, value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] T value)
        {
            var result = await repo.Update(UserId.Value, id, value);
            if(!result)
                return NotFound();

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await repo.Delete(UserId.Value, id);
            if(!result)
                return NotFound();

            return Ok();
        }
    }
}