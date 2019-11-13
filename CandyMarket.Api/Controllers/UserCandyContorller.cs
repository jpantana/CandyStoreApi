using System;
using System.Collections.Generic;
using CandyMarket.Api.DataModels;
using CandyMarket.Api.Dtos;
using CandyMarket.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CandyMarket.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserCandyController : ControllerBase
    {
        private readonly ILogger<UserCandyController> _logger;
        private readonly IUserCandyRepository _repo;

        public UserCandyController(ILogger<UserCandyController> logger, IUserCandyRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<UserCandy> GetAll()
        {
            return _repo.GetAllUserCandy();
        }

        [HttpPost("{userId}/{candyId}")]
        public void Add(AddUserCandyDto newUserCandy, int userId, int candyId)
        {
            _repo.AddUserCandy(newUserCandy, userId, candyId);
        }

        [HttpPut("{id}/trade")]
        public IActionResult Trade(int id, TradeUserCandyDto userCandyUpdate)
        {
            var repo = new UserCandyRepository();

            var updatedUserCandy = new UserCandy
            {
                CandyId = userCandyUpdate.CandyId,
                UserId = userCandyUpdate.UserId,
                IsTraded = true,
            };

            var userCandyThatGotUpdated = repo.TradeCandy(id, updatedUserCandy);

            return Ok(userCandyThatGotUpdated);
        }
    }
}
