using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistration.Models;
using UserRegistration.Repository;

namespace UserRegistration.Controllers
{
    public class UserController : Controller
    {
        UserRepository _userRepository = new UserRepository();
        // GET: User
        public ActionResult Index()
        {
            var userList = _userRepository.GetAllUsers();
            if (userList.Count == 0)
            {
                TempData["InfoMessage"] = "No users avilable";
            }
            return View(userList);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var userList = _userRepository.GetUserById(id).FirstOrDefault();
            if (userList == null)
            {
                TempData["InfoMessage"] = "no user registered on this id";
                return RedirectToAction("Index");
            }
            return View(userList);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View(new User());
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                // TODO: Add insert logic here

                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid user data.");
                    return View(new User()); // Prevent null reference error
                }
                if (user.Password != user.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "Passwords do not match");
                }
                if (ModelState.IsValid)
                {
                    bool isAdded = _userRepository.AddUser(user);
                    if (isAdded)
                    {
                        TempData["SuccessMessage"] = "User added succesfull";
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(user);
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _userRepository.GetUserById(id).FirstOrDefault();
            if (user == null)
            {
                TempData["ErrorMessage"] = "user not avilable";
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    bool isAdded = _userRepository.UpdateUser(user);
                    if (isAdded)
                    {
                        TempData["SuccessMessage"] = "User added succesfull";
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(user);
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = _userRepository.GetUserById(id).FirstOrDefault();
            if (user == null)
            {
                TempData["ErrorMessage"] = "user not avilable";
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {
                // TODO: Add delete logic here
                string result = _userRepository.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
