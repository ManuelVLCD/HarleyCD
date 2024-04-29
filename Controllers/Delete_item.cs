using Microsoft.AspNetCore.Http; //Http contiene tipos y clases relacionadas con el manejo de solicitudes y respuestas HTTP 
using Microsoft.AspNetCore.Mvc; //Mvc, Proporciona tipos y clases relacionados con desarrollo web usando el modelo vista controlador, lo que nos permitira mas adelante definir controladores
using Productos.Context; //Importamos tambien las clases Context,DTO y Model de nuestro microservicio
using Productos.DTO;
using Productos.Model;

namespace Productos.Controllers //Definimos un nuevo espacio de nombre "Controllers"
{
    [Route("api/[controller]")]  //Metodo principal que organizará los controladores y esperará recibir datos tipo json o xml
    [ApiController]
    public class Eliminar : ControllerBase //Creamos una clase publica llamada cambios la cual hereda los atributos de la clase base "ControllerBase"
    {
        [HttpPost] //Dentro de ella declaramos un Metodo Post 
        public JsonResult baja(DTO_Borrar_Producto cual)
        { //Y un nuevo objeto que recibe datos tipo json, llamado baja y recibe un tipo de dato DTO_Usuarios (Estructura)
            bool ret = false;// Inizializamos una variable booleana llamada ret como false

            using (Data_Context ctx = new Data_Context ())
            { // Creamos otro bloque de codigo el cual contendra los atributos de una clase heredada de MyDataContxt
                Product borrar = ctx.product.Where(r => r.Id == cual.Id).FirstOrDefault(); // Esta linea de código filtra los nombres de usuario de la base de datos y cuando encuentra uno repetido lo guarda en la variable borrar

                if (borrar != null)
                {
                    borrar.Id = cual.Id;
                }
                ctx.Entry<Product>(borrar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                ctx.Entry<Product>(borrar).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                ctx.SaveChanges();
                ret = true;
            }
            return new JsonResult(ret);
        }
    }
}
