using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieDomain.AuthEntities;
using MovieDomain.BL.ServicesInterface;
using CinemaWebCore.Dto;
using CinemaWebCore.Mappers;


namespace CinemaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        //----------------------------------------------------------------//

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //----------------------------------------------------------------//

        [HttpGet("{id}")]
        public async Task<UserDto> Get(int userId)
        {
            return UserMapper.UserToUserDto(await _userService.GetUser(userId));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]UserDto userDto)
        {
            User user = UserMapper.UserDtoToUser(userDto);
            string message = await _userService.CreateUser(user);
            return Ok(message);
        }

        //----------------------------------------------------------------//

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]UserDto value)
        {
            User user = UserMapper.UserDtoToUser(value);
            string message = await _userService.UpdateUser(user);
            return Ok(message);
        }

        //----------------------------------------------------------------//

    }
}
