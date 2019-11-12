using System.Collections.Generic;
using CandyMarket.Api.DataModels;
using CandyMarket.Api.Dtos;

namespace CandyMarket.Api.Repositories
{
    public interface IUserCandyRepository
    {
        IEnumerable<UserCandy> GetAllUserCandy();
        IEnumerable<UserCandy> TradeCandy(int newUserId, int oldUserId, int candyId);
        bool AddUserCandy(AddUserCandyDto newUserCandy, int userId, int candyId);
    }
}
