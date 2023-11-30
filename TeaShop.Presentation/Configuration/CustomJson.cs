using Microsoft.AspNetCore.Http.Json;
using System.Text.Json;

namespace TeaShop.Presentation.Configuration
{
    public static class CustomJson
    {


        public static JsonSerializerOptions Option
        {
            get
            {
                return new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
            }
        }

       

           
        
    }
}
