
using MusicCRUD.DataAccess;
using MusicCRUD.Repository.Services;
using MusicCRUD.Server.Configurations;
using MusicCRUD.Service.Services;

namespace MusicCRUD.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.ConfigureDatabase();

            builder.Services.AddScoped<IMusicService, MusicService>();
            builder.Services.AddScoped<IMusicRepository, MusicRepository>();

            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();

            //builder.Services.AddScoped<IMusicRepository, MusicRepositoryFile>();
            //builder.Services.AddSingleton<MainContext>();


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
