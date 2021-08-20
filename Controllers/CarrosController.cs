using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Webapi.Models;
using Webapi.Servicos;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarrosController : ControllerBase
    {
        private readonly DbContexto _context;

        public CarrosController(DbContexto context)
        {
            _context = context;
        }

        // GET: Carros
        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.Carros;
            return StatusCode(200, await dbContexto.ToListAsync());
        }
                      
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Nome,Modelo,MarcaId,Ano")] Carro carro)
        {                      
            _context.Add(carro);
            await _context.SaveChangesAsync();
            return StatusCode(201, carro);                                    
        }

        // POST: Carros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPut]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Modelo,MarcaId,Ano")] Carro carro)
        {
            if (id != carro.Id)
            {
                return NotFound();
            }                       
            try
            {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(carro.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(200, carro);                       
        }
       
        [HttpDelete, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }
        private bool CarroExists(int id)
        {
            return _context.Carros.Any(e => e.Id == id);
        }
    }
}