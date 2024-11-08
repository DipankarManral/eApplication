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
    public class CinemasController : Controller
    {

        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();/*Query only hits the db when we
                                                            use ToList or FirstorDefault 
                                                            something like that */

            return View(data);
        } 

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details (int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _service.UpdateAsync(id, cinema);
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
        [HttpPost, ActionName("Delete")]
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

