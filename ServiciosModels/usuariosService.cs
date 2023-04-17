using Acotma_API.Models_DB;
using Acotma_API.Models_DB.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.EntityModels;

namespace WebApplication2.Service
{
    public class usuariosService
    {
        readonly ACOTMADBEntities DB = new ACOTMADBEntities();

        public List<UsuariosEntity> GetUsuariosEntities()
        {
            // Obtener los datos de la tabla "usuarios" de la base de datos
            var datos = DB.usuarios;
            List<UsuariosEntity> datosAgregados = new List<UsuariosEntity>();
            foreach (usuarios item in datos)
            {
                // Agregar los datos de la tabla "usuarios" a una lista de entidades "UsuariosEntity"
                datosAgregados.Add(new UsuariosEntity
                {
                    usuario = item.usuario,
                    nombre = item.nombre,
                    apellidoP = item.apellidoP,
                    apellidoM = item.apellidoM,
                    pass = item.pass
                });

            }
            return datosAgregados;
        }

        public bool agregarUsuario(UsuariosEntity nuevoUsuario)
        {
            bool respuesta = false;
            try
            {
                // Crear una nueva entidad "usuarios" con los datos del nuevo usuario a agregar
                usuarios insertar = (new usuarios
                {
                    usuario = nuevoUsuario.usuario,
                    nombre = nuevoUsuario.nombre,
                    apellidoP = nuevoUsuario.apellidoP,
                    apellidoM = nuevoUsuario.apellidoM,
                    pass = nuevoUsuario.pass
                });

                // Agregar la nueva entidad a la tabla "usuarios" de la base de datos
                DB.usuarios.Add(insertar);
                DB.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return respuesta;
        }

        //EDITAR USUARIOS
        public bool actualizarUsuario(UsuariosEntity updateUsuarios)
        {
            bool respuesta = false;
            try
            {
                // Crear una nueva entidad "usuarios" con los datos del usuario a actualizar
                usuarios aUsuario = (new usuarios
                {
                    nombre = updateUsuarios.nombre,
                    apellidoP = updateUsuarios.apellidoP,
                    apellidoM = updateUsuarios.apellidoM,
                    pass = updateUsuarios.pass
                });

                // Obtener la entidad del usuario a actualizar de la base de datos
                usuarios oldUsuario = DB.usuarios.FirstOrDefault(i => i.usuario == updateUsuarios.usuario);

                // Actualizar los datos de la entidad en la base de datos
                oldUsuario.nombre = aUsuario.nombre;
                oldUsuario.apellidoP = aUsuario.apellidoP;
                oldUsuario.apellidoM = aUsuario.apellidoM;
                oldUsuario.pass = aUsuario.pass;

                DB.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return respuesta;
        }

        //Eliminar USUARIO
        public bool eliminarUsuario(UsuariosEntity deleteUsuarios)
        {
            bool respuesta = false;

            try
            {
                // Obtener la entidad del usuario a eliminar de la base de datos
                usuarios eUsuario = DB.usuarios.FirstOrDefault(a => a.usuario == deleteUsuarios.usuario);

                // Eliminar la entidad de la tabla "usuarios" de la base de datos
                DB.usuarios.Remove(eUsuario);

                DB.SaveChanges();
                respuesta = true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

            return respuesta;

        }
    }
}
