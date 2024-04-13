using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using QLPreschool.Data;
using QLPreschool.Models;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<QlTMnContext>(options =>
{
    var connectionStr = builder.Configuration.GetConnectionString("SqlServer");
    options.UseSqlServer(connectionStr);
});

//Add Mail Service
var mailSetting = builder.Configuration.GetSection("MailSetting");

builder.Services.AddOptions();
builder.Services.Configure<MailSetting>(mailSetting);
builder.Services.AddTransient<IEmailSender, MailSenderService>();

builder.Services.Configure<RouteOptions>(options => {
    options.AppendTrailingSlash = false;        // Thêm dấu / vào cuối URL
    options.LowercaseUrls = true;               // url chữ thường
    options.LowercaseQueryStrings = false;      // không bắt query trong url phải in thường
});

//Add Identity Service
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<QlTMnContext>().AddDefaultTokenProviders();
// Truy cập IdentityOptions
builder.Services.Configure<IdentityOptions>(options => {
    // Thiết lập về Password
    options.Password.RequireDigit = false; // Không bắt phải có số
    options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
    options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
    options.Password.RequireUppercase = false; // Không bắt buộc chữ in
    options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
    options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

    // Cấu hình Lockout - khóa user
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
    options.Lockout.MaxFailedAccessAttempts = 3; // Thất bại 5 lầ thì khóa
    options.Lockout.AllowedForNewUsers = true;

    // Cấu hình về User.
    options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;  // Email là duy nhất

    // Cấu hình đăng nhập.
    options.SignIn.RequireConfirmedEmail = false;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
    options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại
    options.SignIn.RequireConfirmedAccount = false;  //yêu cầu xác thực email rồi mới cho đăng nhập

});
//Cấu hình Authorization
builder.Services.ConfigureApplicationCookie(options => {
    options.Events = new CookieAuthenticationEvents
    {
        OnRedirectToLogin = context =>
        {
            if (context.Request.Path.StartsWithSegments("/GiaoVien"))
            {
                context.Response.Redirect("/Authentication/GVAuth");
            }
            else if (context.Request.Path.StartsWithSegments("/PhuHuynh") )
            {
                context.Response.Redirect("/Authentication/PHAuth");
            }
            else
            {
                context.Response.Redirect(context.RedirectUri);
            }
            return Task.CompletedTask;
        }
    };
    //options.LoginPath = $"/Authentication/GVAuth";
    options.LogoutPath = $"/Authentication/GVAuth/LogoutGV";
    options.AccessDeniedPath = $"/Authentication/GVAuth/AccessDenied";
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
