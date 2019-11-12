using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyMarket.Api.Dtos
{
    public class AddUserCandyDto
    {
        public int CandyId { get; }
        public int UserId { get; }
        public bool IsTraded { get; set; } = true;
    }
}
