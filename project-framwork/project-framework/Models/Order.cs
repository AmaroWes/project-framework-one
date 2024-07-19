﻿using System.ComponentModel.DataAnnotations;

namespace project_framework.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [Required]
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public string DishList { get; set; }
    }
}
