namespace Backend.Enums;

// TODO: flow chart
public enum OrderStatus
{
    /// <summary>
    /// Order is currently in the cart. 
    /// These items are not reserved.
    /// </summary>
    OrderInCart,
    /// <summary>
    /// The order has been placed. Needs approval.
    /// </summary>
    OrderPlaced,
    /// <summary>
    /// The order has been rejected.
    /// </summary>
    OrderRejected,
    /// <summary>
    /// The order has been approved. Waiting for pickup
    /// </summary>
    OrderApproved,
    /// <summary>
    /// The order has been cancelled before shipping.
    /// </summary>
    OrderCancelled,
    /// <summary>
    /// The order has been shipped.
    /// </summary>
    OrderShipped,
    /// <summary>
    /// The order has been succefully delivered.
    /// </summary>
    OrderFinished,
}
