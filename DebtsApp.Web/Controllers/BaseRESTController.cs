using System.Collections.Generic;
using System.Threading.Tasks;
using DebtsApp.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DebtsApp.Web.Controllers
{
    public abstract class BaseRESTController<T> : BaseController
        where T : IIdEntity
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

        [HttpGet("{id}")]
        public Task<T> GetT(long id)
        {
            return repo.Get(UserId.Value, id);
        }

        [HttpPost]
        public Task Post([FromBody] T value)
        {
            return repo.Add(UserId.Value, value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] T value)
        {
            var result = await repo.Update(UserId.Value, id, value);
            if(!result)
                return NotFound();

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var result = await repo.Delete(UserId.Value, id);
            if(!result)
                return NotFound();

            return Ok();
        }
    }
}