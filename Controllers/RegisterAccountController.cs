using Acotma_API.Models_DB.EntityModels;
using Acotma_API.ServiciosModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acotma_API.Controllers
{

    public class RegisterAccountController : ApiController
    {
        readonly RegistroUsuariosService service = new RegistroUsuariosService();

        [HttpPost]
        public bool AddAccountUser(UsuariosEntity oUser)
        {
            return service.RegisterAccount(oUser);
        }
    }
}
