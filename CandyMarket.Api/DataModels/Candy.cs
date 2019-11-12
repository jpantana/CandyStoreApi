using System;

namespace CandyMarket.Api.DataModels
{
    public class Candy
    {
        public int Id { get; }
        public string Name { get; set; }
        public bool IsHard { get; set; }
        public bool IsChocolate { get; set; }
        public bool IsFruity { get; set; }
        public int Cost { get; set; }
        public bool WillTrade { get; set; }
    }
}
