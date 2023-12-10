using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShop.Business.Abstract;
using TeaShop.DataAccess.Concrete;

namespace TeaShop.Business.Concrete
{
	public class StatisticsService : IStatisticsService
	{
		private readonly TeaContext _context;

		public StatisticsService(TeaContext context)
		{
			_context = context;
		}

		public decimal DrinkAvgPrice()
		{
			return _context.Drinks.Average(x => x.Price);
		}

		public int DrinkCount()
		{
			return _context.Drinks.Count();
		}

		public string LastDrinkName()
		{
			return _context.Drinks.OrderByDescending(x=>x.DrinkId).Select(x=>x.DrinkName).FirstOrDefault();
		}

		public string MaxPriceDrink()
		{
			var price=  _context.Drinks.Max(x => x.Price);
			return _context.Drinks.Where(x => x.Price == price).Select(x => x.DrinkName).FirstOrDefault();
		}
	}
}
