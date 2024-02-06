using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiciosPrueba2.Models;
using System.ComponentModel;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiciosPrueba2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public readonly PruebaContext _context;

        public ProductoController(PruebaContext context)
        {
            this._context = context;
        }


        // GET: api/<ProductoController>
        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            List<Producto> lista = new List<Producto>();

            try
            {
                lista = _context.Productos.ToList();
                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = lista });
            }
        }

        // GET api/<ProductoController>/5
        [HttpGet]
        [Route("get/{idProducto}")]
        public IActionResult Get(int idProducto)
        {
            Producto producto; 
            try
            {
                producto = _context.Productos.Find(idProducto);

                if(producto == null)
                {
                    return NotFound();
                }
                return Ok(producto);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

    }
}
