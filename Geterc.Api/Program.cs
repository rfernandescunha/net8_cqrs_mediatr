using Gertec.Api.Configuration;

namespace Gertec.Api
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            IConfiguration configuration;

            var builder = WebApplication.CreateBuilder(args);            

            configuration = builder.Configuration;

            builder.Services.AddOptions();

            builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(x => x.SerializerOptions.IncludeFields = true);

            builder.Services.AddDependencyInjectionConfig(configuration);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddCustomMediaR();

            builder.Services.AddSwaggerGenConfig();

            var app = builder.Build();

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
