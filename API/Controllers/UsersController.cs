using API.Data;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        //Se usa IEnumerable para dar un tipo de lista más simple
        //Para dar a todos los usuarios, se crea una tarea que es async para poder tener
        //mayor cantidad de usuarios en menos tiempo.
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        //Para dar a un usuario en específico
        //api/users/3  Es un ejemplo de lo que el cliente va a enviar
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}