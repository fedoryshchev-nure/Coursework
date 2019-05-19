using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models.Origin;
using Coursework.API.DTOs;
using Coursework.API.Services.TokenBuilderService;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Coursework.API.Services.AuthenticationService
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly ITokenBuilder tokenBuilder;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public JwtAuthenticationService(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            ITokenBuilder tokenBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.tokenBuilder = tokenBuilder;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<AuthenticationToken> Authenticate(LoginModel model)
        {
            var result = await signInManager
                .PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var token = tokenBuilder.BuildAsync(model.Email);
                return await token;
            }
            else
                throw new Exception("Invalid username or password.");
        }     

        public async Task RegisterAsync(UserDTO dto)
        {
            var user = mapper.Map<User>(dto);
            var result = await userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                await userManager.AddClaimAsync(user, 
                    new Claim(ClaimTypes.Email, user.Email));
                await userManager.AddToRoleAsync(user, "User");
            }
            else
            {
                throw new Exception("Registration failed");
            }
        }
    }
}
