using Prj_CarPool.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Persistence;
using Identity;
using Identity.Models;
using Prj_CarPool.IServices.Services;
using Identity.Seed;
using Domain.Entities;
using Application.Contracts;
using System.Diagnostics;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authorization;
using Prj_CarPool.Handlers;

var builder = WebApplication.CreateBuilder(args);



//builder.Services.AddRazorPages();

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
       builder.Configuration.GetConnectionString("ConnectionString")));
 builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
    options.UseSqlServer(
       builder.Configuration.GetConnectionString("IdentityConnectionString")));

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
//.AddEntityFrameworkStores<ApplicationIdentityDbContext>();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
    options.Lockout.MaxFailedAccessAttempts = 2;
}).AddEntityFrameworkStores<ApplicationIdentityDbContext>().AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddAppServices(builder.Configuration);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/Login";
});

builder.Services.AddMvc().AddRazorPagesOptions(options =>
{
    // options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
    options.Conventions.AddPageRoute("/Identity/Account/Login", "");


});

builder.Services.AddRazorPages();

builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = false;
    options.Cookie.IsEssential = true;
});
builder.Services.AddAntiforgery(options =>
{
    options.FormFieldName = "MyAntiForgeryField";
    options.HeaderName = "MyAntiForgeryHeader";
    options.Cookie.Name = "MyAntiForgeryCookie";
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    
}).AddCookie()
 .AddMicrosoftAccount(microsoftOptions =>
   {
       microsoftOptions.ClientId = "5f5da1aa-71af-4f81-bf0e-793bd0449d2e";//builder.Configuration["Authentication:Microsoft:ClientId"];
       microsoftOptions.ClientSecret = "-o78Q~4parDr7XW9iT.gcqJ_oL6nk7vb2knUHa5b";//builder.Configuration["Authentication:Microsoft:ClientSecret"];
       microsoftOptions.Scope.Add("user.read");
       microsoftOptions.SaveTokens = true;
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
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

//app.MapGet("/vehicleMy", async (ApplicationDbContext appdb) => {

//    var starttime = DateTime.Now;
//    for (int i = 0; i < 1000000; i++)
//    {

//    }
//    //await appdb.SetIcons.ToListAsync();
//    var Endtime = DateTime.Now;
//    return Results.Json("startTime " + starttime.Millisecond + " || Endtime " + Endtime.Millisecond);
//});

//app.MapPost("/vehicleInsert", async (VehicleBrands Obj, ApplicationDbContext appdb) => {
//    //Obj.CreatedBy = "admin";
//    appdb.VehicleBrands.Add(Obj);
//    await appdb.SaveChangesAsync();

//    return Results.Created($"/save/{Obj.VehicleBrandId}", Obj);

//});


app.Run();
