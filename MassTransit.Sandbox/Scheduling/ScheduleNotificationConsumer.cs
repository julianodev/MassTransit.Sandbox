using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransit.Sandbox.Scheduling
{
    /// <summary>
    /// Consumes the message from the schedule_notification_queue 
    /// Then Sends a SendNotificationCommand schedule for 5 seconds later
    /// </summary>
    /// <seealso cref="MassTransit.IConsumer{MassTransit.Sandbox.Scheduling.IScheduleNotification}" />
    internal class ScheduleNotificationConsumer : IConsumer<IScheduleNotification>
    {
        public async Task Consume(ConsumeContext<IScheduleNotification> context)
        {
            await Console.Out.WriteLineAsync($"ScheduleNotificationConsumer> Received a IScheduleNotification to {context.Message.EmailAddress}");
            await Console.Out.WriteLineAsync($"ScheduleNotificationConsumer> Sending at {DateTime.Now} a SendNotification to {context.Message.EmailAddress} for {context.Message.DeliveryTime}");

            var queue = new Uri("rabbitmq://localhost/notification_queue");


            var message = await context.ScheduleSend(queue,
                                   context.Message.DeliveryTime,
                                   new SendNotificationCommand
                                   {
                                       EmailAddress = context.Message.EmailAddress,
                                       Body = context.Message.Body,
                                       DateRequest = context.Message.DeliveryTime
                                   });

            var cancellationToken = message.TokenId;


        }

        public class SendNotificationCommand :
            ISendNotification
        {
            public string EmailAddress { get; set; }
            public string Body { get; set; }
            public DateTime DateRequest { get; set; }
        }
    }
}