﻿namespace flutterApi.Models
{
    public class HomePrice
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public User User { get; set; }
        public string  UserId { get; set; }
    }
}
