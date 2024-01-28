using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RECUPO01_HernandezJorge.Data;
using RECUPO01_HernandezJorge.Models;

namespace RECUPO01_HernandezJorge.Controllers
{
    public class ProductoesController : Controller
    {
        private readonly HernandezContext _context;

        public ProductoesController(HernandezContext context)
        {
            _context = context;
        }

        // GET: Productoes
        public async Task<IActionResult> Index()
        {
              return _context.Productos != null ? 
                          View(await _context.Productos.OrderByDescending(a => a.Nombre).Take(15).ToListAsync()) :
                          Problem("Entity set 'HernandezContext.Productos'  is null.");
        }

        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.CodigoProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Ventas de cada producto
        public async Task<IActionResult> VentaProducto(int id)
        {
            ViewData["venta"] = id;
            //ViewData["NombreProducto"] = _context.Productos;
            var VentaContexto = _context.Venta
                .Include(_ => _.producto);
            //.Where(g => g.Id = id);
            return View(await VentaContexto.ToListAsync());

        }


        //GET CrearVentaProducto
        public IActionResult CrearVentaProducto()
        {
            ViewData["venta"] = new SelectList(_context.Venta, "Venta", "Venta");
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CrearVentaProducto([Bind("CodigoProducto,Nombre,Gama,Dimensiones,Proveedor,Descripcion,CantidadEnStock,PrecioVenta,PrecioProveedor")] Producto producto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(venta);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("VistaProductosPorGama", "Productos", new { id = producto.Gama });
        //    }
        //    ViewData["Gama"] = producto.Gama;
        //    return View(producto);
        //}




        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoProducto,Nombre,Gama,Dimensiones,Proveedor,Descripcion,CantidadEnStock,PrecioVenta,PrecioProveedor")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoProducto,Nombre,Gama,Dimensiones,Proveedor,Descripcion,CantidadEnStock,PrecioVenta,PrecioProveedor")] Producto producto)
        {
            if (id != producto.CodigoProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.CodigoProducto))
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
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.CodigoProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'HernandezContext.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
          return (_context.Productos?.Any(e => e.CodigoProducto == id)).GetValueOrDefault();
        }
    }
}
