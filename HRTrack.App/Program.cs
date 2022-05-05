
using HRTrack.Common.Email;
using HRTrack.Data;
using HRTrack.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace HRTrack.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<HRTrackDbContext>(b =>
            {
                b.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerDB"));
            });

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<HRTrackDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromHours(2));

            builder.Services.AddTransient<IEmailSender, MailKitEmailSender>();
            builder.Services.Configure<MailKitEmailSenderOptions>(options =>
            {
                options.Host_Address = builder.Configuration["ExternalProviders:MailKit:SMTP:Address"];
                options.Host_Port = Convert.ToInt32(builder.Configuration["ExternalProviders:MailKit:SMTP:Port"]);
                options.Host_Username = builder.Configuration["ExternalProviders:MailKit:SMTP:Account"];
                options.Host_Password = builder.Configuration["ExternalProviders:MailKit:SMTP:Password"];
                options.Sender_EMail = builder.Configuration["ExternalProviders:MailKit:SMTP:SenderEmail"];
                options.Sender_Name = builder.Configuration["ExternalProviders:MailKit:SMTP:SenderName"];
            });

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;
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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

