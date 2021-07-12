using Exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Exam.Controllers
{
    public class TheActivityController : Controller
    {
        private MyContext _context;
        private int? uid
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
        }
        private bool isLoggedIn
        {
            get { return uid != null; }
        }

        // here we can "inject" our context service into the constructor
        public TheActivityController(MyContext context)
        {
            _context = context;
        }
        [HttpGet("home")]
        public IActionResult Dashboard()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            // query all Weddings and user info and Guest
            List<TheActivity> allActivities = _context
                .Activities.OrderBy(n => n.Date)   // gets all TheActivity and properties
                .Include(m => m.CreatedBy) // grab CreatedBy nav property
                .Include(m => m.Members)  // grab Members nav property
                .ToList();
            // call user info and put in viewBag
            User u = _context.Users.FirstOrDefault(u => u.UserId == (int)uid);
            ViewBag.User = u;
            return View(allActivities);
        }
        [HttpGet("new")]
        public IActionResult NewActivity()  // Render page with form
        {
            // call user info and put in viewBag
            User u = _context.Users.FirstOrDefault(u => u.UserId == (int)uid);
            ViewBag.User = u;
            return View();
        }
        [HttpPost("postactivity")]
        public IActionResult PostActivity(TheActivity activity)
        {
            // check date if in past
            if (activity.Date.Year < DateTime.Now.Year )
            {
                ModelState.AddModelError("Date", "Release Date must be in the Future");
            }
            // run validation
            if (ModelState.IsValid)
            {
                // store Activity in db
                activity.UserId = (int)uid;
                _context.Activities.Add(activity);
                _context.SaveChanges();
                return Redirect($"/activity/{activity.TheActivityId}");
                // this below one does the same thing
                
            }
            User u = _context.Users.FirstOrDefault(u => u.UserId == (int)uid);
            ViewBag.User = u;
            return View("NewActivity");
        }

        [HttpGet("activity/{activityId}")]
        public IActionResult Activities(int activityId)
        {
            // query the TheActivity by id
            TheActivity thisActivity = _context
            .Activities
            .Include(m => m.CreatedBy)
            .Include(m => m.Members)
            .ThenInclude(f => f.Member)
            .FirstOrDefault(m => m.TheActivityId == activityId);
            // call user info and put in viewBag
            User u =_context.Users.FirstOrDefault(u => u.UserId == (int)uid);
            ViewBag.User = u;
            return View(thisActivity);
        }
        [HttpGet("delete/{activityId}")]  // activityId has to match the asp-route-movieId
        public IActionResult Delete(int activityId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            // query Activities db by id
           TheActivity delActivity = _context.Activities.FirstOrDefault(m => m.TheActivityId ==  activityId);
            // remove from db
            _context.Activities.Remove(delActivity);
            // save changes
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpGet("join/{activityId}")]
        public IActionResult Join(int activityId)
        {
            // create new Participant instance
            Participant join = new Participant();
            // reassign UserId and activityId
            join.UserId = (int)uid;
            join.TheActivityId = activityId;
            // Add to Guests table in db
            _context.Participants.Add(join);
            // save changes
            _context.SaveChanges();
            // redirect dashboard
            return RedirectToAction("Dashboard");
        }
        [HttpGet("leave/{activityId}")]
        public IActionResult Leave(int activityId)
        {
            // query Participant from db
            // must match the activityId and userId in the 1 Participant relationship
            Participant leave = _context.Participants.FirstOrDefault(g => g.MemberOf.TheActivityId == activityId && g.Member.UserId == (int)uid);
            // remov from Participant table in db
            _context.Participants.Remove(leave);
            // save changes
            _context.SaveChanges();
            // redirect dashboard
            return RedirectToAction("Dashboard");
        }
    }
}