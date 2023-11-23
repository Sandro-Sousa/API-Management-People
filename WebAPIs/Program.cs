using ManagmentPeople.Infra;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

//application
builder.Services.AddScoped<ILegalPersonService, LegalPersonService>();
builder.Services.AddScoped<INaturalPersonService, NaturalPersonService>();
builder.Services.AddScoped<IPeopleService, PeopleService>();

//repository
builder.Services.AddScoped<ILegalPersonRepository, LegalPersonRepository>();
builder.Services.AddScoped<INaturalPersonRepository, NaturalPersonRepository>();
builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
               builder =>
               {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "management.api v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
