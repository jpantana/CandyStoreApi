using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyMarket.Api.DataModels
{
    public class UserCandy
    {
        public int Id { get; }
        public int CandyId { get; }
        public int UserId { get;  }
        public bool IsTraded { get; set; }
    }
}
