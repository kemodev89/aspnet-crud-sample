using Microsoft.AspNetCore.Mvc;
using aspnet_crud_sample.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnet_crud_sample.Controllers {
    public class UsersController : Controller {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index() {
            return View(await _context.Users.ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(User user) {
            if (ModelState.IsValid) {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(int id) {
            var user = await _context.Users.FindAsync(id);
            return user == null ? NotFound() : View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user) {
            if (ModelState.IsValid) {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(int id) {
            var user = await _context.Users.FindAsync(id);
            return user == null ? NotFound() : View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var user = await _context.Users.FindAsync(id);
            if (user != null) {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
