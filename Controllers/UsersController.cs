using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Models;
using UsersApi.Services;

namespace UsersApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IUsersRepository usersRepository;
        private IMapper mapper;

        public UsersController(IUsersRepository repository, IMapper _mapper) {
            usersRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers () {
            // var full_name = User.Claims.FirstOrDefault(c => c.Type == "full_name")?.Value;
            var users = await usersRepository.GetUsers();
            return Ok(mapper.Map<IEnumerable<Models.UserDto>>(users));
            // return Ok(full_name);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser (int id) {
            var user = await usersRepository.GetUser(id);
            return Ok(mapper.Map<UserDto>(user));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserAddDto userPayload) {
            var userToSave = mapper.Map<Entities.User> (userPayload);
            await usersRepository.AddUser(userToSave);
            await usersRepository.saveChanges();
            return Ok(userPayload);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, UserUpdateDto userPayload) {
            var user = await usersRepository.GetUser(userId);
            mapper.Map(userPayload, user);
            await usersRepository.saveChanges();
            return Ok(userPayload);
        }
    }
}
