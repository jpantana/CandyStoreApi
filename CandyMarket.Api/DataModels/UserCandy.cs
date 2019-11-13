using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyMarket.Api.DataModels
{
    public class UserCandy
    {
        public int Id { get; }
        public int CandyId { get; set; }
        public int UserId { get; set; }
        public bool IsTraded { get; set; }
    }
}
