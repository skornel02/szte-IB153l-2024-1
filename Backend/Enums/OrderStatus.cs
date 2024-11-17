using System.ComponentModel.DataAnnotations;

namespace Backend.Enums;

// TODO: flow chart
public enum OrderStatus
{
    /// <summary>
    /// Order is currently in the cart. 
    /// These items are not reserved.
    /// </summary>
    [Display(Name = "Order in cart")]
    OrderInCart,
    /// <summary>
    /// The order has been placed. Needs approval.
    /// </summary>
    [Display(Name = "Order placed")]
    OrderPlaced,
    /// <summary>
    /// The order has been rejected.
    /// </summary>
    [Display(Name = "Order rejected")]
    OrderRejected,
    /// <summary>
    /// The order has been approved. Waiting for pickup
    /// </summary>
    [Display(Name = "Order approved")]
    OrderApproved,
    /// <summary>
    /// The order has been cancelled before shipping.
    /// </summary>
    [Display(Name = "Order cancelled")]
    OrderCancelled,
    /// <summary>
    /// The order has been shipped.
    /// </summary>
    [Display(Name = "Order shipped")]
    OrderShipped,
    /// <summary>
    /// The order has been succefully delivered.
    /// </summary>
    [Display(Name = "Order delivered")]
    OrderFinished,
}
