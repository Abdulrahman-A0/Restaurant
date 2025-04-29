using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Project.Data;
using Restaurant_Project.Models;
using Restaurant_Project.ViewModels;

namespace Restaurant_Project.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> userManager;

        public UserController(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await userManager.GetUserAsync(User);
            var model = new UserProfileViewModel
            {
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                Image = user.Image,
                Email = user.Email

            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserProfileViewModel userModel, IFormFile Image)
        {
            ModelState.Remove("OldPassword");
            ModelState.Remove("NewPassword");
            ModelState.Remove("Email");
            ModelState.Remove("Image");

            var oldUser = await userManager.GetUserAsync(User);

            if (Image != null && Image.Length > 0)
            {
                var allowedTypes = new[] { "image/jpeg", "image/png", "image/gif", "image/jpg" };

                if (!allowedTypes.Contains(Image.ContentType))
                {
                    ModelState.AddModelError("Image", "Upload Only An Image");
                    return RedirectToAction("Profile");
                }
                // var filePath = Path.GetTempFileName();

                var fileName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\img", fileName);
                var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\img", oldUser.Image);


                using (var stream = System.IO.File.Create(filePath))
                {
                    Image.CopyTo(stream);
                }

                if (System.IO.File.Exists(oldPath) && !oldPath.Contains("DefaultUserImg.png"))
                {
                    System.IO.File.Delete(oldPath);

                }
                userModel.Image = fileName;
            }
            else
            {

                userModel.Image = oldUser.Image;
            }

            if (!ModelState.IsValid)
                return RedirectToAction("Profile");


            oldUser.Name = userModel.Name;
            oldUser.PhoneNumber = userModel.PhoneNumber;
            oldUser.Address = userModel.Address;
            oldUser.Image = userModel.Image;

            _context.Users.Update(oldUser);
            _context.SaveChanges();
            return RedirectToAction("Profile");

        }
        [HttpPost]
        public async Task<IActionResult> UpdatePassword(UserProfileViewModel userModel)
        {
            ModelState.Remove("Email");
            ModelState.Remove("Name");
            ModelState.Remove("Image");
            ModelState.Remove("Address");
            ModelState.Remove("PhoneNumber");
            var user = await userManager.GetUserAsync(User);

            if (!ModelState.IsValid)
            {
                userModel.Name = user.Name;
                userModel.PhoneNumber = user.PhoneNumber;
                userModel.Address = user.Address;
                userModel.Email = user.Email;
                userModel.Image = user.Image;

                return View("Profile", userModel);
            }


            var passwordCheck = await userManager.CheckPasswordAsync(user, userModel.OldPassword);
            if (!passwordCheck)
            {
                ModelState.AddModelError("OldPassword", "Old Password isn't correct");
                userModel.Name = user.Name;
                userModel.PhoneNumber = user.PhoneNumber;
                userModel.Address = user.Address;
                userModel.Email = user.Email;
                userModel.Image = user.Image;
                return View("Profile", userModel);
            }

            var result = await userManager.ChangePasswordAsync(user, userModel.OldPassword, userModel.NewPassword);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                userModel.Name = user.Name;
                userModel.PhoneNumber = user.PhoneNumber;
                userModel.Address = user.Address;
                userModel.Email = user.Email;
                userModel.Image = user.Image;

                return View("Profile", userModel);
            }

            TempData["SuccessMessage"] = "Password Changed Successfully";
            return RedirectToAction("Profile");
        }
    }
}
