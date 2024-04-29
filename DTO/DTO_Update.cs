namespace Productos.DTO
{
    public class DTO_Update
    {
        public int Id { get; set; }
        public required int New_Id { get; set; }
        public required string New_name{ get; set; }
        public required string New_descripcion { get; set; }
        public required decimal New_precio { get; set; }

    }
}
