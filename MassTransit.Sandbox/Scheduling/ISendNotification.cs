using System;

namespace MassTransit.Sandbox.Scheduling
{
    public interface ISendNotification
    {
        string EmailAddress { get; }
        string Body { get; }
        DateTime DateRequest { get; set; }
    }
}