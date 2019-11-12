using System;
using System.Collections.Generic;
using CandyMarket.Api.DataModels;
using CandyMarket.Api.Dtos;
using System.Data.SqlClient;
using Dapper;

namespace CandyMarket.Api.Repositories
{
    public class CandyRepository : ICandyRepository
    {

        string _connectionString = "Server=localhost;Database=Candy;Trusted_Connection=True;";

        public IEnumerable<Candy> GetAllCandy()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();

                var candy = db.Query<Candy>("Select * From Candy");

                return candy;
            }
        }

        public bool AddCandy(AddCandyDto newCandy)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"
                        INSERT INTO [Candy]
                                    ([Name]
                                    ,[IsHard]
                                    ,[IsChocolate]
                                    ,[IsFruity]
                                    ,[Cost]
                                    ,[WillTrade])
	                        OUTPUT inserted.*
                                VALUES
                                    (@name
                                    ,'false'
                                    ,'true'
                                    ,'false'
                                    ,1
                                    ,'true')";


                return db.Execute(sql, newCandy) == 1;
            }
        }

        public bool EatCandy(int candyIdToDelete)
        {
            using (var db = new SqlConnection(_connectionString))
            {

                var sql = @"delete From Candy Where [id] = @id";

                return db.Execute(sql, new { id = candyIdToDelete }) == 1;
            }
        }

        public void TradeCandy(int userIdToTrade)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"select * from [UserCandy]";

                db.Query<UserCandy>(sql);
            }
        }

    }
}