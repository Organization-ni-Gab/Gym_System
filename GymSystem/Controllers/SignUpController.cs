using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;

namespace GymSystem.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ISignUpService _signUpService;
        private readonly IMemberService _memberService;
        private readonly IWalkInService _walkInService;



        private static IEnumerable<SignUp> _signUp;
        public static DateTime _dateToday;
        public static string _message;
        
        public SignUpController(ISignUpService signUpService,IMemberService memberService,IWalkInService walkInService)
        {
            _signUpService = signUpService;
            _memberService = memberService;
            _walkInService = walkInService;

        }

        public  void setViewBag()
        {
            _dateToday = DateTime.Now;
            ViewBag.dateToday = _dateToday;
            ViewBag.message = _message;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
           // _message = "list...";
            setViewBag();
            var allSignUp = await _signUpService.getAllSignUpAsyn();
            return View(allSignUp);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
           // _message = "creating... pre";
            setViewBag();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            setViewBag();
            var signUp = await _signUpService.GetIdSignUpAsync(id);
            if(signUp == null)
                return NotFound();
            
            return View(signUp);
        }




        [HttpPost]
        public async Task<IActionResult> Edit(SignUp signUp)
        {
            setViewBag();
            if (ModelState.IsValid)
            {
                var success = await _signUpService.UpdateSignUpAsync(signUp);
                if (!success)
                    return BadRequest("request failed!!!");
                return RedirectToAction("List");
            }
            else
            {  //if editing is invalid need to return view with validation
                return View(signUp);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            
            var isSuccess = await _signUpService.DeleteSignUpAsync(id);
            if (isSuccess)
            {
                TempData["SuccessMessage"] = "It has been deleted";
                return RedirectToAction("List");
                _message = "delete sucessfully";
                setViewBag();
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to Delete";
                _message = "failed to delete";
                setViewBag();
            }
            
            return RedirectToAction("List");
        }


        [HttpPost]
        public async Task<IActionResult> Create(SignUp signUp)
        {
           // _message = "creating... post";
            setViewBag();
            if (ModelState.IsValid)
            {
                //private key identity remove set to manual
                var selectAll = await _signUpService.getAllSignUpAsyn();
                int customerId = selectAll.Count();
                signUp.CustomerId = customerId;

                var success = await _signUpService.InsertSignUpAsync(signUp);

                if (success)
                {
                         
                    // create a member record if member is true
                    if(signUp.isMember ==1)
                    {
                        Member newMember = new Member();
                        newMember.CustomerId = signUp.CustomerId;
                        newMember.FirstName = signUp.FirstName;
                        newMember.MiddleName = signUp.MiddleName;
                        newMember.LastName = signUp.LastName;
                        newMember.Gender = signUp.Gender;
                        newMember.PlanId = signUp.PlanId;
                        newMember.ExpiryDate = signUp.ExpiryDate;
                        newMember.JoinDate = signUp.JoinDate;
                        newMember.isMember = signUp.isMember;

                        var isSuccess = await _memberService.InsertMemberAsync(newMember);
                        if (isSuccess)
                        {
                            return RedirectToAction("List");
                        }
                        else
                            return BadRequest("request failed!!!");
                    }
                    if (signUp.isMember == 0)
                    {
                        WalkIn newWalkIn = new WalkIn();
                        newWalkIn.CustomerId = signUp.CustomerId;
                        newWalkIn.FirstName = signUp.FirstName;
                        newWalkIn.MiddleName = signUp.MiddleName;
                        newWalkIn.LastName = signUp.LastName;
                        newWalkIn.Gender = signUp.Gender;
                        newWalkIn.PlanId = signUp.PlanId;
                        newWalkIn.ExpiryDate = signUp.ExpiryDate;
                        newWalkIn.JoinDate = signUp.JoinDate;
                        newWalkIn.isMember = signUp.isMember;

                        var isSuccess = await _walkInService.InsertWalkInAsync(newWalkIn);
                        if (isSuccess)
                        {
                            return RedirectToAction("List");
                        }
                        else
                            return BadRequest("request failed!!!");
                    }
                    else
                        return BadRequest("request failed!!!");

                }
                else
                {                    
                    return BadRequest("request failed!!!");
                }
            }
            else  //if entry is invalid return view with validation
                return View(signUp);
        }

       
    }
}
