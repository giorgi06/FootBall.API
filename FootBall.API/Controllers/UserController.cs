using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootBall.API.Controllers
{
    using FootBall.API.Context;
    using FootBall.API.Models;

    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext db;

        public UserController(UserContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<CreateUser>>> GetAll()

        {
            return await this.db.User.ToListAsync();
        }

        [HttpGet("[action]/{Id}")]
        public async Task<ActionResult<CreateUser>> GetById(int id)
        {
            CreateUser user = await this.db.User.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return NotFound();

            return new ObjectResult(user);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<CreateUser>> Create([FromQuery]CreateUser user)
        {
            if (user == null)
                return this.BadRequest();

            db.User.Add(user);

            await this.db.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<CreateUser>> Update ([FromQuery]CreateUser user)
        {
            if (user == null)
                return this.BadRequest();

            if (!db.User.Any(x => x.Id == user.Id))
                return this.NotFound();

            db.User.Update(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<CreateUser>> Delete(int id)
        {
            CreateUser user = await this.db.User.FirstOrDefaultAsync(x => x.Id == id);
             
            if (id < 0)
                return NotFound();

            db.User.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
