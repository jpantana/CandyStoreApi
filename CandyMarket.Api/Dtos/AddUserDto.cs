using System;

namespace CandyMarket.Api.Dtos
{
    public class AddUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string SignUpDate { get; }
        public bool IsActive { get; set; } = true;
    }
}
