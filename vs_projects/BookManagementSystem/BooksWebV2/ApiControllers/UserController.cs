using BooksWebV2.Models;
using BooksWebV2.Utils;
using ConceptArchitect.BookManagement;
using ConceptArchitect.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BooksWebV2.ApiControllers
{


    [ApiController]
    [Route("/api/users")]
    [ExceptionMapper(typeof(InvalidEntityException), 404)]
    public class UserController : Controller
    {
        IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Authorize(Roles="Admin,Root")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsers();

            return Ok(users.Select(u =>u.CopyTo<UserInfo>("Password")).ToList());

        }

        [HttpPost]
        [ExceptionMapper(typeof(DbUpdateException),400,Details ="Duplicate User")]
        public async Task<IActionResult> AddUser(UserInfo userInfo)
        {
            var user = userInfo.CopyTo<User>();

            user.Roles.Clear();
            user.Roles.Add("User");
            var result = await userService.AddUser(user);
            
            var info= result.CopyTo<UserInfo>("Password");

            return Created(Url.Link("user_by_id", new { id = user.Email }),info);
        }

        [HttpGet("{id}", Name ="user_by_id")]
        [Authorize]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await userService.GetUserById(id);
            return Ok(user.CopyTo<UserInfo>("Password"));
        }

        [HttpPatch("{email}/roles")]
        [Authorize(Roles ="Admin,Root")]
        public async Task<IActionResult> AddToRole(string email, RoleInfo info)
        {
            var user = await userService.GetUserById(email);
            foreach(var role in info.AddRoles)
                user.Roles.Add(role);
            foreach(var role in info.RemoveRoles) 
                if(user.Roles.Contains(role))
                    user.Roles.Remove(role);

            await userService.Save();

            var u = new User();
            u.Copy(user, "Password");
            return Ok(u);
        }

        [HttpDelete("{email}")] 
        public async Task<IActionResult> DeleteUser(string email)
        {
            await userService.GetUserById(email);
            await userService.RemoveUser(email);
            return NoContent();
        }

        [HttpPut("{email}")]
        public async Task<IActionResult> UpdateUser(string email, UserInfo userInfo)
        {
            var user = userInfo.CopyTo<User>();
            var result = userService.UpdateUser(email, user);

            return Accepted(result.CopyTo<UserInfo>("Password"));
        }
        
    }
}
