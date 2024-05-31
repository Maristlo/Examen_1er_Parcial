using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen_1er_Parcial.Models;
using Sakura.AspNetCore;

namespace Examen_1er_Parcial.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly AgendaContext _context;

        public EmpleadosController(AgendaContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index(string searchString, Int32? page)
        {
            ViewData["CurrentFilter"] = searchString;

            var empleados = from e in _context.Empleados select e;

            if (!string.IsNullOrEmpty(searchString))
            {
                empleados = empleados.Where(e => e.Nombres.Contains(searchString) || e.Apellidos.Contains(searchString));
            }
            
            int pageSize = 5;//Para elegir cuantos registros quieres ver
            int pageNumber = (page ?? 1);

            ViewData["currentPage"] = pageNumber;

            var totalEmpleados = await empleados.CountAsync();
            ViewData["totalPages"] = (int)Math.Ceiling(totalEmpleados / (double)pageSize);

            var paginatedEmpleados = await empleados.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return View(paginatedEmpleados);
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cedula,Nombres,Apellidos,FechaNacimiento,Departamento,Municipio,Dirección,Teléfono,Celular,Correo,FechaIngreso,Profesión,Puesto,Salario")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cedula,Nombres,Apellidos,FechaNacimiento,Departamento,Municipio,Dirección,Teléfono,Celular,Correo,FechaIngreso,Profesión,Puesto,Salario")] Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Id))
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
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}
