using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers;

[ApiController]
[Route("user")]
public class UserController: ControllerBase
{
    private LibDB db;

    public UserController(LibDB db)
    {
        this.db = db;
    }

    [HttpGet]
    public ActionResult Read()
    {        
        return Ok(db.Users.ToList());
    }

    [HttpPost]
    public ActionResult Create(User user)
    {
        db.Users.Add(user);
        db.SaveChanges();

        return Created(user.Id.ToString(), user);
    }
    
    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
        User? user = db.Users.Find(id);

        if(user == null)
            return NotFound();

        db.Users.Remove(user);
        db.SaveChanges();

        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(int id, string password)
    {
        User? _user = db.Users.Find(id);
        if(_user == null)
            return NotFound();

        _user.Password = password;

        db.SaveChanges();
        return Ok();
    }

}