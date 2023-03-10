using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContextFactory<TestCasesManagerDbContext>(
    opt => opt.UseSqlServer(
        builder.Configuration.GetConnectionString("TestCasesManagerDb")));
builder.Services.AddScoped<StateContainer>();

var app = builder.Build();

//ensure that site always get the latest migration of db
await EnsureDataBaseIsMigrated(app.Services);

async Task EnsureDataBaseIsMigrated(IServiceProvider services)
{
    using var scope = services.CreateScope();
    using var ctx = scope.ServiceProvider.GetService<TestCasesManagerDbContext>();

    if (ctx is not null)
    {
        await ctx.Database.MigrateAsync();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
