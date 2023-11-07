using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using StudentsManager.DAL.Context;
using StudentsManager.DAL.Entities;

var builder = WebApplication.CreateBuilder(args);
var db_connection_str = builder.Configuration.GetConnectionString("sqlite");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StudentsDBContext>(opts =>
{
    // opts.UseSqlServer(db_connection_str);
    opts.UseSqlite(db_connection_str);
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StudentsDBContext>();
    await db.Database.EnsureDeletedAsync();
    await db.Database.EnsureCreatedAsync();

    db.Students.AddRange(Enumerable.Range(1, 20)
        .Select(id => new Student
        {
            LastName = $"Last-{id}",
            Name = $"Name-{id}",
            Patronymic = $"Patr-{id}"
        }));

    db.StudentsGroup.AddRange(Enumerable.Range(1, 5)
        .Select(id => new StudentsGroup
        {
            Name = $"GroupName-{id}"
        }));

    await db.SaveChangesAsync();
}

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
