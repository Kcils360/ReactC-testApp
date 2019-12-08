using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactTestApp.Models;

namespace ReactTestApp.Controllers
{
    [Route("api/[controller]")]
    public class ToDoesController : Controller
    {
        private readonly ReactTestAppContext _context;

        public ToDoesController(ReactTestAppContext context)
        {
            _context = context;
        }

        // GET: api/ToDoes
        [HttpGet("[action]")]
        public IEnumerable<ToDo> GetToDos()
        {
            var list = _context.ToDo.Select(l => l).ToList();
            return list; 
        }

        // GET: api/ToDoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDo>> GetToDo(int id)
        {
            var toDo = await _context.ToDo.FindAsync(id);

            if (toDo == null)
            {
                return NotFound();
            }

            return toDo;
        }

        // PUT: api/ToDoes/5
        [HttpPut("{id}/[action]")]
        public async Task<IActionResult> PutToDo([FromBody] TodoJson doObject)
        {
            if (doObject.id != doObject.todo.ID)
            {
                return BadRequest();
            }
            //TODO - add linq query to make change to DB
            _context.Entry(doObject.todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoExists(doObject.id))
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

        // POST: api/ToDoes
        [HttpPost]
        public async Task<ActionResult<ToDo>> PostToDo(ToDo toDo)
        {
            _context.ToDo.Add(toDo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDo", new { id = toDo.ID }, toDo);
        }

        // DELETE: api/ToDoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDo>> DeleteToDo(int id)
        {
            var toDo = await _context.ToDo.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }

            _context.ToDo.Remove(toDo);
            await _context.SaveChangesAsync();

            return toDo;
        }

        private bool ToDoExists(int id)
        {
            return _context.ToDo.Any(e => e.ID == id);
        }
    }

    public class TodoJson
    {
        public int id { get; set; }
        public ToDo todo { get; set; }
    }
}
