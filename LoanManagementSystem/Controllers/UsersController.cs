﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoanManagementSystem.Models;
using System.Dynamic;
using NuGet.Packaging.Licenses;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using ReflectionIT.Mvc.Paging;
using X.PagedList;

namespace LoanManagementSystem.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly Context _context;

        public UsersController(Context context)
        {
            _context = context;
        }

        //  Users index
        public IActionResult Index(int? page /*string searchUsername*/)
        {
            try
            {
                //Pagination
                var pageNumber = page ?? 1;
                int pageSize = 4;
                var onePageofUsers =  _context.Users.ToPagedList(pageNumber, pageSize);
                
                // Search 
                //ViewData["SearchByUsername"]=searchUsername;
                //if (!string.IsNullOrEmpty(searchUsername))
                //{
                //    var checkUN =  _context.Users.Where(m => m.userName.Contains(searchUsername)).ToList();
                //    return View(checkUN);

                //}

                //var context = _context.Users.ToList();
                //return View(context);
                return  View(onePageofUsers);

                

            }
            catch (Exception Ex)
            {
                return View(Ex.Message);
            }

        }

        //[HttpGet]
        //public IActionResult Index(string searchUsername)
        //{
        //    ViewData["SearchByUsername"]=searchUsername;
        //    if (!string.IsNullOrEmpty(searchUsername))
        //    {
        //        var checkUN = _context.Users.Where(m => m.userName.Contains(searchUsername)).ToList();
        //        return View(checkUN);
        //    }
        //    return RedirectToAction("Index");
            
        //    //else
        //    //{
        //    //    ViewBag.searchError=$"User with {searchUsername} is not present in the list. Kindly check with valid user name.";
        //    //    return View();
        //    //}
        //}

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

        //  Add Users 
        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                var checkUsername = _context.Users.Any(u => u.userName == user.userName);
                if(checkUsername == true)
                {
                    ViewBag.userName=$"User name {user.userName} already in exist.Try with different User name.";
                    return View();
                }
                else
                {
                    var checkEmail = _context.Users.Any(x => x.emailID== user.emailID);
                    if (checkEmail == true)
                    {

                        ViewBag.Message=$"Email {user.emailID} is already in use.Try with different Email-Id.";
                        return View();
                    }
                    else
                    {
                        _context.Add(user);
                        _context.SaveChanges();
                        return RedirectToAction(nameof(Index));
                    }
                }
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
        public IActionResult Edit(int id, User user)
        {
            try
            {
                var checkUsername = _context.Users.Any(u => u.userName == user.userName);
                if (checkUsername == true)
                {
                    ViewBag.userName=$"User name {user.userName} already in exist.Try with different User name.";
                    return View();
                }
                else
                {
                    var checkEmail = _context.Users.Any(x => x.emailID== user.emailID);
                    if (checkEmail == true)
                    {
                        ViewBag.Message=$"Email{user.emailID} is already in use.Try with different Email-Id.";
                        return View();
                    }
                    else
                    {
                        _context.Update(user);
                        _context.SaveChanges();
                        return RedirectToAction(nameof(Index));

                    }
                }
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

