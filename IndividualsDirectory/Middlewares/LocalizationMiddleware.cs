using System.Globalization;

namespace IndividualsDirectory.Api.Middlewares;

public class LocalizationMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var supportedCultures = new[] { "en-US", "fr-FR", "es-ES", "ka-GE" };

        var acceptLanguage = context.Request.Headers["Accept-Language"].ToString();
        if (string.IsNullOrEmpty(acceptLanguage))
        {
            acceptLanguage = "en-US";
        }

        string cultureName = acceptLanguage;
        if (!supportedCultures.Contains(cultureName))
        {
            var requestedLanguage = acceptLanguage.Split('-')[0];
            cultureName = supportedCultures.FirstOrDefault(c => c.StartsWith(requestedLanguage)) ?? "en-US";
        }

        var culture = new CultureInfo(acceptLanguage);
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;

        await _next(context);
    }
}