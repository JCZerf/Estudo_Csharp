using Estudo_C_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudo_C_.Controllers
{
    [Authorize]
    public class ConsumosController : Controller
    {
        private readonly AppDbContext _context;

        public ConsumosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Consumos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Consumos.Include(c => c.Veiculo);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Consumos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumos = await _context.Consumos
                .Include(c => c.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumos == null)
            {
                return NotFound();
            }

            return View(consumos);
        }

        // GET: Consumos/Create
        public IActionResult Create()
        {
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Nome");
            return View();
        }

        // POST: Consumos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Data,Valor,Km,Tipo,VeiculoId")] Consumos consumos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Nome", consumos.VeiculoId);
            return View(consumos);
        }

        // GET: Consumos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumos = await _context.Consumos.FindAsync(id);
            if (consumos == null)
            {
                return NotFound();
            }
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Nome", consumos.VeiculoId);
            return View(consumos);
        }

        // POST: Consumos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Data,Valor,Km,Tipo,VeiculoId")] Consumos consumos)
        {
            if (id != consumos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumosExists(consumos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Nome", consumos.VeiculoId);
            return View(consumos);
        }

        // GET: Consumos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumos = await _context.Consumos
                .Include(c => c.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumos == null)
            {
                return NotFound();
            }

            return View(consumos);
        }

        // POST: Consumos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consumos = await _context.Consumos.FindAsync(id);
            if (consumos != null)
            {
                _context.Consumos.Remove(consumos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumosExists(int id)
        {
            return _context.Consumos.Any(e => e.Id == id);
        }
    }
}
