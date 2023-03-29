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
            var datos = DB.usuarios;
            List<UsuariosEntity> datosAgregados = new List<UsuariosEntity>();
            foreach (usuarios item in datos)
            {
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
                usuarios insertar = (new usuarios
                {
                    usuario = nuevoUsuario.usuario,
                    nombre = nuevoUsuario.nombre,
                    apellidoP = nuevoUsuario.apellidoP,
                    apellidoM = nuevoUsuario.apellidoM,
                    pass = nuevoUsuario.pass
                });

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
                usuarios aUsuario = (new usuarios
                {
                    nombre = updateUsuarios.nombre,
                    apellidoP = updateUsuarios.apellidoP,
                    apellidoM = updateUsuarios.apellidoM,
                    pass = updateUsuarios.pass
                });
                usuarios oldUsuario = DB.usuarios.FirstOrDefault(i => i.usuario == updateUsuarios.usuario);
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

                usuarios eUsuario = DB.usuarios.FirstOrDefault(a => a.usuario == deleteUsuarios.usuario);
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