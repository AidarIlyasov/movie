﻿using System.Collections.Generic;
using MovieApp.Application.DTO;

namespace MovieApp.Infrastructure.Services.User
{
    public interface IUser
    {
        public IEnumerable<UserDto> GetUsers();
        public UserDto UpdateUser();
        public UserDto GetUser(int id);
    }
}