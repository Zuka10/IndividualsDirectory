using System.Globalization;

namespace IndividualsDirectory.Api.Middlewares;

public class LocalizationMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var supportedCultures = new[] { "en-US", "ka-GE" };

        var acceptLanguageHeader = context.Request.Headers.AcceptLanguage.ToString();

        string selectedCulture = "en-US";

        if (!string.IsNullOrEmpty(acceptLanguageHeader))
        {
            var languages = acceptLanguageHeader.Split(',')
                .Select(lang => lang.Trim().Split(';')[0])
                .ToList();

            foreach (var lang in languages)
            {
                if (supportedCultures.Contains(lang))
                {
                    selectedCulture = lang;
                    break;
                }

                var matchingCulture = supportedCultures.FirstOrDefault(c => c.StartsWith(lang + "-"));
                if (matchingCulture != null)
                {
                    selectedCulture = matchingCulture;
                    break;
                }
            }
        }

        try
        {
            var culture = new CultureInfo(selectedCulture);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
        catch (CultureNotFoundException)
        {
            var defaultCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = defaultCulture;
            Thread.CurrentThread.CurrentUICulture = defaultCulture;
        }

        await _next(context);
    }
}