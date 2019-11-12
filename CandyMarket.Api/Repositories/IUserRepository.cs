using System.Collections.Generic;
using CandyMarket.Api.DataModels;
using CandyMarket.Api.Dtos;

namespace CandyMarket.Api.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        bool AddUser(AddUserDto newUser);
        bool DeleteThisUser(int userIdToDelete);
    }
}
