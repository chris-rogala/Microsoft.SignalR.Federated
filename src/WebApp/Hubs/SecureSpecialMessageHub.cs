using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Hubs
{
    [Authorize]
    public class SecureSpecialMessageHub : Hub
    {
        private static int _messageCounter = 0;

        public override Task OnConnectedAsync()
        {
            // Replaced the extension method with the Identity.Name since the claim will not be here in Azure AD
            var customerId = Context.User.Identity.Name.Split("@").Last();
            Groups.AddToGroupAsync(Context.ConnectionId, GetCustomerGroupName(customerId));

            return base.OnConnectedAsync();
        }

        public Task SendMessage(string customerId,
            SendSpecialMessage message,
            CancellationToken cancellationToken)
        {
            _messageCounter++;
            var specialMessage = new SpecialMessage
            {
                Id = _messageCounter,
                Text = message.Text
            };

            return Clients.Groups(GetCustomerGroupName(customerId))
                .SendAsync("ReceiveMessage", specialMessage, cancellationToken);
        }

        private string GetCustomerGroupName(string customerId) => $"customers-{customerId}";
    }
}