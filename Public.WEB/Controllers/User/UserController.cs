using Microsoft.AspNetCore.Mvc;
using Public.WEB.Models.User;
using Public.WEB.Services.User;

namespace Public.WEB.Controllers.User
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Users
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(UserFilter filter)
        {
            var users = await _userService.GetAllUsersAsync(filter);
            return Json(new
            {
                data = users
            });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return PartialView("_View", user);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_Create", new UserRequest());
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRequest request)
        {
            if (!ModelState.IsValid)
                return PartialView("_Create", request);

            var created = await _userService.CreateUserAsync(request);
            if (created)
                return Json(new { success = true });

            return Json(new { success = false, message = "Failed to create user." });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            var request = new UserRequest
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                EmploymentType = user.EmploymentType,
                UserType = user.UserType
            };

            ViewBag.UserId = id;
            return PartialView("_Edit", request);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UserRequest request)
        {
            if (!ModelState.IsValid)
                return PartialView("_Edit", request);

            var updated = await _userService.UpdateUserAsync(id, request);
            if (updated)
                return Json(new { success = true });

            return Json(new { success = false, message = "Failed to update user." });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return PartialView("_Delete", user);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _userService.DeleteUserAsync(id);
            if (deleted)
                return Json(new { success = true });

            return Json(new { success = false, message = "Failed to delete user." });
        }
    }
}
