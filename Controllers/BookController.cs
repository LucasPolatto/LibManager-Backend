using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers;

[ApiController]
[Route("book")]
public class BookController: ControllerBase
{
    private LibDB db;
    public BookController(LibDB db)
    {
        this.db = db;
    }
    
    [HttpGet]
    public ActionResult Read()
    {
        return Ok(db.Books.ToList());
    }

    [HttpPost]
    public ActionResult Create(Book book)
    {
        db.Books.Add(book);
        db.SaveChanges();
        return Created(book.Id.ToString(), book);
    }
    
    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
        Book? book = db.Books.Find(id);

        if(book == null)
            return NotFound();

        db.Books.Remove(book);
        db.SaveChanges();

        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(int id, string? newSession, string newSituation)
    {
        Book? _book = db.Books.Find(id);
        if(_book == null)
            return NotFound();

        _book.Session = newSession;
        _book.Situation = newSituation;

        db.SaveChanges();
        return Ok();
    }
}