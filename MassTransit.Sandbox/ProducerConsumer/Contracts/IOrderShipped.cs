using System;

namespace MassTransit.Sandbox.ProducerConsumer.Contracts
{
    public interface IOrderShipped
    {
        string OrderId { get; }
        DateTime OrderDate { get; }
        DateTime ShippingDate { get; }
    }
}