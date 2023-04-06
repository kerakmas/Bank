using Bank.Service.DTOs;
using Bank.Service.Interfaces;
using Bank.Service.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService = new UserService();
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> DoCreate(UserCreationDTO userCreationDTO)
        {
            var res = await _userService.CreateAsync(userCreationDTO);
            return View("Index");
        }
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var res = await _userService.DeleteAsync(x => x.Id == id);
            return View("Index");
        }
        public async Task<IActionResult> DoUpdate(UserCreationDTO userCreationDTO)
        {
            int UserId = int.Parse(TempData["id"].ToString());
            var res = await _userService.UpdateAsync(x => x.Id == UserId,userCreationDTO);
            return View("Index");
        }
        public IActionResult Update(int id)
        {
            TempData["id"] = id;
            return View();
        }

    }
}
