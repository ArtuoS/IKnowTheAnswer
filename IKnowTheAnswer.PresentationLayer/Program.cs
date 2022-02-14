using AutoMapper;
using IKnowTheAnswer.Infrastructure.Repositories.DatabaseContext;
using IKnowTheAnswer.PresentationLayer.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IKnowTheAnswerDbContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("IKnowTheAnswer");
    opt.UseSqlServer(connectionString, opt =>
    {
        opt.MigrationsAssembly(assemblyName: typeof(IKnowTheAnswerDbContext).Assembly.FullName.Split(',')[0]);
    });
});

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Add services to the container.
builder.Services.AddControllersWithViews();

DependecyInjection.Inject(builder.Services);

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
