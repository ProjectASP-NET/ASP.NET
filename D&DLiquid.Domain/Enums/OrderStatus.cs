using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.Domain.Enums
{
    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Processing,
        Shipped,
        Delivered,
        Cancelled,
        Refunded,
    }
}
