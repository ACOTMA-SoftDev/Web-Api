using Acotma_API.Models_DB; // Se importa el espacio de nombres Acotma_API.Models_DB que contiene los modelos de la base de datos.
using Acotma_API.Models_DB.EntityModels; // Se importa el espacio de nombres Acotma_API.Models_DB.EntityModels que contiene los modelos de entidades de la base de datos.
using System; // Se importa el espacio de nombres System que contiene tipos y clases fundamentales de .NET.
using System.Collections.Generic; // Se importa el espacio de nombres System.Collections.Generic que contiene clases para trabajar con colecciones de datos.
using System.Linq; // Se importa el espacio de nombres System.Linq que contiene clases para consultas y manipulación de datos en colecciones.
using System.Web; // Se importa el espacio de nombres System.Web que contiene clases para trabajar con aplicaciones web.

namespace Acotma_API.ServiciosModels // Se define un nuevo espacio de nombres Acotma_API.ServiciosModels para la clase RegistroUsuariosService.
{
    public class RegistroUsuariosService // Se define una clase pública llamada RegistroUsuariosService.
    {
        readonly ACOTMADBEntities DB = new ACOTMADBEntities(); // Se crea una instancia de ACOTMADBEntities para interactuar con la base de datos.

        public bool RegisterAccount(UsuariosEntity oUser) // Se define un método público llamado RegisterAccount que toma un objeto UsuariosEntity como parámetro para registrar una cuenta de usuario.
        {
            bool response = false; // Se inicializa una variable booleana llamada response con el valor false.

            try // Se inicia un bloque try para manejar excepciones.
            {
                usuarios addoUser = (new usuarios // Se crea una nueva instancia de la entidad usuarios y se asigna a la variable addoUser, utilizando el objeto UsuariosEntity oUser para establecer los valores de las propiedades.
                {
                    usuario = oUser.usuario,
                    nombre = oUser.nombre,
                    apellidoP = oUser.apellidoP,
                    apellidoM = oUser.apellidoM,
                    pass = oUser.pass,
                });

                DB.usuarios.Add(addoUser); // Se agrega la entidad addoUser a la colección de usuarios en la base de datos.
                DB.SaveChanges(); // Se guardan los cambios en la base de datos.
                response = true; // Se establece la variable response en true para indicar que el registro de la cuenta ha sido exitoso.
            }
            catch (Exception e) // Se captura cualquier excepción que ocurra durante la ejecución del código dentro del bloque try.
            {
                e.Message.ToString(); // Se obtiene el mensaje de la excepción y se convierte a una cadena de caracteres, pero no se hace nada con ella.
            }

            return response; // Se devuelve el valor de la variable response, que indica si el registro de la cuenta fue exitoso o no.
        }
    }
}
