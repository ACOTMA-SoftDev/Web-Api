using Acotma_API.Models_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.EntityModels;

namespace WebApplication2.Service
{
    public class permisosService
    {
        readonly ACOTMADBEntities DB = new ACOTMADBEntities();

        public List<permisosEntity> GetPermisoEntities()
        {
            var datos = DB.permisos;
            List<permisosEntity> datosAgregados = new List<permisosEntity>();
            foreach (permisos item in datos)
            {
                datosAgregados.Add(new permisosEntity
                {
                    permiso = item.permiso
                });

            }
            return datosAgregados;
        }


        public bool agregarPermiso(permisosEntity nuevoPermiso)
        {
            bool respuesta = false;
            try
            {
                permisos insertar = (new permisos
                {
                    permiso = nuevoPermiso.permiso
                });

                DB.permisos.Add(insertar);
                DB.SaveChanges();
                respuesta = true;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return respuesta;
        }

        public bool actualizarPermiso(permisosEntity updatePermiso)
        {
            bool respuesta = false;
            try
            {
                permisos aPermiso = (new permisos
                {
                    permiso = updatePermiso.permiso
                });
                permisos oldPermiso = DB.permisos.FirstOrDefault(a => a.permiso == updatePermiso.permiso);
                oldPermiso.permiso = aPermiso.permiso;
                DB.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return respuesta;
        }


        public bool eliminarPermiso(permisosEntity deletePermiso)
        {
            bool respuesta = false;

            try
            {

                permisos ePermiso = DB.permisos.FirstOrDefault(a => a.permiso == deletePermiso.permiso);
                DB.permisos.Remove(ePermiso);

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