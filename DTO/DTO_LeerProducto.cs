namespace Productos.DTO
{
    public class DTO_LeerProducto
    {
        public int Id { get; set; }

        public required string nombre { get; set; }
        public required string descripcion { get; set; }
        public decimal precio { get; set; }
    }
}
