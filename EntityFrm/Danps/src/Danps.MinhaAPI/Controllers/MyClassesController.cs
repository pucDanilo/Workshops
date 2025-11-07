using Danps.My.Domain.Models; 
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Danps.My.Data.Repository;

namespace Danps.MinhaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyClassController : ControllerBase
    {
        private readonly IMyClassRepository _repository;

        public MyClassController(IMyClassRepository repository)
        {
            _repository = repository;
        }

        // GET: api/MyClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyClass>>> GetMyClasses()
        {
            return await _repository.ObterTodos();
        }

        // GET: api/MyClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyClass>> GetMyClass(int id)
        {
            var myClass = await _repository.ObterPorId(id);

            if (myClass == null)
            {
                return NotFound();
            }

            return myClass;
        }

        /*

        // PUT: api/MyClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyClass(int id, MyClass myClass)
        {
            if (id != myClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(myClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MyClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MyClass>> PostMyClass(MyClass myClass)
        {
            _context.MyClasses.Add(myClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyClass", new { id = myClass.Id }, myClass);
        }

        // DELETE: api/MyClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyClass(int id)
        {
            var myClass = await _context.MyClasses.FindAsync(id);
            if (myClass == null)
            {
                return NotFound();
            }

            _context.MyClasses.Remove(myClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyClassExists(int id)
        {
            return _context.MyClasses.Any(e => e.Id == id);
        }
        */
    }
}