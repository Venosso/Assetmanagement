using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assetmanagement.Data;
using Assetmanagement.Models;

namespace Assetmanagement.Controllers {
    [ApiController]
    [Route("api/[Controller]")]
    public class MachinesController : ControllerBase {
        private readonly AssetmanagementContext _context;

        public MachinesController(AssetmanagementContext context)
        {
            _context = context;
        }

        //GET: api/machines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Machine>>> GetMachines() =>
            await _context.Machines.ToListAsync();


        // GET: api/machines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Machine>> GetMachine(int id)
        {
            var machine = await _context.Machines.FindAsync(id);
            if (machine == null) return NotFound();
            return machine;
        }

        // POST: api/machines
        [HttpPost]
        public async Task<ActionResult<Machine>> PostMachine(Machine machine) {
            _context.Machines.Add(machine);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMachine), new { id = machine.Id }, machine);

        }

        // PUT: api/machines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMachine(int id, Machine machine)
        {
            if (id != machine.Id)  return BadRequest();
            _context.Entry(machine).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/machines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachine(int id)
        {
            var machine = await _context.Machines.FindAsync(id);
            if (machine == null) return NotFound();
            _context.Machines.Remove(machine);
            await _context.SaveChangesAsync(); 
            return NoContent();
        }
    
    }
}
