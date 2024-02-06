using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiciosPrueba2.Models;
using System.Web.Http.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiciosPrueba2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaProductoController : ControllerBase
    {
        public readonly PruebaContext _context;

        public VentaProductoController(PruebaContext context)
        {
            this._context = context;
        }

        // GET: api/<VentaProductoController>
        [HttpGet]
        [Route("getAll")]
        public IActionResult Get()
        {
            List<VentaProducto> lista = new List<VentaProducto>();

            try
            {
                lista = _context.Ventas
                .Join(
                    _context.Productos,
                    venta => venta.Idproductos,
                    producto => producto.Idproductos,
                    (venta, producto) => new VentaProducto
                    {
                        IdVenta = venta.Idventas,
                        NombreProducto = producto.Titulo,
                        CantidadVendida = venta.CantidadVendida,
                        Fecha = venta.Fecha,
                        TotalVenta = venta.CantidadVendida * producto.PrecioUnitario
                    })
                .ToList();
                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, data = lista });
            }
        }
    }
}
