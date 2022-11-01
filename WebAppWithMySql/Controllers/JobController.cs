using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAppWithMySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : Controller
    {
        private MySQLDBContext _dbContext;

        public JobController(MySQLDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IList<Job> Get()
        {
            return (this._dbContext.Job.Include(x => x.User).ToList());
        }

        [HttpPost]
        public async Task<ActionResult<Job>> Post(Job job)
        {
            this._dbContext.Job.Add(job);
            await this._dbContext.SaveChangesAsync();
            return Ok(job);
        }
    }
}
