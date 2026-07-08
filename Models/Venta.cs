using System;

namespace EmpresaModularAPI.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

        // Relación con Cliente
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        // Relación con Producto
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
    }
}