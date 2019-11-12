namespace CandyMarket.Api.Dtos
{
    public class AddCandyDto
    {
        public string Name { get; set; }
        // my updates below
        public bool IsHard { get; set; }
        public bool IsChocolate { get; set; }
        public bool IsFruity { get; set; }
        public int Cost { get; set; }
        public bool WillTrade { get; set; }
    }
}