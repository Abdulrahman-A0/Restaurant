using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Project.Data;
using Restaurant_Project.Models;
using Restaurant_Project.ViewModels;

namespace Restaurant_Project.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> userManager;

        public CartController(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        public IActionResult Cart()
        {
            var userId = userManager.GetUserId(User);
            var cart = _context.Carts.FirstOrDefault(c => c.UserId == userId);
            List<CartItem> cartItemsModel = new List<CartItem>();
            if (cart != null)
            {
                cartItemsModel = cartItemsModel = _context.CartItems
                                                .Where(c => c.CartId == cart.Id)
                                                .Include(c => c.Dish)
                                                .ToList();
            }

            decimal subtotal = cartItemsModel.Sum(item => item.UnitPrice * item.Quantity);
            decimal shipping = 10;
            decimal total = subtotal + shipping;

            var cartViewModel = new CartViewModel
            {
                CartItems = cartItemsModel,
                Subtotal = subtotal,
                Shipping = shipping,
                Total = total
            };

            return View(cartViewModel);
        }
        [Authorize]
        public IActionResult AddToCart(int dishId)
        {

            var userId = userManager.GetUserId(User);

            var dish = _context.Dishes.FirstOrDefault(d => d.Id == dishId);
            if (dish == null)
            {
                return NotFound();
            }

            var cart = _context.Carts.FirstOrDefault(c => c.UserId == userId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    CartItems = new List<CartItem>()
                };
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }

            var existingCartItem = _context.CartItems
                                   .FirstOrDefault(ci => ci.CartId == cart.Id && ci.DishId == dishId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += 1;
                _context.CartItems.Update(existingCartItem);
            }
            else
            {
                var cartItem = new CartItem
                {
                    Quantity = 1,
                    UnitPrice = dish.Price,
                    DishId = dish.Id,
                    CartId = cart.Id
                };

                _context.CartItems.Add(cartItem);
            }

            _context.SaveChanges();
            return RedirectToAction("Menu", "Menu");
        }

        public IActionResult Remove(int cartItemId)
        {
            var cartItem = _context.CartItems.FirstOrDefault(c => c.Id == cartItemId);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();
            }
            return RedirectToAction("Cart");
        }
        [HttpPost]
        public IActionResult Checkout()
        {
            var userId = userManager.GetUserId(User);
            var cart = _context.Carts.FirstOrDefault(c => c.UserId == userId);
            if (cart == null)
                return RedirectToAction("Cart");

            var cartItems = _context.CartItems.Where(c => c.CartId == cart.Id).ToList();
            if (!cartItems.Any())
                return RedirectToAction("Cart");

            var order = new Order
            {
                UserId = userId,
                Amount = cartItems.Sum(x => x.Quantity),
                Date = DateTime.Now,
                Status = false,
                Details = new List<OrderDetail>()
            };

            foreach (var item in cartItems)
            {
                var detail = new OrderDetail
                {
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    DishId = item.DishId,
                };
                order.Details.Add(detail);
            }

            var payment = new Payment
            {
                PaymentMethod = PaymentMethod.Cash,
                Status = false,
                Order = order,
                TotalPayment = cartItems.Sum(x => x.UnitPrice * x.Quantity) + 10 //+10 shipping
            };

            _context.Orders.Add(order);
            _context.Payments.Add(payment);
            _context.CartItems.RemoveRange(cartItems);
            _context.Carts.Remove(cart);

            _context.SaveChanges();
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public JsonResult UpdateCartItem(int cartItemId, int quantity)
        {
            var cartItem = _context.CartItems.FirstOrDefault(x => x.Id == cartItemId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                _context.SaveChanges();
            }

            var userId = userManager.GetUserId(User);
            var cart = _context.Carts.FirstOrDefault(c => c.UserId == userId);
            var cartItems = _context.CartItems.Where(c => c.CartId == cart.Id).ToList();

            decimal subtotal = cartItems.Sum(x => x.UnitPrice * x.Quantity);
            decimal shipping = 10;
            decimal total = subtotal + shipping;

            return Json(new { subtotal = subtotal, total = total });
        }

    }
}
