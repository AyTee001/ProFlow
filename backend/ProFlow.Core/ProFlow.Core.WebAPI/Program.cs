using ProFlow.Core.BLL.Interfaces;
using ProFlow.Core.BLL.MappingProfiles;
using ProFlow.Core.BLL.Services;
using ProFlow.Core.WebAPI.Extensions;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace ProFlow.Core.WebAPI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add builder.Services to the container.
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<ICardService, CardService>();

            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddAutoMapper(typeof(CardProfile));

            builder.Services.AddProFlowMongoDbContext(builder.Configuration);
            builder.Services.AddProFlowSqlContext(builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseProFlowSqlContext();

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