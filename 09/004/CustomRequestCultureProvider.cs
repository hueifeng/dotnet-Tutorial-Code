using Microsoft.AspNetCore.Localization;

namespace _004
{
    public class CustomRequestCultureProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult?> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return Task.FromResult((ProviderCultureResult)null);
            }

            //var culture = httpContext.User.GetCulture();
            string culture = null;
            if (culture == null)
            {
                return Task.FromResult((ProviderCultureResult)null);
            }

            return Task.FromResult(new ProviderCultureResult(culture));

        }
    }
}
