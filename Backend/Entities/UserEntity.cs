using Backend.Enums;

namespace Backend.Entities;

public class UserEntity
{
    public Guid Id { get; set; }

    public string EmailAddress { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime LastSeen { get; set; } = DateTime.MinValue;

    public DateTime Registered { get; set; }

    public UserRole Role { get; set; }

    public List<OrderEntity> Orders { get; set; } = null!;
}
