using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCBaseline.Services
{
    public class ProtectedCookies : IProtectedCookies
    {
        private readonly IDataProtector _protector;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProtectedCookies(IDataProtectionProvider provider, IHttpContextAccessor httpContextAccessor)
        {
            _protector = provider.CreateProtector("CookieProtector");
            _httpContextAccessor = httpContextAccessor;
        }

        public string Get(string key)
        {
            return _protector.Unprotect(_httpContextAccessor.HttpContext.Request.Cookies[key]??string.Empty);
        }

        public void Set(string key, string value)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, _protector.Protect(value), new CookieOptions { Expires = DateTime.Now.AddMinutes(60), IsEssential = true });
        }

    }
}
