using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ORM.Context;
using ORM.DTO;
using ORM.Model;
using System;

namespace ORM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Modificar : ControllerBase
    {
        [HttpPost]
        public JsonResult ModificarUsuario(DTO_Actualizar datos)
        {

            try
            {
                using (MyDataContext ctx = new MyDataContext())
                {
                    // Buscar el usuario en la base de datos
                    var usuario = ctx.users.FirstOrDefault(u => u.Username == datos.Username);

                    // Verificar si el usuario existe
                    if (usuario == null)
                    {
                        return new JsonResult("Usuario no encontrado") { StatusCode = 404 };
                    }

                    // Eliminar la entidad existente
                    ctx.users.Remove(usuario);

                    // Crear una nueva entidad con los cambios deseados
                    var nuevoUsuario = new Users
                    {
                        Username = datos.NewUsername,
                        Password = datos.Password
                    };

                    // Agregar la nueva entidad a la base de datos
                    ctx.users.Add(nuevoUsuario);

                    // Guardar los cambios en la base de datos
                    ctx.SaveChanges();

                    return new JsonResult("Usuario modificado correctamente") { StatusCode = 200 };
                }
            }
            catch (Exception ex)
            {
                // Manejar las excepciones y devolver un mensaje de error
                return new JsonResult($"Error al modificar usuario: {ex.Message}") { StatusCode = 500 };
            }
        }
    }
}
