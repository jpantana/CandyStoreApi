using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyMarket.Api.DataModels
{
    public class User
    {
        public int Id { get;  } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime SignUpDate { get; }
        public bool IsActive { get; set; }

        public User()
        {

        }

    }
}
