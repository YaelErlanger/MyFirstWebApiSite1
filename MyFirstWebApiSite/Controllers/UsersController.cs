using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text.Json;
using Services;
using Entities;
using DTO;
using AutoMapper;
using System.Runtime.InteropServices.JavaScript;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductsController> _logger;

        public UsersController(IUserServices userServices, IMapper mapper, ILogger<ProductsController> logger)
        {
            _userServices = userServices;
            _mapper = mapper;
            _logger = logger;
        }



        [HttpPost("checkYourPass")]
        public   ActionResult checkYourPass([FromBody] string password)
        {
            int result =  _userServices.validatePassword(password);
            return  Ok(result);
        }

        // GET api/<UsersController>/
        [HttpPost("Login")]
        public async Task<ActionResult> Get([FromBody] UserLogin userlogin)
        {
            UsersTbl user =await _userServices.getUserByEmailAndPassword(userlogin.Email, userlogin.Password);
            if (user != null)
            {
                _logger.LogInformation("user loged in: ",user);
                return Ok(user);
            }
               
             return NoContent();
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDTO user)
        {
   
                UsersTbl userTbl = _mapper.Map<UserDTO,UsersTbl>(user);
                userTbl = await _userServices.addUserToDB(userTbl);
                if (userTbl != null)
                    return CreatedAtAction(nameof(Get), new { id = userTbl.UserId }, userTbl);
                return BadRequest(userTbl);
  
   
        }

        // PUT api/<UsersController>/5
        [HttpPut("{UserId}")]
        public async Task<ActionResult> Put(int UserId, [FromBody] UserDTO userToUpdate)
        {
            userToUpdate.UserId = UserId;
            UsersTbl userTbl = _mapper.Map<UserDTO, UsersTbl>(userToUpdate);
            int result =await _userServices.updateUserDetails(UserId, userTbl);
            if(result==0)
                return Ok(User);
            else
                return BadRequest("faild to update. the password is not strong enough");
          
        }

       
    }
}
