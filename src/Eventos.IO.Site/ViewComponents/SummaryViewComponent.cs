using Eventos.IO.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventos.IO.Site.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public SummaryViewComponent(IDomainNotificationHandler<DomainNotification> notifications)
        {
            _notifications = notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notifications.GetNotifications());
            notificacoes.ForEach(x => ViewData.ModelState.AddModelError(string.Empty, x.Value));
            return View();
        }
    }
}
