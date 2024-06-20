using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SonMama_Burger.DAL;
using SonMama_Burger.Models.Entitites;
using SonMama_Burger.VM;
using System;

namespace SonMama_Burger
{
	public class Program
	{
		public static void Main(string[] args)
		{


			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            

            builder.Services.AddRazorPages();

			builder.Services.AddDbContext<BurgerDBContext>(options =>
				options.UseSqlServer(connectionString));

            

    //        builder.Services.AddIdentity<AppUser, AppRole>()
    //.AddEntityFrameworkStores<BurgerDBContext>()
    //.AddDefaultTokenProviders();


            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BurgerDBContext>().AddRoles<AppRole>();

            //builder.Services.AddIdentity<AppUser, IdentityRole>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<BurgerDBContext>();
            builder.Services.AddControllersWithViews();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/User/Login";

                options.LogoutPath = "/User/Logout";

                options.LoginPath = "/User/Login";

            });

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;

                options.Password.RequireUppercase = true;

                options.Password.RequireDigit = true;

                options.Password.RequireLowercase = true;

                options.Password.RequireNonAlphanumeric = true;

                options.User.RequireUniqueEmail = true;

            });
            builder.Services.AddControllersWithViews();

            // SiparisOlusturVM kaydýný ekleyin
            builder.Services.AddTransient<SiparisOlusturVM>();

            var app = builder.Build();

            //Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //	app.UseMigrationsEndPoint();
            //}
            //else
            //{
            //	app.UseExceptionHandler("/Home/Error");
            //}

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

			//DataSeeder.Seed(app);

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
				  name: "areas",
				  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);
			});

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.MapRazorPages();

			app.Run();


		}
	}
}



