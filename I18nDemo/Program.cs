using I18nDemo.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(options => { options.ResourcesPath = "Resources"; });
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.SetDefaultCulture("en-us")
        .AddSupportedCultures(["en-us", "zh-hans-cn"])
        .AddSupportedUICultures(["en-us", "zh-hans-cn"]);
});
builder.Services.AddMvc()
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
            factory.Create(typeof(ValidationLocalization));
    });

var app = builder.Build();

app.MapGet("/",
    ([FromServices] IStringLocalizer<FooLocalization> fooLocalizer)
        => fooLocalizer["HelloWorld"].Value);

app.MapControllers();
app.UseRequestLocalization();

app.Run();