using ClosedXML.Excel;
using Lab_13_JuanMachaca.DTOs;
using Lab_13_JuanMachaca.DTOs.Interfaces;

using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Swagger y Servicios
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de dependencias para CQRS y Repositorio
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    });
}
app.UseHttpsRedirection();

// Endpoint documentado en Swagger
app.MapGet("/api/orders/export-excel", async (ISender mediator) =>
    {
        var fileBytes = await mediator.Send(new ExportOrdersToExcelQuery());
        return Results.File(
            fileBytes, 
            contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 
            fileDownloadName: $"Reporte_Pedidos_{DateTime.Now:yyyyMMddHHmmss}.xlsx"
        );
    })
    .WithName("ExportOrdersToExcel")
    .WithTags("Reportes")
    .WithSummary("Genera y descarga un reporte en Excel de los pedidos de la BD")
    .WithDescription("Consulta las tablas Clients, Products, Orders y OrderDetails usando CQRS y retorna un archivo .xlsx listo para descargar.");

app.Run();