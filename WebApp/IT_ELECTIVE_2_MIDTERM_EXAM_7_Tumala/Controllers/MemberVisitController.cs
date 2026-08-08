using GymAttendanceSystem.Models;
using GymAttendanceSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymAttendanceSystem.Controllers
{
    [Authorize]
    public class MemberVisitController : Controller
    {
        private readonly IMemberVisitRepository _visitRepository;

        public MemberVisitController(IMemberVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        // List & Search[cite: 1]
        public IActionResult Index(string search)
        {
            ViewData["CurrentSearch"] = search;
            var visits = string.IsNullOrEmpty(search)
                ? _visitRepository.GetAll()
                : _visitRepository.Search(search);
            return View(visits);
        }

        // Details[cite: 1]
        public IActionResult Details(int id)
        {
            var visit = _visitRepository.GetById(id);
            if (visit == null) return NotFound();
            return View(visit);
        }

        // Register Visit (Create)[cite: 1]
        [HttpGet]
        public IActionResult Create() => View(new MemberVisit());

        [HttpPost]
        public IActionResult Create(MemberVisit visit)
        {
            if (ModelState.IsValid)
            {
                _visitRepository.Add(visit);
                return RedirectToAction(nameof(Index));
            }
            return View(visit);
        }

        // Edit Visit[cite: 1]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var visit = _visitRepository.GetById(id);
            if (visit == null) return NotFound();
            return View(visit);
        }

        [HttpPost]
        public IActionResult Edit(MemberVisit visit)
        {
            if (ModelState.IsValid)
            {
                _visitRepository.Update(visit);
                return RedirectToAction(nameof(Index));
            }
            return View(visit);
        }

        // Record Checkout[cite: 1]
        [HttpPost]
        public IActionResult CheckOut(int id)
        {
            _visitRepository.CheckOut(id);
            return RedirectToAction(nameof(Index));
        }
    }
}