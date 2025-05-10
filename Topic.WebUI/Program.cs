using Microsoft.Extensions.Options;
using NuGet.Configuration;
using Topic.WebUI.Areas.Admin.Controllers;
//using Topic.WebUI.Service;
//using Topic.WebUI.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection(nameof(ApiSettings)));
//builder.Services.AddHttpClient<IBlogService, BlogService>((sp, client) =>
//{
//    var settings = sp.GetRequiredService<IOptions<ApiSettings>>().Value;

//    client.BaseAddress = new Uri(settings.BaseUrl);
//});
//builder.Services.AddHttpClient<BlogController>(client =>
//{
//    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]);
//});
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
