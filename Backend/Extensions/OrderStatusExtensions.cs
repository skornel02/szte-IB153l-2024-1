using Backend.Enums;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Backend.Extensions;

public static class OrderStatusExtensions
{
    public static string GetDisplayName(this OrderStatus enumValue)
    {
        return enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()!
                        .Name!;
    }
}
