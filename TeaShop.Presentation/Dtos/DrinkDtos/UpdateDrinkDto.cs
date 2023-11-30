namespace TeaShop.Presentation.Dtos.DrinkDtos
{
    public class UpdateDrinkDto
    {
        public int DrinkId { get; set; }
        public string DrinkName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
