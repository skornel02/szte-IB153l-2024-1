using Backend.Enums;

namespace Backend.Entities;

public class OrderEntity
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public UserEntity Customer { get; set; } = null!;

    public OrderStatus Status { get; set; }

    public DateTime OrderPlaced { get; set; }

    public DateTime? OrderPaid { get; set; }

    public DateTime? OrderShipped { get; set; }

    public DateTime? OrderReceived { get; set; }

    public DateTime? OrderRefunded { get; set; }

    public decimal TotalPrice { get; set; }

    public decimal Discount { get; set; }

    public List<OrderItemEntity> OrderItems { get; set; } = null!;
}
