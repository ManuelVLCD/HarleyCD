using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Productos.Context;
using Productos.DTO;
using Productos.Model;

namespace Productos.Controllers
{
    [Route("api/[controller]")]  //Metodos Principales para Json y XML
    [ApiController]
    public class Añadir : ControllerBase //Clase con atributos de controlador
    {

        [HttpPost]
        public JsonResult Nuevo(DTO_Producto pro)
        {     //Funciona como una funcion que recibe un objeto de tipo producto

            using (Data_Context dbc = new Data_Context())
            {
                try
                {
                    Product nuevo = new Product //Nuevo instancia del objeto Product
                    {

                        nombre = pro.nombre,
                        descripcion = pro.descripcion,
                        precio = pro.precio
                    };
                    dbc.product.Add(nuevo);
                    dbc.SaveChanges();
                }
                catch (Exception)
                {
                    return new JsonResult("Hubo un error!");

                }
            }
            return new JsonResult(pro);
        }
    }

        public class Buscar : ControllerBase //Clase con atributos de controlador
        {
        [Route("api/[controller]")]  //Metodos Principales para Json y XML

        [HttpGet]
        public JsonResult Leer(string pro)
        {
            List<DTO_LeerProducto> read = new List<DTO_LeerProducto>();
            DTO_LeerProducto filtro;
            using (Data_Context dbc = new Data_Context())
            {
                var select = dbc.product.Where(x => x.nombre == pro);
                foreach (var item in select)
                {
                    read.Add(new DTO_LeerProducto
                    {
                        Id = item.Id,
                        nombre = item.nombre,
                        precio = item.precio,
                        descripcion = item.descripcion
                    });

                }
            }

            return new JsonResult(read);
        }
    }


}