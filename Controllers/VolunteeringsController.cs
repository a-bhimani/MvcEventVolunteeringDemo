using MvcEventVolunteeringDemo.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MvcEventVolunteeringDemo.Controllers
{
	public class VolunteeringsController : Controller
	{
		private SrvContext db = new SrvContext();

		// GET: Volunteerings
		public ActionResult Index()
		{
			var volunteerings = db.Volunteerings
															.Include(v => v.Event)
															.Include(v => v.Volunteer)
															.OrderBy(e => e.Event.StartDate)
															.OrderBy(e => e.Event.Title);
			ViewBag.Error = TempData["ErrorMessage"];
			return View(volunteerings.ToList());
		}

		// GET: Volunteerings/Create
		public ActionResult Create()
		{
			ViewBag.Title = "Assignments : Assign Volunteer to an Event";
			ViewBag.EventID = new SelectList(db.Events
																					.Where(el => el.IsActive
																													&&
																												(el.EndDate > DateTime.Now)), "EventID", "Title");
			ViewBag.VolunteerID = new SelectList(db.Volunteers
																								.Where(el => el.IsActive), "VolunteerID", "Username");
			return View();
		}

		// POST: Volunteerings/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Remarks, EventID, VolunteerID")] Volunteering volunteering)
		{
			bool b = true;

			//assign datetime from event
			Event evt = db.Events.Find(volunteering.EventID);
			volunteering.BeginDate = evt.StartDate;
			volunteering.BeginTime = evt.StartTime;
			volunteering.EndDate = evt.EndDate;
			volunteering.EndTime = evt.EndTime;

			//check for datetime conflicts as required!
			//check for datetime conflicts as required!
			//check for datetime conflicts as required!
			//check for datetime conflicts as required!
			foreach (Volunteering vs in db.Volunteerings
																			.Where(el => (el.VolunteerID == volunteering.VolunteerID)))
			{
				DateTime startDate = new DateTime(vs.BeginDate.Year, vs.BeginDate.Month, vs.BeginDate.Day, vs.BeginTime.Hour, vs.BeginTime.Minute, vs.BeginTime.Second);
				DateTime endDate = new DateTime(vs.EndDate.Year, vs.EndDate.Month, vs.EndDate.Day, vs.EndTime.Hour, vs.EndTime.Minute, vs.EndTime.Second);
				DateTime startCompareDate = new DateTime(volunteering.BeginDate.Year, volunteering.BeginDate.Month, volunteering.BeginDate.Day, volunteering.BeginTime.Hour, volunteering.BeginTime.Minute, volunteering.BeginTime.Second);
				DateTime endCompareDate = new DateTime(volunteering.EndDate.Year, volunteering.EndDate.Month, volunteering.EndDate.Day, volunteering.EndTime.Hour, volunteering.EndTime.Minute, volunteering.EndTime.Second);
				if ((startCompareDate >= startDate && startCompareDate <= endDate)
								||
							(endCompareDate >= startDate && endCompareDate <= endDate))
				{
					b = false;
				}
			}

			if (!b)
			{
				TempData["ErrorMessage"] = "This Volunteer has already been assigned to another event within this time slot.";
				return RedirectToAction("Index");
			}

			//duplicates
			if (db.Volunteerings.Where(el => (el.VolunteerID == volunteering.VolunteerID)
																					&&
																				(el.EventID == volunteering.EventID)).Count() > 0)
			{
				TempData["ErrorMessage"] = "The Volunteer has already been assigned to the Event.";
				return RedirectToAction("Index");
			}

			if (ModelState.IsValid)
			{
				db.Volunteerings.Add(volunteering);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.EventID = new SelectList(db.Events, "EventID", "Title", volunteering.EventID);
			ViewBag.VolunteerID = new SelectList(db.Volunteers, "VolunteerID", "FirstName", volunteering.VolunteerID);
			return View(volunteering);
		}

		// GET: Volunteerings/Delete/{id}
		public ActionResult Delete(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			Volunteering volunteering = db.Volunteerings.Find(id);
			if (volunteering == null)
				return HttpNotFound();
			return View(volunteering);
		}

		// POST: Volunteerings/Delete/{id}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Volunteering volunteering = db.Volunteerings.Find(id);
			db.Volunteerings.Remove(volunteering);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
				db.Dispose();
			base.Dispose(disposing);
		}
	}
}
