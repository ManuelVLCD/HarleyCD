namespace Productos.Model
{
    public class Product
    {
        

        public int Id { get; set; }
        public string nombre { set; get; } = string.Empty;
        public string descripcion { set; get; } = string.Empty;
        public decimal precio { set; get;} = decimal.Zero;
        
        

    }
}
