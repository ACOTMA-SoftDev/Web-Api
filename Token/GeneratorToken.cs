using Acotma_API.Models_DB.EntityModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Acotma_API.Token
{
    public class GeneratorToken
    {
        //private readonly string certificate = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Certificate", "certificate.p12");
        
        /// <summary>
        /// Obtencion del Certificado
        /// </summary>
        /// <returns>
        /// Retorna las claves del certificado
        /// </returns>
        private RsaSecurityKey GetCertificate()
        {
            var certificate=server.MapPath("~/Certificado.p12");
            try
            {
                var oCertificate = new X509Certificate2(certificate, "ACOTMA");
                var properties = (RSACryptoServiceProvider)oCertificate.PrivateKey;
                return new RsaSecurityKey(properties);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string GeneratingToken(UsuariosEntity oUser, string[]roles)
        {
            var sendCrentials = new JwtHeader(new SigningCredentials(GetCertificate(), SecurityAlgorithms.RsaSha256));
            var getRoles = roles.Select(x => new Claim(ClaimTypes.Role, x));
            var claims = Enumerable.Concat(getRoles, new Claim[]
                {
                  new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                  new Claim(JwtRegisteredClaimNames.Sub,oUser.usuario),
                  new Claim(JwtRegisteredClaimNames.NameId,oUser.usuario)
                });
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            JwtPayload keyValues = new JwtPayload
                (
                issuer: "ACOTMA",
                audience: "Users",
                claims: claimsPrincipal.Claims,
                issuedAt: DateTime.Now,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMonths(2)
                );
            var getToken = new JwtSecurityToken(sendCrentials, keyValues);
            List<UsuariosEntity> usuarios = new List<UsuariosEntity>();
            return new JwtSecurityTokenHandler().WriteToken(getToken);            
        }
    }
}