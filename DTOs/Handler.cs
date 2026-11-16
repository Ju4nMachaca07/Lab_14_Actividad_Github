using Lab_13_JuanMachaca.DTOs.Interfaces;

namespace Lab_13_JuanMachaca.DTOs;

using ClosedXML.Excel;
using MediatR;

// 1. Query CQRS
public record ExportOrdersToExcelQuery : IRequest<byte[]>;

// 2. Handler CQRS
public class ExportOrdersToExcelHandler : IRequestHandler<ExportOrdersToExcelQuery, byte[]>
{
    private readonly IOrderRepository _repository;

    public ExportOrdersToExcelHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<byte[]> Handle(ExportOrdersToExcelQuery request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetOrderReportDataAsync();

        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Reporte de Pedidos");

            // Encabezados
            worksheet.Cell(1, 1).Value = "ID Orden";
            worksheet.Cell(1, 2).Value = "Cliente";
            worksheet.Cell(1, 3).Value = "Email";
            worksheet.Cell(1, 4).Value = "Fecha Pedido";
            worksheet.Cell(1, 5).Value = "Producto";
            worksheet.Cell(1, 6).Value = "Cantidad";
            worksheet.Cell(1, 7).Value = "Precio Unitario";
            worksheet.Cell(1, 8).Value = "Total";

            // Dar formato a la fila de encabezado
            var headerRow = worksheet.Row(1);
            headerRow.Style.Font.Bold = true;
            headerRow.Style.Fill.BackgroundColor = XLColor.FromHtml("#1F497D");
            headerRow.Style.Font.FontColor = XLColor.White;

            // Llenado de datos
            int row = 2;
            foreach (var item in data)
            {
                worksheet.Cell(row, 1).Value = item.OrderId;
                worksheet.Cell(row, 2).Value = item.ClientName;
                worksheet.Cell(row, 3).Value = item.ClientEmail;
                worksheet.Cell(row, 4).Value = item.OrderDate.ToString("yyyy-MM-dd");
                worksheet.Cell(row, 5).Value = item.ProductName;
                worksheet.Cell(row, 6).Value = item.Quantity;
                worksheet.Cell(row, 7).Value = item.UnitPrice;
                worksheet.Cell(row, 8).Value = item.Total;
                row++;
            }

            // Ajustar automáticamente el ancho de columnas
            worksheet.Columns().AdjustToContents();

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return stream.ToArray();
            }
        }
    }
}