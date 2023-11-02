using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text.Json;
using Services;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserServices _userServices;

        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
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
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] string email, [FromQuery] string password)
        {
            User user =await  _userServices.getUserByEmailAndPassword(email, password);
            if (user != null)
                return Ok(user);
             return NoContent();
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            try
            {
                user= _userServices.addUserToDB(user);
                if (user!=null)
                    return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
                return BadRequest(user);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User userToUpdate)
        {
            int result =await _userServices.updateUserDetails(id, userToUpdate);
            if(result==0)
                return Ok(User);
            if (result == 1)
                return BadRequest();
            return BadRequest();
        }

        // DELETE api/<UsersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        
    }
}
