using System.Collections.Generic;
using CandyMarket.Api.DataModels;
using CandyMarket.Api.Dtos;

namespace CandyMarket.Api.Repositories
{
    public interface IUserCandyRepository
    {
        IEnumerable<UserCandy> GetAllUserCandy();
        bool AddUserCandy(AddUserCandyDto newUserCandy, int userId, int candyId);
        bool Update(UserCandy updatedUserCandy, int id, int newId);
    }
}
