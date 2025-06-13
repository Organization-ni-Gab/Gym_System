using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
public class CoachController : Controller
    {
    private readonly ICoachService _CoachService;
    private readonly GymSystemDbContext _GymDb;

    public CoachController(ICoachService coachservice, GymSystemDbContext gymDbContext)
    {
        _CoachService = coachservice;
        _GymDb = gymDbContext;
    }

        public async Task <IActionResult> List()
        {
        var coach = await _CoachService.GetAllCoachAsync();
            return View(coach);
        }

        [HttpGet]
        public async Task<IActionResult> Create ()
        {
        var branches = await _GymDb.Branch.ToListAsync();
        ViewBag.Branch = new SelectList(branches, "BranchID", "BranchName");

        return View();
        }

        [HttpPost]
            public async Task <IActionResult> Create (Coach coach)
            {
            var result = await _CoachService.CreateCoachAsync(coach);

            var branches = await _GymDb.Branch.ToListAsync();
            ViewBag.Branch = new SelectList(branches, "BranchID", "BranchName");
            return RedirectToAction("List");
            }

            [HttpGet]
            public async Task<IActionResult> Edit (int id)
            {

                var coach = await _CoachService.GetCoachID(id);
                if (coach == null)
                    return NotFound();
                return View(coach);
            }

            [HttpPost]
            public async Task<IActionResult> Edit(Coach coach)
            {

                if (ModelState.IsValid)
                {
                    var success = await _CoachService.UpdateCoachAsync(coach);
                    if (!success)
                        return BadRequest("request failed!!!");
                    return RedirectToAction("List");
                }
                else
                {  //if editing is invalid need to return view with validation
                    return View(coach);
                }
        
            }

    [HttpPost]


        [HttpPost]
        public async Task<IActionResult> DeleteCoach (int id)
        {
            var isSuccess = await _CoachService.DeleteCoachAsync(id);

                if (isSuccess)
                {
                TempData["SuccessMessage"] = "Student has been deleted";
                return RedirectToAction("List");
                } else
                {
            TempData["ErrorMessage"] = "Failed to Delete Coach";
                }
                return RedirectToAction ("List");
        }

    }

