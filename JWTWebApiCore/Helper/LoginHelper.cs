﻿using JWTWebApiCore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTWebApiCore.Helper
{
    public class LoginHelper
    {
        private IConfiguration _config;
        public LoginHelper(IConfiguration config)
        {
            _config = config;
        }
        public string Generate(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.GivenName, user.GivenName),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddHours(24),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public UserModel Authenticate(UserLogin userLogin)
        {
            var currentUser = UserConstants.Users.FirstOrDefault(o => o.Username.ToLower() == userLogin.User.ToLower() && o.Password == userLogin.Pwd);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

    }
}
