using System;
using System.Collections.Generic;
using CandyMarket.Api.DataModels;
using CandyMarket.Api.Dtos;
using System.Data.SqlClient;
using Dapper;

namespace CandyMarket.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        string _connectionString = "Server=localhost;Database=Candy;Trusted_Connection=True;";

        public IEnumerable<User> GetAllUsers()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();

                var user = db.Query<User>("Select * From [User]");

                return user;
            }
        }

        public IEnumerable<User> GetSingleUser(int userId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();

                var sql = @"Select * From [User] Where [User].id = @uid";

                var user = db.Query<User>(sql, new { uid = userId });

                return user;
            }
        }

        public bool AddUser(AddUserDto newUser)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"
                        INSERT INTO [User]
                                    ([FirstName]
                                    ,[LastName]
                                    ,[SignUpDate]
                                    ,[IsActive])
	                        OUTPUT inserted.*
                                VALUES
                                    (@FirstName
                                    ,@LastName
                                    ,CURRENT_TIMESTAMP
                                    ,'true')";


                return db.Execute(sql, newUser) == 1;
            }
        }

        public bool DeleteThisUser(int deleteThisUser)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = @"delete from [User] where [Id] = @id";

                return db.Execute(sql, new { id = deleteThisUser }) == 1;
            }
        }
    }
}
