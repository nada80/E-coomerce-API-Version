using APi_version.DTO;
using APi_version.Mapper;
using APi_version.Models;
using AutoMapper;
using AutoMapper.Configuration;
using LinqToDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static APi_version.Models.AppDBContext;

namespace APi_version.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        protected readonly IMapper Mapper = Mapperconfig.mapper;
        protected readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly AppDBContext _context;

        public AccountController(Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager, IConfiguration configuration, AppDBContext context)
        {
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserDto userdto)
        {
            var user = Mapper.Map<ApplicationUser>(userdto);

            if (!ModelState.IsValid)
            {
                return BadRequest("Data Not Valid");
            }
            try
            {

                UserStore<IdentityUser> store = new UserStore<IdentityUser>(new AppDBContext());


                IdentityUser identity = new IdentityUser();
                identity.UserName = user.UserName;
                identity.PasswordHash = user.Password;

                IdentityResult result = await _userManager.CreateAsync(identity, user.Password);

                if (result.Succeeded)
                {
                    _context.Cart.Add(new Cart() { UserID = identity.Id });
                    //_context.SaveChanges();
                    _context.SaveChanges();
                    //  return Redirect("http://localhost:49682/Student_Index.html");
                    return Ok();
                }
                else
                {
                    return BadRequest(result.Errors.ToList()[0]);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {


                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier,user.Id),
                    new Claim(ClaimTypes.Role,user.Id),

                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };





                //var token = new JwtSecurityToken(
                //    issuer: _configuration["JWT:Issuer"],
                //    audience: _configuration["JWT:Audience"],
                //    expires: DateTime.Now.AddHours(3),
                //    claims: authClaims

                //    );

                //return Ok(new
                //{
                //    token = new JwtSecurityTokenHandler().WriteToken(token),
                //    expiration = token.ValidTo
                //});
            }
            return Unauthorized();
        }
    }
}
