using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogApp.BLL.Services.IServices;
using BlogApp.BLL.ViewModels.Users;

namespace BlogApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// [Get] Метод, login
        /// </summary>
        [Route("Account/Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// [Post] Метод, login
        /// </summary>
        [Route("Account/Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Login(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        /// <summary>
        /// [Get] Метод, создания пользователя
        /// </summary>
        [Route("User/Create")]
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        /// <summary>
        /// [Post] Метод, создания пользователя
        /// </summary>
        [Route("User/Create")]
        [HttpPost]
        public async Task<IActionResult> AddUser(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUser(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("GetAccounts", "User");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        /// <summary>
        /// [Get] Метод, регистрации
        /// </summary>
        [Route("User/Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// [Post] Метод, регистрации
        /// </summary>
        [Route("User/Register")]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Register(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        /// <summary>
        /// [Get] Метод, редактирования аккаунта
        /// </summary>
        [Route("User/Edit")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> EditAccount(Guid id)
        {
            var model = await _userService.EditAccount(id);

            return View(model);
        }

        /// <summary>
        /// [Post] Метод, редактирования аккаунта
        /// </summary>
        [Route("User/Edit")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> EditAccount(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _userService.EditAccount(model);

                return RedirectToAction("GetAccounts", "User");
            }

            else
            {
                return View(model);
            }
        }

        /// <summary>
        /// [Get] Метод, удаление аккаунта
        /// </summary>
        [Route("User/Remove")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpGet]
        public async Task<IActionResult> RemoveAccount(Guid id, bool confirm = true)
        {
            if (confirm)

                await RemoveAccount(id);

            return RedirectToAction("GetAccounts", "User");
        }

        /// <summary>
        /// [Post] Метод, удаление аккаунта
        /// </summary>
        [Route("User/Remove")]
        [Authorize(Roles = "Администратор, Модератор")]
        [HttpPost]
        public async Task<IActionResult> RemoveAccount(Guid id)
        {
            var account = await _userService.GetAccount(id);

            await _userService.RemoveAccount(id);

            return RedirectToAction("GetAccounts", "User");
        }

        /// <summary>
        /// [Post] Метод, выхода из аккаунта
        /// </summary>
        [Route("User/Logout")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> LogoutAccount()
        {
            await _userService.LogoutAccount();

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// [Get] Метод, получения всех пользователей
        /// </summary>
        [Route("User/Get")]
        [Authorize(Roles = "Администратор, Модератор")]
        public async Task<IActionResult> GetAccounts()
        {
            var users = await _userService.GetAccounts();

            return View(users);
        }

        /// <summary>
        /// [Get] Метод, получения одного пользователя по Id
        /// </summary>
        [Route("User/Details")]
        [Authorize(Roles = "Администратор, Модератор")]
        public async Task<IActionResult> DetailsAccount(Guid id)
        {
            var model = await _userService.GetAccount(id);

            return View(model);
        }
    }
}
