using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Productos.Context;
using Productos.DTO;
using Productos.Model;
using System;

namespace Productos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Modificar : ControllerBase
    {
        [HttpPost]
        public JsonResult ModificarUsuario(DTO_Update Id)
        {

            try
            {
                using (Data_Context ctx = new Data_Context())
                {
                    // Buscar el usuario en la base de datos
                    var product = ctx.product.FirstOrDefault(u => u.Id == Id.Id);

                    // Verificar si el usuario existe
                    if (product == null)
                    {
                        return new JsonResult("Producto no encontrado") { StatusCode = 404 };
                    }

                    // Eliminar la entidad existente
                    ctx.product.Remove(product);

                    // Crear una nueva entidad con los cambios deseados
                    var nuevo_producto = new Product
                    {
                        Id = Id.New_Id,
                        nombre = Id.New_name,
                        precio = Id.New_precio,
                        descripcion = Id.New_descripcion
                    };

                    // Agregar la nueva entidad a la base de datos
                    ctx.product.Add(nuevo_producto);

                    // Guardar los cambios en la base de datos
                    ctx.SaveChanges();

                    return new JsonResult("Item modificado correctamente") { StatusCode = 200 };
                }
            }
            catch (Exception ex)
            {
                // Manejar las excepciones y devolver un mensaje de error
                return new JsonResult($"Error al modificar el item: {ex.Message}") { StatusCode = 500 };
            }
        }
    }
}
