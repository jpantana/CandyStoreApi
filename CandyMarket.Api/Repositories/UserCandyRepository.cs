using CandyMarket.Api.DataModels;
using CandyMarket.Api.Dtos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CandyMarket.Api.Repositories
{
    public class UserCandyRepository : IUserCandyRepository
    {
        string _connectionString = "Server=localhost;Database=Candy;Trusted_Connection=True;";

        public IEnumerable<UserCandy> GetAllUserCandy()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select * from [UsersCandy]";

                var userCandy = db.Query<UserCandy>(sql);
                
                return userCandy;
            }
        }

        public bool AddUserCandy(AddUserCandyDto newUserCandy, int userId, int candyId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO [UsersCandy]
                                ([CandyId]
                                ,[UserId]
                                ,[IsTraded])
                            OUTPUT inserted.*
                                VALUES
                                (@cId
                                ,@uId
                                ,'false')";

                var userCandyObj = new
                {
                    uId = userId,
                    cId = candyId,
                };

                return db.Execute(sql, userCandyObj) == 1;
            }
        }

        public IEnumerable<UserCandy> TradeCandy(int newUserId, int oldUserId, int candyId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT * FROM [UsersCandy]
                            WHERE candyId = @cId AND userId = @ouId";


                var sql3 = @"UPDATE [UsersCandy]
                `            SET UserId = @nuId, IsTraded = 'true'
                             WHERE candyId = @cId AND userId = @ouId";

                var sql2 = @"INSERT INTO [UsersCandy]
                                ([CandyId]
                                ,[UserId]
                                ,[IsTraded])
                            OUTPUT inserted.*
                                VALUES
                                (@cId
                                ,@uId
                                ,'true')";

                var userCandyObj = new
                {
                    cId = candyId,
                    nuId = newUserId,
                    ouId = oldUserId,
                };

                var userCandy = db.Query<UserCandy>(sql3, userCandyObj);

                return userCandy;
            }
        }
    }
}
