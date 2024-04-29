using Microsoft.AspNetCore.Http; //Http contiene tipos y clases relacionadas con el manejo de solicitudes y respuestas HTTP 
using Microsoft.AspNetCore.Mvc; //Mvc, Proporciona tipos y clases relacionados con desarrollo web usando el modelo vista controlador, lo que nos permitira mas adelante definir controladores
using ORM.Context; //Importamos tambien las clases Context,DTO y Model de nuestro microservicio
using ORM.DTO;
using ORM.Model;

namespace ORM.Controllers //Definimos un nuevo espacio de nombre "Controllers"
{
    [Route("api/[controller]")]  //Metodo principal que organizará los controladores y esperará recibir datos tipo json o xml
    [ApiController] 
    public class Eliminar_Usuario : ControllerBase //Creamos una clase publica llamada cambios la cual hereda los atributos de la clase base "ControllerBase"
    {
        [HttpPost] //Dentro de ella declaramos un Metodo Post 
        public JsonResult baja(DTO_Usuarios quien) { //Y un nuevo objeto que recibe datos tipo json, llamado baja y recibe un tipo de dato DTO_Usuarios (Estructura)
            bool ret = false;// Inizializamos una variable booleana llamada ret como false

            using (MyDataContext ctx = new MyDataContext()) { // Creamos otro bloque de codigo el cual contendra los atributos de una clase heredada de MyDataContxt
                Users borrar = ctx.users.Where(r => r.Username == quien.Username).FirstOrDefault(); // Esta linea de código filtra los nombres de usuario de la base de datos y cuando encuentra uno repetido lo guarda en la variable borrar
                
                if(borrar != null)
                {
                    borrar.Password = quien.Password;
                }
                ctx.Entry<Users>(borrar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                ctx.Entry<Users>(borrar).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                ctx.SaveChanges();
                ret = true;
            }
            return new JsonResult(ret);
        }
    }
}
