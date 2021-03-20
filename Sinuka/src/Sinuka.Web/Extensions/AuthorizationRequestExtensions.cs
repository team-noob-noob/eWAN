using System;
using IdentityServer4.Models;

namespace Sinuka.Web.Extensions
{
    public static class AuthorizationRequestExtensions
    {
        /// <summary>
        /// Checks if the redirect URI is for a native client.
        /// </summary>
        public static bool IsNativeClient(this AuthorizationRequest context)
        {
            return !context.RedirectUri.StartsWith("https", StringComparison.Ordinal)
               && !context.RedirectUri.StartsWith("http", StringComparison.Ordinal);
        }
    }
}