using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationCRUD.Models;

namespace WebApplicationCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyExpancesController : ControllerBase
    {
        private readonly DailyExpancesContext db;

        public DailyExpancesController(DailyExpancesContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async  Task<ActionResult<List<Expense>>> getExpances()
        {
            var data=await db.Expenses.ToListAsync();
            return Ok(data);
        }

       [HttpGet("{id}")]
        public async  Task<ActionResult<Expense>> GetExpnacesById(int id)
        {
            var data= await db.Expenses.FindAsync(id);
            if(data== null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }
  [HttpPost]
        public async Task<ActionResult<Expense>> AddExpances(Expense ex)
        {
           await db.Expenses.AddAsync(ex);
            await db.SaveChangesAsync();
            return Ok(ex);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Expense>> EditExpances(int id,Expense ex)
        {
           if(id!=ex.Id)
            {
                return BadRequest();
            }
           db.Entry(ex).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok(ex);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Expense>> DeleteExpances(int id)
        {
            var data = await db.Expenses.FindAsync(id);
            if(data== null)
            {
                return NotFound();
            }
db.Expenses.Remove(data);
            await db.SaveChangesAsync();
            return Ok  ();
            
        }

    }
}
