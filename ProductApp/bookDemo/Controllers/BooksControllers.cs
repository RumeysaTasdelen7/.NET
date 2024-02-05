using bookDemo.Data;
using bookDemo.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bookDemo.Controllers
{
    [Route("api/books")]
    public class BooksControllers : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBooks([FromRoute(Name ="id")] int id)
        {
            var book = ApplicationContext
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();
            
            if(book is null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if(book is null)
                return BadRequest();

                ApplicationContext.Books.Add(book);
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name ="id")] int id,
        [FromBody] Book book)
        {
            //check book?
            var entity = ApplicationContext
                .Books
                .Find(b => b.Id.Equals(id));

            if(entity is null)
                return NotFound(); //404

                //check id
                if (id != book.Id)
                return BadRequest(); //400

                ApplicationContext.Books.Remove(entity);
                book.Id = entity.Id;
                ApplicationContext.Books.Add(book);
                return Ok(book);
        }

        [HttpDelete]
        public IActionResult DeleteAllBooks()
        {
            ApplicationContext.Books.Clear();
            return NoContent(); // 204
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name ="id")] int id)
        {
            var entity = ApplicationContext
            .Books
            .Find(b => b.Id.Equals(id));

            if (entity is null)
            return NotFound(new
            {
                StatusCode = 404,
                message = $"Book with id:{id} could not found."
            }); //404

            ApplicationContext.Books.Remove(entity);
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name ="id")] int id,
         [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            var entity = ApplicationContext.Books.Find(b =>b.Id.Equals(id));
            if (entity is null)
            return NotFound(); //404

            bookPatch.ApplyTo(entity);
            return NoContent(); // 204
        }
    }
}