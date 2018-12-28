using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MovieDomain.AuthEntities;
using CinemaWebCore.Dto;

namespace CinemaWebCore.Mappers
{
    public static class UserMapper
    {

        //----------------------------------------------------------------//

        public static User UserDtoToUser(UserDto userDto)
        {
            User user = null;
            if(userDto != null)
            {
                user = new User(userDto.Gender)
                {
                    FirstName = userDto.FirstName,
                    SecondName = userDto.SecondName,
                    Country = userDto.Country,
                    City = userDto.City,
                    Address = userDto.Address,
                    PathOfPhoto = userDto.PathOfPhoto
                };
            }

            return user;
        }

        //----------------------------------------------------------------//

        public static UserDto UserToUserDto(User user)
        {
            UserDto userDto = null;

            if(userDto != null)
            {
                userDto = new UserDto()
                {
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    Country = user.Country,
                    City = user.City,
                    Address = user.Address,
                    PathOfPhoto = user.PathOfPhoto
                };
            }

            return userDto;
        }

        //----------------------------------------------------------------//

    }
}