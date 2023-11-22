using Zimaltec.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseOutputCache();

app.UseHttpsRedirection();

app.AddAppEndpoints();

app.Run();
