var builder = WebApplication.CreateBuilder(args);

/* Install Services using the builder.Services methods
 */

//TODO: use the AddMvc method to enable MVC for this application
builder.Services.AddMvc();

//TODO: DIJ Part 1: Notify the app that the TextTranform class is available for DIJ
builder.Services.AddTransient<LuckySpin.Models.TextTransform>();

var app = builder.Build();


/* Middleware in the HTTP Request Pipeline
 */
app.UseStaticFiles();

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Spinner/Error");
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{luck}",
    defaults: new {
        controller = "Spinner",
        action = "Index",
        luck = 7
    });

app.Run();

