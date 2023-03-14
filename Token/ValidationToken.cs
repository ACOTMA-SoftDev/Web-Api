
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
    public class ValidationToken:DelegatingHandler
    {
        private readonly string certificate = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Certificate", "certificate.p12");
        /// <summary>
        /// RECUPERACION DEL TOKEN POR LAS CABECERAS(HEADERS)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="token"></param>
        /// <returns>
        /// Retorna Verdadero o Falso para la validacion del token
        /// </returns>
        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            if (!request.Headers.TryGetValues("Authorization", out IEnumerable<string> authorizationHeaders) ||
                authorizationHeaders.Count() > 1)
            {
                return false;
            }
            var bearerToken = authorizationHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }
        /// <summary>
        /// Obtencion del Certificado
        /// </summary>
        /// <returns>
        /// Retorna las claves del certificado
        /// </returns>
        private RsaSecurityKey GetCertificate()
        {
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
        /// <summary>
        /// Genera y obtiene los parametros del token 
        /// </summary>
        /// <returns>
        /// Retorna el token validado
        /// </returns>
        private TokenValidationParameters GetValidationTokenParameters()
        {
            return new TokenValidationParameters
            {
                ValidAudience = "Users",
                ValidIssuer = "ACOTMA",
                IssuerSigningKey = GetCertificate()
            };
        }
        /// <summary>
        /// Validacion del token recibido
        /// </summary>
        /// <param name="token"></param>
        private void ValidateTokens(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationTokenParameters();
            IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out _);
            Thread.CurrentPrincipal = principal;
            HttpContext.Current.User = principal;
        }
        /// <summary>
        /// Autorizacion por cabeceras comprobacion y validacion
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// Retornando un status del http         
        /// </returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;
            var authHeader = request.Headers.Authorization;
            if (authHeader == null)
            {
                return base.SendAsync(request, cancellationToken);
            }
            if(!TryRetrieveToken(request,out string token))
            {
                return Task<HttpResponseMessage>.Factory.StartNew(()=>new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            try
            {
                ValidateTokens(token);
                return base.SendAsync(request, cancellationToken);
            }
            catch (Exception)
            {
                statusCode = HttpStatusCode.InternalServerError;
            }
            return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode));
        }
    }
}