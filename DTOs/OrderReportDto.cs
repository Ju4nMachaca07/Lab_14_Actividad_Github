namespace Lab_13_JuanMachaca.DTOs;

public class Client { public int ClientId { get; set; } public string Name { get; set; } = string.Empty; public string Email { get; set; } = string.Empty; }
public class Product { public int ProductId { get; set; } public string Name { get; set; } = string.Empty; public string? Description { get; set; } public decimal Price { get; set; } }
public class Order { public int OrderId { get; set; } public int ClientId { get; set; } public DateTime OrderDate { get; set; } }
public class OrderDetail { public int OrderDetailId { get; set; } public int OrderId { get; set; } public int ProductId { get; set; } public int Quantity { get; set; } }

// DTO optimizado para el reporte de Excel
public record OrderReportDto(
    int OrderId,
    string ClientName,
    string ClientEmail,
    DateTime OrderDate,
    string ProductName,
    int Quantity,
    decimal UnitPrice,
    decimal Total
);