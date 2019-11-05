using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autenticacao.Data;
using Autenticacao.Models;
using Microsoft.AspNetCore.Authorization;

namespace Autenticacao.Controllers
{
    public class TorneiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TorneiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Torneios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Torneio.ToListAsync());
        }

        // GET: Torneios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

                var torneio = await _context.Torneio
                .SingleOrDefaultAsync(m => m.Id == id);
            if (torneio == null)
            {
                return NotFound();
            }

            return View(torneio);
        }

        [Authorize]
        // GET: Torneios/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: Torneios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeTorneio,QuantidadeJogadores,Inicio, Premiacao")] Torneio torneio)
        {
            if (ModelState.IsValid)
            {
                torneio.Dono = User.Identity.Name;

                     
                _context.Add(torneio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(torneio);
        }
        [Authorize]
        // GET: Torneios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneio = await _context.Torneio.SingleOrDefaultAsync(m => m.Id == id);
            if (torneio == null)
            {
                return NotFound();
            }
            return View(torneio);
        }

        // POST: Torneios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeTorneio,QuantidadeJogadores,Inicio, Premiacao")] Torneio torneio)
        {
            if (id != torneio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(torneio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TorneioExists(torneio.Id))
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
            return View(torneio);
        }
        [Authorize]
        // GET: Torneios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneio = await _context.Torneio
                .SingleOrDefaultAsync(m => m.Id == id);
           
            if (torneio == null)
            {
                return NotFound();
            }
            if (User.Identity.Name != torneio.Dono)
            {
                return Forbid();
            }
            return View(torneio);
        }
        [Authorize]
        // POST: Torneios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var torneio = await _context.Torneio.SingleOrDefaultAsync(m => m.Id == id);
            if (User.Identity.Name != torneio.Dono)
            {
                return Forbid();
            }
            _context.Torneio.Remove(torneio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TorneioExists(int id)
        {
            return _context.Torneio.Any(e => e.Id == id);
        }
    }
}
