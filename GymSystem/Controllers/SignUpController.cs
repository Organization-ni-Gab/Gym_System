using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


    public class SignupController : Controller
    {
    private readonly ISignupService _signupService;

    public SignupController(ISignupService signupService)
    {
        _signupService = signupService;
    }

        public async Task<IActionResult> List()
            {
                var signup = await _signupService.GetAllSignupsAsync();
                return View(signup);
            }

        [HttpGet]
        public async Task<IActionResult> Create ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create (Signup signup)
            {
               if (!ModelState.IsValid)
                return View(signup);

            await _signupService.AddSignupAsync(signup);
            return RedirectToAction(nameof(List));
            }
    }

