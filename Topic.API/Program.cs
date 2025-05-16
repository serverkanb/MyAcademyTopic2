using System.Reflection;
using Topic.BusinessLayer.Abstract;
using Topic.BusinessLayer.Concrete;
using Topic.DataAccessLayer.Abstract;
using Topic.DataAccessLayer.Concrete;
using Topic.DataAccessLayer.Context;
using Topic.DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());   


builder.Services.AddScoped<TopicContext>();

builder.Services.AddScoped<IBlogDal,EfBlogDal>();
builder.Services.AddScoped<IBlogService, BlogManager>();

builder.Services.AddScoped<ICategoryDal,EfCategoryDal>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();

builder.Services.AddScoped<IManuelDal,EfManuelDal>();
builder.Services.AddScoped<IManuelService,ManuelManager>();

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IFAQDal, EfFAQDal>();
builder.Services.AddScoped<IFAQService, FAQManager>();

builder.Services.AddScoped<ISubscriberDal, EfSubscriberDal>();
builder.Services.AddScoped<ISubscriberService, SubscriberManager>();


builder.Services.AddScoped(typeof(IGenericDal<>),typeof(GenericRepository<>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
