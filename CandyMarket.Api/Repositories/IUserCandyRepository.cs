using System.Collections.Generic;
using CandyMarket.Api.DataModels;
using CandyMarket.Api.Dtos;

namespace CandyMarket.Api.Repositories
{
    public interface IUserCandyRepository
    {
        IEnumerable<UserCandy> GetAllUserCandy();
        UserCandy TradeCandy(int id, UserCandy userCandyUpdate);
        bool AddUserCandy(AddUserCandyDto newUserCandy, int userId, int candyId);
        object Update(UserCandy updatedUserCandy, int id);
    }
}
