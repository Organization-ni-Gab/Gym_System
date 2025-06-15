using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<GymSystemDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("GymSystemConnection")));

builder.Services.AddScoped<ICoachRepository, CoachRepository>();
builder.Services.AddScoped<ICoachService, CoachService>();

builder.Services.AddScoped<ISignupRepository, SignupRepository>();
builder.Services.AddScoped<ISignupService, SignupService>();

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
