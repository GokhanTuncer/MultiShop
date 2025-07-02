using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _DirectoryAlertUILayoutComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> Invoke()
        {
            return View();
        }
    }
}
