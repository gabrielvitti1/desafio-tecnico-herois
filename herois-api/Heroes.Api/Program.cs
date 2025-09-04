
using Heroes.Application.Services;
using Heroes.Application.Validators;
using Heroes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using Heroes.Infrastructure.Interfaces;
using Heroes.Infrastructure.Repositories;
using Heroes.Application.Interfaces;

namespace Heroes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Conectando com o banco de dados MySQL
            builder.Services.AddDbContext<HeroesContext>(options => 
                options.UseMySQL("server=localhost;database=hero;user=root;password=admin"));

            //Adicionando validações com fluent validation 
            builder.Services.AddValidatorsFromAssemblyContaining<CreateHeroiRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<PatchHeroiRequestValidator>();
            builder.Services.AddFluentValidationAutoValidation();

            //Injetando as dependências
            builder.Services.AddScoped<IHeroesRepository, HeroesRepository>();
            builder.Services.AddScoped<IHeroesService, HeroesService>();

            builder.Services.AddScoped<ISuperpoderesRepository, SuperpoderesRepository>();
            builder.Services.AddScoped<ISuperpoderesService, SuperpoderesService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200") 
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAngularApp");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
