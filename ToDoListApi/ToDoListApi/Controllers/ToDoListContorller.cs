using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Models;
using ToDoListApi.Services;

namespace ToDoListApi.Controllers
{
    [ApiController]
    [Route("api/v1/todolist")]
    [EnableCors]
    public class ToDoListContorller : ControllerBase
    {
        private readonly TodoListDbContext _context;

        public ToDoListContorller(TodoListDbContext context)
        {
            _context = context;
        }


        [HttpGet("{id:int}")]
        public async Task<Note> Get(int id)
        {
            return await _context.ToDoList.SingleOrDefaultAsync(u => u.Id == id);
        }

        
        // api/v1/user/all
        [HttpGet("all")]
        public async Task<IEnumerable<Note>> Get()
        {
            //var tokenGenerator = new UserTokengenerator();

            //HttpContext.Response.Cookies.Append("user_token", tokenGenerator.Generate());

            //foreach (var cookie in HttpContext.Request.Cookies)
            //{
            //    if (cookie.Value == "user_token")
            //    {

            //    }
            //}

            return await _context.ToDoList.ToListAsync();
        }

        [HttpDelete("{id:int?}")]
        public async Task<Note?> DeleteUser(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var foundUser = await _context.ToDoList.SingleOrDefaultAsync(u => u.Id == id);

            if (foundUser == null)
            {
                return null;
            }

            var entity = _context.ToDoList.Remove(foundUser);

            await _context.SaveChangesAsync();

            return entity.Entity;
        }


        [HttpPut]
        public async Task< Note?> Replace(Note? user)
        {
            if (user == null)
            {
                return null;
            }

            var foundUser = await _context.ToDoList.SingleOrDefaultAsync(u => user.Id == u.Id);

            if (foundUser == null)
            {
                return null;
            }

            _context.ToDoList.Remove(foundUser);
            await _context.ToDoList.AddAsync(user);

            await _context.SaveChangesAsync();


            return user;
        }

        [HttpPost("add")]
        public async Task<HttpResponseMessage> Add(Note? user)
        {
            if (user == null)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = JsonContent.Create(new
                    {
                        Success = false,
                        Message = "Failed to create user"
                    })
                };
            }

            await _context.ToDoList.AddAsync(user);
            await _context.SaveChangesAsync();

            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = JsonContent.Create(new
                {
                    Success = true,
                    Message = "User created"
                })
            };
        }


        [HttpPatch("{id:int?}")]
        public async Task<Note?> Modify(int? id, Note? note)
        {
            if (id == null || note == null)
            {
                return null;
            }

            var foundUser = await _context.ToDoList.SingleOrDefaultAsync(u => u.Id == id);

            if (foundUser == null)
            {
                return null;
            }

            if (note.Title != null)
            {
                foundUser.Title = note.Title;
            }


            

            await _context.SaveChangesAsync();

            return note;
        }

    }
}
