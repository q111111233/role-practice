using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BasicAuthentication.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicAuthentication.Controllers
{
    public class TagController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TagController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);

            return View(_db.Tags.Where(x => x.User.Id == currentUser.Id));
        }
        public IActionResult Create()
        {
            ViewBag.TagId = new SelectList(_db.Images, "ImageId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tag tag)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            tag.User = currentUser;
            _db.Tags.Add(tag);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public IActionResult Delete(int imageId)
        //{
        //    var thisImage = _db.Images.FirstOrDefault(images => images.ImageId == imageId);
        //    return View(thisImage);
        //}
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteConfirmed(int imageId)
        //{
        //    var thisImage = _db.Images.FirstOrDefault(images => images.ImageId == imageId);
        //    _db.Images.Remove(thisImage);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
