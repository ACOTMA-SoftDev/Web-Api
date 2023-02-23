using Acotma_API.Models_DB.EntityModels;
using Acotma_API.serviciosModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acotma_API.Controllers
{
    public class asignacionController : ApiController
    {
        asignacionServicio service = new asignacionServicio();        
        [HttpPost]
        public bool agregarServicio(List<asignacionEntity> oService)
        {
            bool response = false;
            try                
            {
                for (int i = 0; i < oService.Count; i++)
                {
                    service.addAsignacion(oService[i]);
                }
                response = true;
            }catch(Exception e)
            {
                string ex = e.Message;
                Console.WriteLine(ex);
            }
            return response;            
        }
    }
}
