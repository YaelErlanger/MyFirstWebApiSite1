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

        public UsersController(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        // GET: api/<UsersController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

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
                return Ok(user);
             return NoContent();
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDTO user)
        {
            try
            {
                UsersTbl userTbl = _mapper.Map<UserDTO,UsersTbl>(user);
                userTbl = await _userServices.addUserToDB(userTbl);
                if (userTbl != null)
                    return CreatedAtAction(nameof(Get), new { id = userTbl.UserId }, userTbl);
                return BadRequest(userTbl);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromBody] UsersTbl userToUpdate)
        {
            userToUpdate.UserId = id;
            int result =await _userServices.updateUserDetails(id,userToUpdate);
            if(result==0)
                return Ok(User);
            else
                return BadRequest("password is not strong enough");
          
        }

       
    }
}
