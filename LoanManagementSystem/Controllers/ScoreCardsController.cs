using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Controllers
{
    public class ScoreCardsController : Controller
    {
        private readonly Context _context;

        public ScoreCardsController(Context context)
        {
            _context = context;
        }

        // Index Scorecards
        public  IActionResult Index()
        {
            try
            {
                var scCards = _context.ScoreCards.ToList();
                return View(scCards);
            }
            catch(Exception Ex)
            {
                return View(Ex.Message);
            }
           
        }

        // Details function to check individual detail of score card
        public IActionResult Details(int id)
        {
            try
            {
                var scoreCard =  _context.ScoreCards.FirstOrDefault(m => m.scID == id);
                return View(scoreCard);
            }
            catch (Exception Ex)
            {
                return View(Ex.Message);
            }
            
        }

        // To get create page
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

       // To Add new score card
        [HttpPost]
        public IActionResult Create([Bind("scID,name,age,minIncome,maxIncome,stateId,acntId,minLoanamt,maxLoanamt,routingBlcklst,zipcodeBlcklst")] ScoreCard scoreCard)
        {
            try
            {
                _context.Add(scoreCard);
                _context.SaveChanges();
               return RedirectToAction(nameof(Index));

            }
            catch (Exception Ex)
            {
                return View(Ex.Message);
            }
               
        }

        // GET ScoreCards to Edit by Id
        public IActionResult Edit(int id)
        {
            try
            {
                var scoreCard =  _context.ScoreCards.Find(id);

                ViewData["acntId"] = new SelectList(_context.Accounts, "aID", "aID", scoreCard.acntId);
                ViewData["stateId"] = new SelectList(_context.States, "sID", "sID", scoreCard.stateId);
                return View(scoreCard);
            }
            catch(Exception Ex)
            {
                return View(Ex.Message);
            }
        }

        // POST  ScoreCards to Edit by
        [HttpPost]
        public IActionResult Edit(int id, [Bind("scID,name,age,minIncome,maxIncome,stateId,acntId,minLoanamt,maxLoanamt,routingBlcklst,zipcodeBlcklst")] ScoreCard scoreCard)
        {
            try
            {
                _context.Update(scoreCard);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
                ViewData["acntId"] = new SelectList(_context.Accounts, "aID", "aID", scoreCard.acntId);
                ViewData["stateId"] = new SelectList(_context.States, "sID", "sID", scoreCard.stateId);
                return View(scoreCard);
            }
            catch (Exception Ex)
            {
                return View(Ex.Message);
            }
        }

        // ScoreCards Delete/5
        public IActionResult Delete(int id)
        {
            try
            {
                var scoreCard = _context.ScoreCards.FirstOrDefault(m => m.scID == id);
                return View(scoreCard);
            }
           catch(Exception Ex)
            {
                return View(Ex.Message);
            }
        }

        //  ScoreCards Delete by Id
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var scoreCard = _context.ScoreCards.Find(id);
                if (scoreCard != null)
                {
                    _context.ScoreCards.Remove(scoreCard);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception Ex)
            {
                return View(Ex.Message);
            }
           
        }

      
    }
}
