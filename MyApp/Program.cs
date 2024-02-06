using MyApp.ServiceInterface;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddServiceStack(typeof(MyServices).Assembly, c =>
{
    c.AddSwagger();
});

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseServiceStack(new AppHost(), options => {
    options.MapEndpoints();
});

app.Run();