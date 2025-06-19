using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


    public class SignupController : Controller
    {
    private readonly ISignupService _signupService;

    private static string _message = "";

    public SignupController(ISignupService signupService)
    {
        _signupService = signupService;
    }

        private void setViewBag()
        {
            ViewBag.Message = _message;
        }
        public async Task<IActionResult> List()
        {
        if (_message == "") { _message = "welcome to the list of customers"; }
        
        setViewBag();
            
            var signup = await _signupService.GetAllSignupsAsync();
            return View(signup);
        }

        [HttpGet]
        public async Task<IActionResult> Create ()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var signupId = await _signupService.getIdSignUpAsync(id);
            return View(signupId);
        }

        [HttpPost]

    public async Task<IActionResult> Edit(Signup signup)
    {
        if(ModelState.IsValid)
        {
            var isSuccess = await _signupService.updateSignUp(signup);
            if (isSuccess) 
            {
                // need to add code if ismember has changed to for membership need to show form for membership
                if(signup.isMember == 1)
                {

                }

                _message = $"Customer named {signup.FirstName}'s record updated successfully.";
                setViewBag();
                return RedirectToAction("List");
            } 
                
        }
        _message = $"Customer named {signup.FirstName}'s record failed to update.";
        setViewBag();
        return View(signup);
    }
        public async Task<IActionResult> Create (Signup signup)
        {
            if (!ModelState.IsValid)
            {
                return View(signup);
            }
    // await _signupService.AddSignupAsync(signup);
            _message = $"Customer Named {signup.FirstName} Added Sucessfully";
            setViewBag();

            await _signupService.AddSignupAndWalkinAsync(signup);
            return RedirectToAction(nameof(List));
        }
    [HttpPost]
    public async Task<IActionResult> Delete(Signup signup)
        {
            string deleteIds = "";

            if (signup.checkBoxId != null)
            {
                foreach (var id in signup.checkBoxId)
                {
                deleteIds += id.ToString() + ",";
                }

                var isSuccess = await _signupService.DeleteMultipleSignUpAsync(deleteIds);
               _message = $"Customer IDs {deleteIds} Deleted Sucessfully";
            setViewBag();
            return RedirectToAction(nameof(List));
            }

           _message = "Opps!!! select Customer to delete.";
            setViewBag();

        return RedirectToAction(nameof(List));
        }

  
}

