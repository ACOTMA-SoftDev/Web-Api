
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;


namespace Acotma_API.Token
{
    public class ValidationToken : DelegatingHandler
    {
        private readonly string certificate = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Certificate", "certificate.p12");
        // Campo privado que almacena la ruta del archivo de certificado en formato P12

        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            // Inicializa el parámetro de salida token con null

            if (!request.Headers.TryGetValues("Authorization", out IEnumerable<string> authorizationHeaders) ||
                authorizationHeaders.Count() > 1)
            {
                return false;
            }
            // Verifica si el encabezado Authorization existe en la solicitud y si hay más de un valor en él

            var bearerToken = authorizationHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer") ? bearerToken.Substring(7) : bearerToken;
            // Obtiene el valor del token de autorización eliminando el prefijo "Bearer" si existe

            return true;
        }

        private RsaSecurityKey GetCertificate()
        {
            try
            {
                var oCertificate = new X509Certificate2(certificate, "ACOTMA");
                // Carga el certificado desde el archivo P12 y lo protege con una contraseña
                var properties = (RSACryptoServiceProvider)oCertificate.PrivateKey;
                // Obtiene la clave privada del certificado
                return new RsaSecurityKey(properties);
                // Devuelve una instancia de RsaSecurityKey con la clave privada del certificado como valor
            }
            catch (Exception)
            {
                throw;
            }
        }

        private TokenValidationParameters GetValidationTokenParameters()
        {
            return new TokenValidationParameters
            {
                ValidAudience = "Users",
                ValidIssuer = "ACOTMA",
                IssuerSigningKey = GetCertificate()
                // Crea una instancia de TokenValidationParameters con los valores de audiencia, emisor y clave de firma obtenidos
            };
        }

        private void ValidateTokens(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // Crea una instancia de JwtSecurityTokenHandler para validar el token

            var validationParameters = GetValidationTokenParameters();
            // Obtiene los parámetros de validación del token

            IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out _);
            // Valida el token con los parámetros de validación y obtiene el principal resultante

            Thread.CurrentPrincipal = principal;
            HttpContext.Current.User = principal;
            // Establece el principal en el hilo actual y en el contexto de la solicitud actual
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;
            var authHeader = request.Headers.Authorization;
            // Obtiene el encabezado Authorization de la solicitud

            if (authHeader == null)
            {
                return base.SendAsync(request, cancellationToken);
                // Si no hay encabezado Authorization, se pasa la solicitud al siguiente delegado en la cadena de manejo
            }

            if (!TryRetrieveToken(request, out string token))
            {
                return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(HttpStatusCode.Unauthorized));
                // Intenta obtener y validar el token de autorización de la solicitud. Si falla, devuelve una respuesta de error 401 (No autorizado)
            }
            try
            {
                // Intenta validar el token utilizando el método ValidateTokens
                ValidateTokens(token);
                // Si la validación es exitosa, envía la solicitud al siguiente delegado en la cadena y devuelve la respuesta
                return base.SendAsync(request, cancellationToken);
            }
            catch (Exception)
            {
                // Si ocurre una excepción durante la validación del token, establece el código de estado a InternalServerError
                statusCode = HttpStatusCode.InternalServerError;
            }
            // Devuelve una nueva tarea que crea una instancia de HttpResponseMessage con el código de estado establecido
            return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode));
        }
    }
}