using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APi_version.Models;
using Microsoft.AspNetCore.Identity;
using static APi_version.Models.AppDBContext;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace APi_version.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser>_userManager;

        private SignInManager<ApplicationUser>_singInManager;

        private readonly AppDBContext _context;

        public ApplicationUserController(AppDBContext context , UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser>signInManager)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _context = context;
        }
        //[HttpPost]
        //[Route("Register")]//POST : /api/ApplicationUser/Register
        //public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        //{
        //    var applicationUser = new ApplicationUser()
        //    {
        //        UserName = model.UserName,Email = model.Email,FullName = model.FullName
        //    };
        //    try {
        //        var result = await _userManager.CreateAsync(applicationUser, model.Password);
        //        return Ok(result);
        //    } catch (Exception ex){
        //        throw ex;
        //    }
        //}
        //[HttpPost][Route("Login")]
        ////POST : /api/ApplicationUser/Login
        //public async Task<IActionResult> Login(LoginModel model){
        //    var user = await _userManager.FindByNameAsync(model.UserName);
        //    if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        //    {
        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(new Claim[]{new Claim("UserID",user.Id.ToString())
        //            });
        //    }

        //}
            
        // GET: api/ApplicationUser
        [HttpGet]
        public IEnumerable<ApplicationUserModel> GetApplicationUserModel()
        {
            return _context.ApplicationUserModel;
        }

        // GET: api/ApplicationUser/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationUserModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var applicationUserModel = await _context.ApplicationUserModel.FindAsync(id);

            if (applicationUserModel == null)
            {
                return NotFound();
            }

            return Ok(applicationUserModel);
        }

        // PUT: api/ApplicationUser/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationUserModel([FromRoute] int id, [FromBody] ApplicationUserModel applicationUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicationUserModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(applicationUserModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApplicationUser
        [HttpPost]
        public async Task<IActionResult> PostApplicationUserModel([FromBody] ApplicationUserModel applicationUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ApplicationUserModel.Add(applicationUserModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationUserModel", new { id = applicationUserModel.Id }, applicationUserModel);
        }

        // DELETE: api/ApplicationUser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationUserModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var applicationUserModel = await _context.ApplicationUserModel.FindAsync(id);
            if (applicationUserModel == null)
            {
                return NotFound();
            }

            _context.ApplicationUserModel.Remove(applicationUserModel);
            await _context.SaveChangesAsync();

            return Ok(applicationUserModel);
        }

        private bool ApplicationUserModelExists(int id)
        {
            return _context.ApplicationUserModel.Any(e => e.Id == id);
        }




       


    }
}