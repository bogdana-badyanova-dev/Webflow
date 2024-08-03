using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Webflow.Data;
using Webflow.Repositories.BaseRepository.Implementations;
using Webflow.Repositories.BaseRepository.Interfaces;
using Webflow.Repositories.FilesRepository.Implementations;
using Webflow.Repositories.FilesRepository.Interfaces;
using Webflow.Services.FilesService.Implementations;
using Webflow.Services.FilesService.Interfaces;

namespace Webflow
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<WebflowContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("WebflowContext") ?? throw new InvalidOperationException("Connection string 'WebflowContext' not found.")));

            builder.Services.AddScoped<IFilesService, FilesService>();
            builder.Services.AddScoped<IFilesRepository, FilesRepository>();
            builder.Services.AddScoped<IBaseRepository<Models.File>, BaseRepository<Models.File>>();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddCors();

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All);
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors(builder =>
            {
                builder.WithOrigins("https://sevsu-webflow.vercel.app", "http://localhost:4200", "http://localhost:14637")
                .AllowAnyHeader()
                .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE")
                .AllowCredentials();
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
