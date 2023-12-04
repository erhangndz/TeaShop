using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TeaShop.Presentation.Configuration;
using TeaShop.Presentation.Dtos.TestimonialDtos;

namespace TeaShop.Presentation.ViewComponents.Default_Index
{
    public class _IndexTestimonials:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _IndexTestimonials(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7248/api/Testimonials");
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var testimonials = JsonSerializer.Deserialize<List<ResultTestimonialDto>>(jsonData,CustomJson.Option);
                return View(testimonials);
            }
            return View();
        }
    }
}
