using ECommerce3.DataLayer.Repositories;
using ECommerce3.EntityLayer;
using ECommerce3.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce3.Controllers
{
    public class UserManagementController : Controller
    {
        IRepository<User> userRepository;

        public UserManagementController()
        {
            userRepository = new UserRepository();
        }
        // GET: UserManagement
        public ActionResult Index()
        {
            IEnumerable<User> users = userRepository.GetAll();
            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            UserVM uservm = new UserVM();
            return View(uservm);
        }

        [HttpPost]
        public ActionResult Create(UserVM uservm)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Name = uservm.Name,
                    Email = uservm.Email,
                    DOB = uservm.DOB,
                    Mobile = uservm.Mobile,
                    Status = 1,
                    Gender = uservm.Gender,
                    Password = uservm.password,
                    RoleId = uservm.RoleId

                };
                User result = userRepository.Add(user);
                return RedirectToAction("Index");
            }
            else
            {
                return View(uservm);
            }
                
        }

        public ActionResult SearchByName()
        {
            string name = Request.Form["txtname"];
            IEnumerable<User> users=userRepository.GetByName(name);
            return View("Index",users);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            User user = userRepository.GetById(id);
            UserVM uservm = new UserVM()
            {
                Id = user.Id,
                Name = user.Name,
                DOB = user.DOB,
                Email = user.Email,
                Mobile = user.Mobile,
                RoleId = user.RoleId,
                Gender=user.Gender,
                password=user.Password,
            };
            return View(uservm);
        }
       

    }
}