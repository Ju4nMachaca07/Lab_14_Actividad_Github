namespace Lab_13_JuanMachaca.DTOs.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<OrderReportDto>> GetOrderReportDataAsync();
}

public class OrderRepository : IOrderRepository
{
    // Simulación de los datos del script SQL (remplazar por DbContext de EF Core según tu proyecto)
    public Task<IEnumerable<OrderReportDto>> GetOrderReportDataAsync()
    {
        var clients = new[]
        {
            new Client { ClientId = 1, Name = "Juan Pérez", Email = "juan.perez@example.com" },
            new Client { ClientId = 2, Name = "Ana Gómez", Email = "ana.gomez@example.com" },
            new Client { ClientId = 3, Name = "Carlos Díaz", Email = "carlos.diaz@example.com" },
            new Client { ClientId = 4, Name = "Lucía Martínez", Email = "lucia.martinez@example.com" }
        };

        var products = new[]
        {
            new Product { ProductId = 1, Name = "Producto A", Price = 10.50m },
            new Product { ProductId = 2, Name = "Producto B", Price = 25.00m },
            new Product { ProductId = 3, Name = "Producto C", Price = 15.75m },
            new Product { ProductId = 4, Name = "Producto D", Price = 30.20m }
        };

        var orders = new[]
        {
            new Order { OrderId = 1, ClientId = 1, OrderDate = DateTime.Parse("2025-05-01") },
            new Order { OrderId = 2, ClientId = 1, OrderDate = DateTime.Parse("2025-05-02") },
            new Order { OrderId = 3, ClientId = 2, OrderDate = DateTime.Parse("2025-05-03") },
            new Order { OrderId = 4, ClientId = 2, OrderDate = DateTime.Parse("2025-05-04") }
        };

        var details = new[]
        {
            new OrderDetail { OrderDetailId = 1, OrderId = 1, ProductId = 2, Quantity = 2 },
            new OrderDetail { OrderDetailId = 2, OrderId = 1, ProductId = 1, Quantity = 1 },
            new OrderDetail { OrderDetailId = 3, OrderId = 2, ProductId = 3, Quantity = 1 },
            new OrderDetail { OrderDetailId = 4, OrderId = 2, ProductId = 4, Quantity = 1 }
        };

        var query = from d in details
                    join o in orders on d.OrderId equals o.OrderId
                    join c in clients on o.ClientId equals c.ClientId
                    join p in products on d.ProductId equals p.ProductId
                    select new OrderReportDto(
                        o.OrderId,
                        c.Name,
                        c.Email,
                        o.OrderDate,
                        p.Name,
                        d.Quantity,
                        p.Price,
                        d.Quantity * p.Price
                    );

        return Task.FromResult(query.AsEnumerable());
    }
}