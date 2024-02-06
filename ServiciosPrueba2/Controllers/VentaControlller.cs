using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiciosPrueba2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiciosPrueba2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaControlller : ControllerBase
    {

        public readonly PruebaContext _context;

        public VentaControlller(PruebaContext context)
        {
            this._context = context;
        }

        // GET: api/<VentaControlller>
        [HttpGet]
        [Route("getAll")]
        public IActionResult Get()
        {
            List<Venta> lista = new List<Venta>();

            try
            {
                lista = _context.Ventas.ToList();
                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, data = lista });
            }
        }
    }
}
