// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;
// using System.Linq;
// using TodoApi.Models;

// namespace TodoApi.Controllers{
//     [Route("api/[controller]")]
//     [ApiController]
//     public class AuthorController : ControllerBase{
//         private readonly TodoContext _context;
//         public AuthorController(TodoContext context)
//         {
//             _context = context;
//         }

//         #region snippet_GetAll
//         [HttpGet]
//         public ActionResult<List<Author>> GetAll()
//         {
//             return _context.Author.ToList();
//         }
//         #endregion
//         #region snippet_GetByID
//         [HttpGet("{id}", Name = "GetAuthor")]
//         public ActionResult<Author> GetById(long id)
//         {
//             var item = _context.Author.Find(id);
//             if (item == null)
//             {
//                 return NotFound();
//             }
//             return item;
//         }
//         #endregion
//     }
// }