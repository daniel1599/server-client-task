using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server_side_app.Models;

namespace server_side_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassItemsController : ControllerBase
    {
        private readonly ClassContext _context;

        public ClassItemsController(ClassContext context)
        {
            _context = context;
            var classes = new List<ClassItem>
            {
            new ClassItem
            {
                Id = 1,
                TeacherFirstName = "Michal",
                TeacherLastName = "Cohen",
                StudentsNames = "Nadav Amara, Ron Israeli, Dan Edri, Yosef Levi, Idan Chen, Tom Edri"
            },
            new ClassItem
            {
                Id = 2,
                TeacherFirstName = "Beni",
                TeacherLastName = "Nachum",
                StudentsNames = "Avi Amara, Ron Feder, Dan Edri, Shachar Levi, Idan Chen, Naor Edri, Segev Smith, Dana Lev, Or Cohen, Or Shpiz, Eden Zangbi"
            }
        };
            foreach (var cla in classes)
            {
                if (!ClassItemExists(cla.Id))                    
                    context.ClassItems.Add(cla);
            }            
            context.SaveChanges();
        }

        // GET: api/ClassItems
        [HttpGet]
        private async Task<ActionResult<IEnumerable<ClassItem>>> GetClassItems()
        {
            return await _context.ClassItems.ToListAsync();
        }

        // GET: api/ClassItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassItem>> GetClassInfoById(long id)
        {
            var classItem = await _context.ClassItems.FindAsync(id);

            if (classItem == null)
            {
                return NotFound();
            }

            return classItem;
        }

        // PUT: api/ClassItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        private async Task<IActionResult> PutClassItem(long id, ClassItem classItem)
        {
            if (id != classItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(classItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassItemExists(id))
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

        // POST: api/ClassItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        private async Task<ActionResult<ClassItem>> PostClassItem(ClassItem classItem)
        {
            _context.ClassItems.Add(classItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassItem", new { id = classItem.Id }, classItem);
        }

        // DELETE: api/ClassItems/5
        [HttpDelete("{id}")]
        private async Task<IActionResult> DeleteClassItem(long id)
        {
            var classItem = await _context.ClassItems.FindAsync(id);
            if (classItem == null)
            {
                return NotFound();
            }

            _context.ClassItems.Remove(classItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassItemExists(long id)
        {
            return _context.ClassItems.Any(e => e.Id == id);
        }
    }
}
