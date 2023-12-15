using Microsoft.AspNetCore.Mvc;
using TeaShop.Presentation.Dtos.TestimonialDtos;

namespace TeaShop.Presentation.ViewComponents.Dashboard
{
    public class _DashboardComments : ViewComponent
    {
        private readonly HttpClient _client;

        public _DashboardComments(HttpClient client)
        {
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonials = await _client.GetFromJsonAsync<List<ResultTestimonialDto>>("https://localhost:7248/api/Testimonials/");
            return View(testimonials);
        }
    }
}
