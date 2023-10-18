﻿using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Features.Users.Commands;

public record LoginQuery : IRequest<string>
{
    public required string Email { get; init; }

    public required string Password { get; init; }
}

internal class LoginHandler : IRequestHandler<LoginQuery, string>
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public LoginHandler(IConfiguration configuration, IUserRepository userRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }

    public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.CheckUserCredentials(request.Email, request.Password);
        if (user is not null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            var tokenString = GetTokenString(claims, DateTime.UtcNow.AddMinutes(30));
            return tokenString;
        }
        return "User not found or password is incorrect.";
    }

    private string GetTokenString(List<Claim> claims, DateTime exp)
    {
        var key = _configuration["Jwt"] ?? throw new Exception();
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));

        var token = new JwtSecurityToken(
            claims: claims,
            expires: exp,
            signingCredentials: new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256));

        var handler = new JwtSecurityTokenHandler();

        return handler.WriteToken(token);
    }
}
