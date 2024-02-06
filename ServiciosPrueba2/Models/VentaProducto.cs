namespace ServiciosPrueba2.Models
{
    public class VentaProducto
    {
        public int IdVenta { get; set; }
        public string NombreProducto { get; set; }
        public int? CantidadVendida { get; set; }
        public DateTime Fecha { get; set; }
        public decimal? TotalVenta { get; set; }

    }
}
