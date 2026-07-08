namespace EmpresaModularAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Identificacion { get; set; } = string.Empty; // Cédula o RUC
        public string Nombre { get; set; } = string.Empty;
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
    }
}