﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class CreateEntityDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ConsumptionDate { get; set; }
        public MealType MealType { get; set; }
        public RecipeDTO Recipe { get; set; }
    }
}
