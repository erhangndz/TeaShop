namespace TeaShop.Business.Abstract
{
	public interface IStatisticsService
	{
		int DrinkCount();
		decimal DrinkAvgPrice();
		string LastDrinkName();
		string MaxPriceDrink();
	}
}
