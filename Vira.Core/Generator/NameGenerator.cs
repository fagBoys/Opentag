using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Berlance.Core.Generator
{
    public class NameGenerator
    {
        private static Random random = new Random();

        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        public static string RandomString(int length)
        {
            //const string chars = "0123456789AbghtT";
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        #region Cookie

        public static void Add(HttpContext context, string token, string value)
        {
            context.Response.Cookies.Append(token, value, getCookieOptions(context));
        }
        public static string GetValue(HttpContext context, string token)
        {
            string cookieValue;
            if (!context.Request.Cookies.TryGetValue(token, out cookieValue))
            {
                return null;
            }
            return cookieValue;
        }

        public static Guid GetBrowserId(HttpContext context)
        {
            string browserId = GetValue(context, "BowserId");
            if (browserId == null)
            {
                string value = Guid.NewGuid().ToString();
                Add(context, "BowserId", value);
                browserId = value;
            }
            Guid guidBowser;
            Guid.TryParse(browserId, out guidBowser);
            return guidBowser;
        }
        private static CookieOptions getCookieOptions(HttpContext context)
        {
            return new CookieOptions
            {
                HttpOnly = true,
                Path = context.Request.PathBase.HasValue ? context.Request.PathBase.ToString() : "/",
                Secure = context.Request.IsHttps,
                Expires = DateTime.Now.AddDays(100),
            };
        }



        #endregion

    }
}
