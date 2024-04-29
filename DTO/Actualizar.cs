namespace ORM.DTO
{
    public class DTO_Actualizar
    {
     
            public string Username { get; set; }
            public string Password { get; set; }
            public required string NewUsername { get; set; } // Agregar la propiedad NewUsername
            public required string NewPassword { get; set; } // Agregar la propiedad NewPassword
        }
    }




