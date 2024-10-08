﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SC_701_ProyectoG4_Horarios.DAL;

namespace SC_701_ProyectoG4_Horarios.Controllers
{
    public class ProfesoresController : Controller
    {
        private readonly HorariosContext _context;

        public ProfesoresController(HorariosContext context)
        {
            _context = context;
        }

        // GET: Profesores
        public async Task<IActionResult> Index()
        {
            var horariosContext = _context.Profesores.Include(p => p.Usuario);
            return View(await horariosContext.ToListAsync());
        }

        // GET: Profesores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // GET: Profesores/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios.Select(u => new { Id = u.Id, NombreCompleto = u.Nombre + " " + u.PrimerApellido + " " + u.SegundoApellido }), "Id", "NombreCompleto");
            return View();
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Departamento,Titulo,UsuarioId")] Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios.Select(u => new { Id = u.Id, NombreCompleto = u.Nombre + " " + u.PrimerApellido + " " + u.SegundoApellido }), "Id", "NombreCompleto", profesor.UsuarioId);
            return View(profesor);
        }

        // GET: Profesores/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios.Select(u => new { Id = u.Id, NombreCompleto = u.Nombre + " " + u.PrimerApellido + " " + u.SegundoApellido }), "Id", "NombreCompleto", profesor.UsuarioId);
            return View(profesor);
        }

        // POST: Profesores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Departamento,Titulo,UsuarioId")] Profesor profesor)
        {
            if (id != profesor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesorExists(profesor.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios.Select(u => new { Id = u.Id, NombreCompleto = u.Nombre + " " + u.PrimerApellido + " " + u.SegundoApellido }), "Id", "NombreCompleto", profesor.UsuarioId);
            return View(profesor);
        }

        // GET: Profesores/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // POST: Profesores/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor != null)
            {
                _context.Profesores.Remove(profesor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorExists(int id)
        {
            return _context.Profesores.Any(e => e.Id == id);
        }
    }
}
