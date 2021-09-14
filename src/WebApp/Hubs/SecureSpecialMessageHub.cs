using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Hubs
{
    [Authorize]
    public class SecureSpecialMessageHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            // Replaced the extension method with the Identity.Name since the claim will not be here in Azure AD
            var customerId = Context.User.Identity.Name;
            Groups.AddToGroupAsync(Context.ConnectionId, GetCustomerGroupName(customerId));

            return base.OnConnectedAsync();
        }

        public Task SendMessage(string customerId,
            SpecialMessage message,
            CancellationToken cancellationToken)
        {
            return Clients.Groups(GetCustomerGroupName(customerId)).SendAsync("ReceiveMessage", message, cancellationToken);
        }

        private string GetCustomerGroupName(string customerId) => $"customers-{customerId}";
    }
}