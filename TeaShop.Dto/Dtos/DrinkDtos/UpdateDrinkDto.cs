﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShop.Dto.Dtos.DrinkDtos
{
    public class UpdateDrinkDto
    {
        public int DrinkId { get; set; }
        public string DrinkName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
