using Microsoft.EntityFrameworkCore;
using Hospital.Repositories;
using Microsoft.AspNetCore.Identity;
using hospitals.Utilities;
using Hospital.Repositories.Interfaces;
using Hospital.Repositories.Implementation;
using Microsoft.AspNetCore.Identity.UI.Services;
using Hospital.Models;
using Hospital.Services;

var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Tokens.ProviderMap[TokenOptions.DefaultEmailProvider] =
                    new TokenProviderDescriptor(
                        typeof(IUserTwoFactorTokenProvider<IdentityUser>));
            })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

builder.Services.AddScoped<IDbInitializer,DbInitializer>();
            builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
            builder.Services.AddScoped<IEmailSender, EmailSender>();
            builder.Services.AddTransient<IHospitalInfo, HospitalInfoService>();
            builder.Services.AddTransient<IRoomService, RoomService>();
            builder.Services.AddTransient<IContactService, ContactService>();
            builder.Services.AddTransient<IApplicationUserService, ApplicationUserService>();
builder.Services.AddTransient<IDoctorService,DoctorService>();
            builder.Services.AddHttpClient();
            builder.Services.AddRazorPages();
            

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
            DataSedding();
            app.UseRouting();

            app.UseAuthorization();
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{Area=admin}/{controller=Hospitals}/{action=Index}/{id?}");

            app.Run();
            void DataSedding()
            {
                using (var scope = app.Services.CreateScope())
                {
                    var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>(); 
                    dbInitializer.Initialize();
                }
            }
  