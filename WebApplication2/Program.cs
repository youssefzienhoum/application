 using AutoMapper;
using BIL.Services;
using DAL.context;
using DAL.Entities;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IEmployeeRespository, EmployeeRespository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IRespository<>), typeof(MainRespository<>));
            builder.Services.AddScoped(typeof(IRespository<Department>), typeof(MainRespository<Department>));
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //builder.Services.AddScoped<CompanyDbContext>(provider =>
            //{
            //    var optionsBuilder = new DbContextOptionsBuilder<CompanyDbContext>();
            //    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            //    return new CompanyDbContext(optionsBuilder.Options);
            //});
            builder.Services.AddDbContext<CompanyDbContext>(options => 
                options.UseSqlServer("Server=MSI\\SQLEXPRESS;DataBase=CompanyG01;Trusted_Connection=true;TrustServerCertificate=true"));

            builder.Services.AddAutoMapper(typeof(BIL.AssemblyReference).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
