namespace Productos.DTO
{
    public class DTO_Producto  //Esta clase sera llamada en el metodo para agregar producto
    {
        public required string Id { get; set; }
        public required string nombre { get; set; }
        public required string descripcion { get; set; }
        public required decimal precio { get; set; }

    }
}
