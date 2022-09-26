using Gisfpp_projects.Project.Data;
using Gisfpp_projects.Project.Repositories;
using Gisfpp_projects.Project.Services;

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
builder.Services.AddSqlite<ProjectDbContext>(builder.Configuration.GetConnectionString("ProjectDBTest")!);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
