using ERPSystem.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineOfBusinessController : Controller
    {
        private readonly ErpContext _context;
        public LineOfBusinessController(ErpContext context)
        {

            _context = context;
        }

        // GET: api/<LinesOfBusinessController>
        [HttpGet]
        public IEnumerable<LinesOfBusiness> Get()
        {
            return _context.LinesOfBusinesses.ToList();
        }

        // GET api/<LinesOfBusinessController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var lineOfBusiness = _context.LinesOfBusinesses.Find(id);
            if (lineOfBusiness is null)
            {
                return NotFound();
            }
            return Ok(lineOfBusiness);
        }

        // POST api/<LinesOfBusinessController>
        [HttpPost]
        public IActionResult Post([FromBody] LinesOfBusiness lineOfBusiness)
        {
            if (lineOfBusiness is null)
            {
                return BadRequest();
            }
            _context.LinesOfBusinesses.Add(lineOfBusiness);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/<LinesOfBusinessController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LinesOfBusiness lineOfBusiness)
        {
            if (lineOfBusiness is null || lineOfBusiness.LineOfBusinessId != id)
            {
                return BadRequest();
            }

            var existingLineOfBusiness = _context.LinesOfBusinesses.Find(id);
            existingLineOfBusiness.LineOfBusinessName = lineOfBusiness.LineOfBusinessName;
            existingLineOfBusiness.AccountId = lineOfBusiness.AccountId;

            _context.LinesOfBusinesses.Update(existingLineOfBusiness);
            _context.SaveChanges();
            return Ok();

        }

        // DELETE api/<LinesOfBusinessController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var LineOfBusiness = _context.LinesOfBusinesses.Find(id);
            if (LineOfBusiness is null)
            {
                return NotFound();
            }
            _context.LinesOfBusinesses.Remove(LineOfBusiness);
            _context.SaveChanges();
            return Ok();
        }
    }
}
