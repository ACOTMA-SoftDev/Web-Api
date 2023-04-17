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
        private readonly string certificate = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Certificate", "certificate.p12");

        // Método para obtener la clave RSA de seguridad a partir del certificado
        private RsaSecurityKey GetCertificate()
        {
            try
            {
                // Crea una instancia de X509Certificate2 con la ruta del archivo del certificado y su contraseña
                var oCertificate = new X509Certificate2(certificate, "ACOTMA");

                // Obtiene la clave privada del certificado como instancia de RSACryptoServiceProvider
                var properties = (RSACryptoServiceProvider)oCertificate.PrivateKey;

                // Retorna la clave privada del certificado como una instancia de RsaSecurityKey
                return new RsaSecurityKey(properties);
            }
            catch (Exception)
            {
                // Si ocurre una excepción, la relanza para manejarla en un nivel superior
                throw;
            }
        }
        public string GeneratingToken(UsuariosEntity oUser, string[] roles)
        {
            // Crea un encabezado para el token con la clave de firma obtenida del certificado
            var sendCrentials = new JwtHeader(new SigningCredentials(GetCertificate(), SecurityAlgorithms.RsaSha256));

            // Crea una lista de reclamaciones de roles
            var getRoles = roles.Select(x => new Claim(ClaimTypes.Role, x));

            // Concatena las reclamaciones de roles con otras reclamaciones
            var claims = Enumerable.Concat(getRoles, new Claim[]
            {
        // Agrega una reclamación de identificador único (JTI) con un nuevo GUID como valor
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        
        // Agrega una reclamación de sujeto con el valor del nombre de usuario del usuario
        new Claim(JwtRegisteredClaimNames.Sub, oUser.usuario),
        
        // Agrega una reclamación de identificador de nombre con el valor del nombre de usuario del usuario
        new Claim(JwtRegisteredClaimNames.NameId, oUser.usuario)
            });

            // Crea una identidad de reclamaciones con las reclamaciones obtenidas
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);

            // Crea un principal de reclamaciones con la identidad de reclamaciones
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // Crea un objeto JwtPayload con la información del emisor, audiencia, reclamaciones, fecha de emisión,
            // fecha de no antes y fecha de expiración del token
            JwtPayload keyValues = new JwtPayload
            (
                issuer: "ACOTMA",
                audience: "Users",
                claims: claimsPrincipal.Claims,
                issuedAt: DateTime.Now,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMonths(2)
            );

            // Crea un objeto JwtSecurityToken con el encabezado y el payload del token
            var getToken = new JwtSecurityToken(sendCrentials, keyValues);

            // Crea una lista de UsuariosEntity vacía (¿para qué se usa?)
            List<UsuariosEntity> usuarios = new List<UsuariosEntity>();

            // Escribe el token en formato JWT y lo retorna como una cadena de texto
            return new JwtSecurityTokenHandler().WriteToken(getToken);
        }
    }
}