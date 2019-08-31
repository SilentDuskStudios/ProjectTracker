using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Models;
using ProjectTracker.Models.DataContext;

namespace ProjectTracker.Controllers
{
    [Route("task")]
    public class IssueController : Controller
    {
        private readonly IssueDataContext _db;

        public IssueController(IssueDataContext db)
        {
            _db = db;
        }

        #region " - - - - - - Index - - - - - - "

        [HttpGet, Route("")]
        public IActionResult Index()
        {
            var issues = _db.Issues.ToList();

            return View(issues);
        }

        #endregion

        #region " - - - - - - Create - - - - - - "
        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View("IssueCreate");
        }

        [HttpPost, Route("create")]
        public IActionResult Create(Issue issue)
        {
            //DateStart & Status should not be edited by the user upon creation.
            issue.DateStart = DateTime.Now;
            issue.Status = StatusEnum.NotStarted;

            _db.Issues.Add(issue);
            _db.SaveChanges();

            return RedirectToAction("Index", "Issue");
        }
        #endregion

        #region " - - - - - - Read - - - - - - "

        [HttpGet, Route("read/{id}")]
        public IActionResult Read(int id)
        {
            var issue = _db.Issues.FirstOrDefault(x => x.ID == id);

            return View("IssueRead", issue);
        }

        #endregion

        #region " - - - - - - Update - - - - - - "

        [HttpGet, Route("edit/{id}")]
        public IActionResult Update(int id)
        {
            var issue = _db.Issues.FirstOrDefault(x => x.ID == id);

            return View("IssueUpdate", issue);
        }

        [HttpPost, Route("edit/{id}")]
        public IActionResult Update(Issue updatedIssue)
        {
            var issue = _db.Issues.FirstOrDefault(x => x.ID == updatedIssue.ID);
            issue.Summary = updatedIssue.Summary;
            issue.Priority = updatedIssue.Priority;
            issue.DateDue = updatedIssue.DateDue;
            issue.Status = updatedIssue.Status;

            _db.SaveChanges();

            return RedirectToAction("Read", new { id = issue.ID });
        }

        #endregion

        #region " - - - - - - Delete - - - - - - "

        //Delete action only works when set as HttpGet. Not sure why as its a POST.
        [HttpGet, Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var issue = _db.Issues.FirstOrDefault(x => x.ID == id);

            _db.Issues.Remove(issue);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion
    }
}