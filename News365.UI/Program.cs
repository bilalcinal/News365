using System.Reflection;
using System.Text.Unicode;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.CookiePolicy;
using News365.Business.Autofac;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
ApplicationName = typeof(Program).Assembly.FullName,
ContentRootPath = Directory.GetCurrentDirectory(),
EnvironmentName = Environments.Staging,
WebRootPath = "wwwroot"
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(options =>
{
options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
options.AccessDeniedPath = new PathString("/cms/account/login/");
options.LoginPath = new PathString("/cms/account/login/");
options.LogoutPath = new PathString("/cms/account/logout/");
options.Cookie.Name = ".News365.net";
options.Cookie.SameSite = SameSiteMode.Lax;
options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
options.Cookie.IsEssential = true;
});

builder.Services.AddSession(options =>
{
options.IdleTimeout = TimeSpan.FromDays(1);
options.Cookie.IsEssential = true;
options.Cookie.HttpOnly = true;
options.Cookie.SameSite = SameSiteMode.Lax;
options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddWebEncoders(o => {
o.TextEncoderSettings = new System.Text.Encodings.Web.TextEncoderSettings(UnicodeRanges.All);
});
builder.Services.AddControllersWithViews().AddFluentValidation(options =>
{
options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
app.UseExceptionHandler("/Home/Error");
app.UseHsts();
// }
// else
// {
app.UseDeveloperExceptionPage();
// }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

var cookiePolicyOptions = new CookiePolicyOptions
{
MinimumSameSitePolicy = SameSiteMode.Lax,
HttpOnly = HttpOnlyPolicy.Always,
Secure = CookieSecurePolicy.Always
};
app.UseCookiePolicy(cookiePolicyOptions);
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
name: "areas",
pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();