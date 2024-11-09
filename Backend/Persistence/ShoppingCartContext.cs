using Backend.Models;
using System.Collections.Concurrent;

namespace Backend.Persistence;

public static class ShoppingCartContext
{

    private static readonly ConcurrentDictionary<string, List<ShoppingCartItem>> ShoppingCart = new();

    public static List<ShoppingCartItem> GetShoppingCart(string? email)
    {
        if (email is null)
        {
            return [];
        }

        return new(ShoppingCart.GetOrAdd(email, _ => []));
    }

    public static void AddItemToCart(string email, ShoppingCartItem item)
    {
        var shoppingCart = GetShoppingCart(email);

        var existingItem = shoppingCart.FirstOrDefault(_ => _.ProductId == item.ProductId);
        if (existingItem != null)
        {
            shoppingCart.Remove(existingItem);
            item = existingItem with { Quantity = existingItem.Quantity + item.Quantity };
        }

        shoppingCart.Add(item);
    }

    public static void SaveShoppingCart(string? email, List<ShoppingCartItem> shoppingCart)
    {
        if (email is null)
        {
            return;
        }

        ShoppingCart.AddOrUpdate(email, shoppingCart, (_, _) => shoppingCart);
    }

    public static void ClearCart(string email)
    {
        ShoppingCart.TryRemove(email, out _);
    }

    public static void RemoveItemFromCart(string email, Guid productId)
    {
        var shoppingCart = GetShoppingCart(email);
        var item = shoppingCart.FirstOrDefault(_ => _.ProductId == productId);
        if (item != null)
        {
            shoppingCart.Remove(item);
        }
    }
}
