using Gisfpp_projects.Project.Data;
using Gisfpp_projects.Project.Repositories;
using Gisfpp_projects.Project.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IProjectRepository, ProjectDBRepository>();
builder.Services.AddScoped(typeof(ProjectService));

//DB Config
var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));
var connectionStringDB = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
connectionStringDB = connectionStringDB ?? builder.Configuration.GetConnectionString("ProjectDB");

builder.Services.AddDbContext<ProjectDbContext>(
    dbContextOption => 
        dbContextOption.UseMySql(connectionStringDB, serverVersion)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                //.LogTo(Console.WriteLine, LogLevel.Information)
                //.EnableSensitiveDataLogging()
                //.EnableDetailedErrors()
);

builder.Services.AddCors( options => {
    options.AddDefaultPolicy(
        policy => {
            policy.WithOrigins("http://localhost:4200", "http://localhost:8080")
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler("/errors");
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors();
//app.UseAuthorization();
app.MapControllers();

app.Run();