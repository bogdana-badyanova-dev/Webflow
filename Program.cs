using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Webflow.Application.Helpers;
using Webflow.Application.Interfaces;
using Webflow.Application.Services.FilesService.Implementations;
using Webflow.Application.Services.FilesService.Interfaces;
using Webflow.Application.Services.StudentsService.Implementations;
using Webflow.Application.Services.StudentsService.Interfaces;
using Webflow.Infrastructure;
using Webflow.Infrastructure.Repositories.BaseRepository.Implementations;
using Webflow.Infrastructure.Repositories.BaseRepository.Interfaces;
using Webflow.Infrastructure.Repositories.FilesRepository.Implementations;
using Webflow.Infrastructure.Repositories.FilesRepository.Interfaces;
using Webflow.Infrastructure.Repositories.StudentsRepository.Implementations;
using Webflow.Infrastructure.Repositories.StudentsRepository.Interfaces;

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
            builder.Services.AddScoped<IBaseRepository<Domain.Files.File>, BaseRepository<Domain.Files.File>>();
            builder.Services.AddScoped<IStudentsService, StudentsService>();
            builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
            builder.Services.AddScoped<IFactory<ICourse>, CourseFactory>();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddCors();

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All);
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "WebFlow API", Version = "v1" });

                // Добавление XML-файла документации
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                option.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            app.UseCors(builder =>
            {
                builder.WithOrigins("https://sevsu-webflow.vercel.app", "http://localhost:4200", "http://localhost:14637")
                .AllowAnyHeader()
                .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE")
                .AllowCredentials();
            });

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
