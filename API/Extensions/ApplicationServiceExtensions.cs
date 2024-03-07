using Application.Activities;
using Application.Core;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public  static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services,IConfiguration config)
        {
            Services.AddEndpointsApiExplorer();
Services.AddSwaggerGen();
Services.AddDbContext<DataContext>(opt=>
{
opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
});

Services.AddCors(opt=>{
    opt.AddPolicy("CorsPolicy",policy=>{
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
    });

});

Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(List.Handler).Assembly));
Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
return Services;

        }
        
    }
}