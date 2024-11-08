using eApplication.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using eApplication.Data.Services;
using eApplication.Models;

namespace eApplication.Controllers
{
    public class ActorsController : Controller
    {

        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service=service;


        }




        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();


            return View(data);
        }
        public IActionResult Create()
        {
            


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName", "ProfilePictureName", "Bio")] Actor actor)
        {

            if (!ModelState.IsValid)
            {
                return View(actor);
            }

           await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetByIdAsync(id);

            if(data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if(data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id","FullName", "ProfilePictureName", "Bio")] Actor actor)
        {

            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
