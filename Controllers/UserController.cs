using Microsoft.AspNetCore.Mvc;
using Shabana.DBFirst.DataAccessLayer;
using Shabana.DBFirst.DataAccessLayer.Models;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
       QuickKartRepository quickKartRepository;

        public UserController(QuickKartRepository quickKartRepository)
        {
            this.quickKartRepository = quickKartRepository;
        }
        [HttpGet]
        public JsonResult GetAllUser()
        {
            List<User> users = new List<User>();
            try
            {
                users = quickKartRepository.GetUsers();
            }
            catch (Exception ex)
            {
                users = null;
            }
            return Json(users);
        }
        [HttpGet]
        public JsonResult GetUser(string EmailID)
        {
            User userbyEmail = new User ();
            try
            {
                userbyEmail = quickKartRepository.GetUserByEmailId(EmailID);

            }
            catch (Exception ex)
            {
                userbyEmail = null;
            }
            return Json(userbyEmail);


        }
    }
}
