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
    
    public class MarcasController : ControllerBase
    {
        private readonly DbContexto _context;

        public MarcasController(DbContexto context)
        {
            _context = context;
        }

        // GET: Marcas
        [HttpGet]
        [Route("/marcas")]
        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.Marcas;
            return StatusCode(200, await dbContexto.ToListAsync());
        }
                      
        [HttpPost]
        [Route("/marcas")]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Marca marca)
        {                      
            _context.Add(marca);
            await _context.SaveChangesAsync();
            return StatusCode(201, marca);                                    
        }

        // POST: Marcas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPut]
        [Route("/marcas{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Marca marca)
        {
            if (id != marca.Id)
            {
                return NotFound();
            }                       
            try
            {
                    _context.Update(marca);
                    await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(marca.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(200, marca);                       
        }
       
        [HttpGet]
        [Route("/marcas{id}")]
        public async Task<Marca> Get(int id)
        {
            return await _context.Marcas.FindAsync(id);                      
        }

        [HttpDelete]
        [Route("/marcas{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }
        private bool MarcaExists(int id)
        {
            return _context.Marcas.Any(e => e.Id == id);
        }
    }
}