using Microsoft.AspNetCore.Mvc;

namespace GymSystem.Controllers
{
    public class WalkInController : Controller
    {
        private readonly IWalkInService _WalkInService;
        private static DateTime _dateToday;
        
        public WalkInController(IWalkInService WalkInService)
        {
            _WalkInService = WalkInService;

        }

        public void setViewBag()
        {
            _dateToday = DateTime.Now;
            ViewBag.dateToday = _dateToday;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var WalkIns = await _WalkInService.getAllWalkInAsyn();
            return View(WalkIns);
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

            var WalkIn = await _WalkInService.GetIdWalkInAsync(id);  
            if(WalkIn == null)
                return NotFound();
            
            return View(WalkIn);
        }




        [HttpPost]
        public async Task<IActionResult> Edit(WalkIn WalkIn)
        {

            if (ModelState.IsValid)
            {
                var success = await _WalkInService.UpdateWalkInAsync(WalkIn);
                if (!success)
                    return BadRequest("request failed!!!");
                return RedirectToAction("List");
            }
            else
            {  //if editing is invalid need to return view with validation
                return View(WalkIn);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _WalkInService.DeleteWalkInAsync(id);
            if (isSuccess)
            {
                TempData["SuccessMessage"] = "WalkIn has been deleted";
                return RedirectToAction("List");
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to Delete WalkIn";
            }
            return RedirectToAction("List");
        }


        [HttpPost]
        public async Task<IActionResult> Create(WalkIn WalkIn)
        {
            if(ModelState.IsValid)
            {
                var success = await _WalkInService.InsertWalkInAsync(WalkIn);
                if (!success)
                    return BadRequest("request failed!!!");
                return RedirectToAction("List");
            }
            else  //if entry is invalid return view with validation
                return View(WalkIn);
                
        }

       
    }
}
