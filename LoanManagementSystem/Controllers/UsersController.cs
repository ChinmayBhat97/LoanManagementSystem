using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoanManagementSystem.Models;
using System.Dynamic;
using NuGet.Packaging.Licenses;

namespace LoanManagementSystem.Controllers
{
    public class UsersController : Controller
    {
        private readonly Context _context;

        public UsersController(Context context)
        {
            _context = context;
        }

        //  Users index
        public IActionResult Index()
        {
            try
            {
                var context = _context.Users.ToList();
                return View(context);
            }
            catch (Exception Ex)
            {
                return View(Ex.Message);
            }

        }



        //  Users Create page
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception Ex)
            {
                return View(Ex.Message);
            }

        }

        //  Add Users Users
        [HttpPost]
        public IActionResult Create([Bind("Id,firstName,lastName,userName,passWord,emailID,roleId,activeStatus")] User user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception Ex)
            {
                return View(Ex.Message);
            }
        }

        //  Users Edit by Id
        public IActionResult Edit(int? id)
        {
            try
            {
                //dynamic myModel = new ExpandoObject();
                //myModel.Roles;
                 

                var user = _context.Users.Find(id);
                ViewData["roleId"] = new SelectList(_context.Roles, "rId", "rId", user.roleId);
                return View(user);
            }
            catch (Exception Ex)
            {
                return View(Ex.Message);
            }

        }


        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,firstName,lastName,userName,passWord,emailID,roleId,activeStatus")] User user)
        {
            try
            {
                _context.Update(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
                ViewData["roleId"] = new SelectList(_context.Roles, "rId", "rId", user.roleId);
                return View(user);

            }
            catch (Exception Ex)
            {
                return View(Ex.Message);
            }
        }
        // Delete User by Id
        public IActionResult Delete(int? id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(m => m.Id == id);
                return View(user);
            }
            catch(Exception Ex)
            {
                return View(Ex.Message);
            }
           

        }

        // dELETE User by Id
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var user = _context.Users.Find(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                }

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception Ex)
            {
                return View(Ex.Message);
            }
           
        }

       
    }

   
}

