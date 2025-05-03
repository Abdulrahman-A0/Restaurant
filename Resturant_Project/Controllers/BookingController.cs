using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Project.Data;
using Restaurant_Project.Models;
using Restaurant_Project.ViewModels;

namespace Restaurant_Project.Controllers
{
    public class BookingController : Controller
    {
        private readonly UserManager<User> userManager;
        private const int TotalTables = 20;

        private readonly AppDbContext _context;

        public BookingController(UserManager<User> userManager, AppDbContext context)
        {
            this.userManager = userManager;
            _context = context;
        }

        [Authorize]
        public IActionResult BookTable()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> BookTable(BookTableViewModel bookModel)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid data. Please check your inputs.");
                return View(bookModel);
            }


            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var startTime = bookModel.Date.Date + bookModel.Time;
                    var endTime = startTime.Add(TimeSpan.FromHours(bookModel.Duration));

                    var reservedTables = _context.Reservations
                        .Where(r => startTime < r.EndTime && endTime > r.StartTime)
                        .Sum(r => r.TableCount);

                    int availableTables = TotalTables - reservedTables;

                    if (availableTables < bookModel.TableCount)
                    {
                        ModelState.AddModelError("", $"Only {availableTables} tables available at this time.");
                        return View(bookModel);
                    }
                    var user = await userManager.GetUserAsync(User);

                    var reservation = new Reservation
                    {
                        UserId = user.Id,
                        StartTime = startTime,
                        EndTime = endTime,
                        Duration = TimeSpan.FromHours(bookModel.Duration),
                        TableCount = bookModel.TableCount,
                        Description = bookModel.Description,
                    };

                    _context.Reservations.Add(reservation);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    TempData["SuccessMessage"] = "Your table has been booked successfully!";
                    return View(bookModel);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    ModelState.AddModelError("", "Something went wrong. Please try again.");
                    return View(bookModel);
                }
            }

        }
    }
}
