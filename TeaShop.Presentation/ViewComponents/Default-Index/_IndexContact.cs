using Microsoft.AspNetCore.Mvc;

namespace TeaShop.Presentation.ViewComponents.Default_Index
{
    public class _IndexContact:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
