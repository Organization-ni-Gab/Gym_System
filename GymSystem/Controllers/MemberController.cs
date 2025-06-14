using Microsoft.AspNetCore.Mvc;

namespace GymSystem.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private static DateTime _dateToday;
        
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;

        }

        public void setViewBag()
        {
            _dateToday = DateTime.Now;
            ViewBag.dateToday = _dateToday;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var members = await _memberService.getAllMemberAsyn();
            return View(members);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            setViewBag();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var member = await _memberService.GetIdMemberAsync(id);  
            if(member == null)
                return NotFound();
            
            return View(member);
        }




        [HttpPost]
        public async Task<IActionResult> Edit(Member member)
        {

            if (ModelState.IsValid)
            {
                var success = await _memberService.UpdateMemberAsync(member);
                if (!success)
                    return BadRequest("request failed!!!");
                return RedirectToAction("List");
            }
            else
            {  //if editing is invalid need to return view with validation
                return View(member);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _memberService.DeleteMemberAsync(id);
            if (isSuccess)
            {
                TempData["SuccessMessage"] = "Member has been deleted";
                return RedirectToAction("List");
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to Delete Member";
            }
            return RedirectToAction("List");
        }


        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
            if(ModelState.IsValid)
            {
                var success = await _memberService.InsertMemberAsync(member);
                if (!success)
                    return BadRequest("request failed!!!");
                return RedirectToAction("List");
            }
            else  //if entry is invalid return view with validation
                return View(member);
                
        }

       
    }
}
