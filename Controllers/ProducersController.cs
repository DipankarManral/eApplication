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
    public class ProducersController : Controller
    {

        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;


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
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
        {

            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id", "FullName", "ProfilePictureName", "Bio")] Producer Producer)
        {

            if (!ModelState.IsValid)
            {
                return View(Producer);
            }

            await _service.UpdateAsync(id, Producer);
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
