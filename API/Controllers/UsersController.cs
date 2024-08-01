using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController(DataContext context) : ControllerBase
{
    /*private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        this._context = context;
    }
    Usual way of inject a service in a controller, but in C# 12 we have concept of primary constructor.
    */

    [HttpGet]
    //[Route("getusers")]
 public ActionResult<IEnumerable<AppUser>> GetUsers()
 {
    var users = context.Users.ToList();
    return Ok(users);
 } 
 [HttpGet("{id:int}")]
 //[Route("getuser/{id}")]
 public ActionResult<AppUser> GetUser(int id)
 {
    var user = context.Users.Find(id);
    
    if(user == null) return BadRequest();
    return Ok(user);
 }

}
