using Acotma_API.Models_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.EntityModels;

namespace WebApplication2.Service
{
    public class RegistroVehicularService
    {

        readonly ACOTMADBEntities DB = new ACOTMADBEntities();
        //todos los registros
        public List<RegistroVehicularEntity> GetAsignacionVehicularEntities()
        {
            var datos = DB.Registro_Vehicular;
            List<RegistroVehicularEntity> datosAgregados = new List<RegistroVehicularEntity>();
            foreach (Registro_Vehicular item in datos)
            {
                datosAgregados.Add(new RegistroVehicularEntity
                {
                    Id_RegistroVeh = item.Id_RegistroVeh,
                    Fecha = (DateTime)item.Fecha,
                    Nombre_solicitante =item.Nombre_solicitante,
                    Marca_vehiculo = item.Marca_vehiculo,
                    Submarca = item.Submarca,
                    Placa = item.Placa,
                    Tiempo = item.Tiempo,
                    Area_solicitante = item.Area_solicitante,
                    Actividades_a_realizar = item.Actividades_a_realizar,
                    Registro_de_kilometraje =item.Registro_de_kilometraje,
                });

            }
            return datosAgregados;
        }


        //agregar
        public bool agregarAsignacionVehicular(RegistroVehicularEntity nuevoRegistro)
        {
            bool respuesta = false;
            try
            {
                Registro_Vehicular insertar = (new Registro_Vehicular
                {
                    Id_RegistroVeh = nuevoRegistro.Id_RegistroVeh,
                    Fecha = nuevoRegistro.Fecha,
                    Nombre_solicitante = nuevoRegistro.Nombre_solicitante,
                    Marca_vehiculo = nuevoRegistro.Marca_vehiculo,
                    Submarca = nuevoRegistro.Submarca,
                    Placa = nuevoRegistro.Placa,
                    Tiempo = nuevoRegistro.Tiempo,
                    Area_solicitante = nuevoRegistro.Area_solicitante,
                    Actividades_a_realizar = nuevoRegistro.Actividades_a_realizar,
                    Registro_de_kilometraje = nuevoRegistro.Registro_de_kilometraje

                });

                DB.Registro_Vehicular.Add(insertar);
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