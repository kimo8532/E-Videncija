
using E_Videncija.DAL;
using E_Videncija.Repository.Automappers;
using E_Videncija.Repository.Common;
using E_Videncija.Service.Common;
using Microsoft.EntityFrameworkCore;

namespace E_Videncija.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<EVidencijaDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("E-Videncija")));
            builder.Services.AddScoped<IService, Service.Service>();
            builder.Services.AddScoped<IRepository, Repository.Repository>();
            builder.Services.AddScoped<IRepositoryMappingService, RepositoryMappingService>();
            var app = builder.Build();
            app.UseCors("AllowCors");
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
        }
    }
}
