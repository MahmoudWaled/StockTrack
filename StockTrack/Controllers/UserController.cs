using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockTrack.Services.DTOs;
using StockTrack.Services.services.Interfaces;
using StockTrack.ViewModels;

namespace StockTrack.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        // Display the list of all users
        public async Task<IActionResult> Index()
        {
            var users = await userService.GetAllUsers();
            var mappedUsers = mapper.Map<List<UserVM>>(users);
            return View(mappedUsers);
        }

        // Show the form to add a new user
        public async Task<IActionResult> Add()
        {
            return View();
        }

        // Handle the submission of a new user
        [HttpPost]
        public async Task<IActionResult> Add(UserVM userVM)
        {
            if (!ModelState.IsValid)
            {
                return View(userVM);
            }

            var newUser = mapper.Map<UserDto>(userVM);
            await userService.Add(newUser);
            return RedirectToAction("Index");
        }

        // Display details of a specific user
        public async Task<IActionResult> ViewUser(int id)
        {
            var user = await userService.GetById(id);
            var mappedUser = mapper.Map<UserVM>(user);
            return View(mappedUser);
        }

        // Show the form to edit an existing user
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var user = await userService.GetById(id);
                var mappedUser = mapper.Map<UserVM>(user);
                return View(mappedUser);
            }
            catch (KeyNotFoundException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred while retrieving the user: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // Handle the submission of an updated user
        [HttpPost]
        public async Task<IActionResult> Edit(UserVM userVM)
        {
            if (!ModelState.IsValid)
            {
                return View(userVM);
            }

            try
            {
                var mappedUser = mapper.Map<UserDto>(userVM);
                await userService.Update(mappedUser);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred while updating the user: " + ex.Message;
                return View(userVM);
            }
        }
    }
}