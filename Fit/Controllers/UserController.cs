using Fit.ViewModels.User;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Fit.Controllers
{
    public class UserController : Controller
    {
        private readonly UserLogic _userLogic = new UserLogic();
        private AuthController _auth = new AuthController();
        // GET
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            var user = _auth.IsLoggedIn(HttpContext);
            ViewData["AuthUser"] = user;
            
            
            UserListViewModel viewModel = new UserListViewModel();
            viewModel.AllUsers = _userLogic.GetAll();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _userLogic.GetBy(id);
            
            UserEditViewModel viewModel = new UserEditViewModel();
            viewModel = user as UserEditViewModel;
            viewModel.Rights = 
            
            return View(viewModel);
        }
        
    }
}