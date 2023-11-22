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

// Global exception handler, so that we do not need to add try/catch to every endpoint 
app.UseExceptionHandler(exceptionHandlerApp =>
    exceptionHandlerApp.Run(async context =>
        await Results.Problem()
            .ExecuteAsync(context)));

app.AddAppEndpoints();

app.Run();
