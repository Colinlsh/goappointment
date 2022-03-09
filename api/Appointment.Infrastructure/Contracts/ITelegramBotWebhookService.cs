using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Appointment.Application.Core.Interfaces
{
    public interface ITelegramBotWebhookService
    {
        Task EchoAsync(Update update, CancellationToken cancellationToken);
        Task HandleErrorAsync(Exception exception);
    }
}