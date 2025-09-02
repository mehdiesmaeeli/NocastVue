using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using NoCast.App.Data;
using NoCast.App.Models;
using System.Security.Claims;

namespace NoCast.App.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;
        private static string groupName ="AdminGroup";

        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SendMessage(string receiverId, string message)
        {
            var senderId = Guid.Parse(Context.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var msg = new ChatMessage
            {
                SenderId = senderId,
                //ReceiverId = Guid.Parse(receiverId),
                Content = message,
                Type = MessageType.Direct
            };

            //_context.ChatMessages.Add(msg);
            //await _context.SaveChangesAsync();

            msg.CreatedAt = DateTime.UtcNow.ToLocalTime();
            // Send to receiver
            await Clients.Group(groupName).SendAsync("ReceiveMessage", msg);

            if (true)
            {
                var botReply = $"بات: پاسخ به '{message}'";
                // await Clients.Group(groupName).SendAsync("ReceiveMessage", "Bot", botReply);
                // Send back to sender
                await Clients.Caller.SendAsync("ReceiveMessage", msg);
                await Clients.Caller.SendAsync("ReceiveMessage", botReply);
            }
        }
    }
}