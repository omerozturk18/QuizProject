﻿using System.Collections.Generic;
using Core.Utilities.Results;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult IsAuthenticated(string userMail, List<string> requiredRoles);

    }
}
