using MvcEventVolunteeringDemo.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MvcEventVolunteeringDemo.Controllers
{
	public class EventsController : Controller
	{
		private SrvContext db = new SrvContext();

		// GET: Events
		public ActionResult Index()
		{
			return View(db.Events.ToList());
		}

		// GET: Events/Edit/{id}
		public ActionResult Edit(int? id)
		{
			Event @event = db.Events.Find(id);
			ViewBag.Title = "Events : Add";
			ViewBag.IsEdit = false;
			if (@event != null)
			{
				ViewBag.Title = "Events : Edit";
				ViewBag.IsEdit = true;
				return View(@event);
			}
			return View();
		}

		// POST: Events/Edit/{id}
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "EventID, StartDate, EndDate, Title, Description, Capacity, VolunteersRequired, VenueAddress, VenueCity, VenueState, VenueZip, VenuePhone, IsActive")] Event @event)
		{
			//if (ModelState.IsValid)
			{
				string StartTime = string.Empty;
				string EndTime = string.Empty;
				int startHour = 0;
				int startMinutes = 0;
				int endHour = 0;
				int endMinutes = 0;
				StartTime = Request.Form["StartTime"];
				EndTime = Request.Form["EndTime"];
				startHour = int.Parse(StartTime.Split(':')[0]);
				startMinutes = int.Parse(StartTime.Split(':')[1]);
				endHour = int.Parse(EndTime.Split(':')[0]);
				endMinutes = int.Parse(EndTime.Split(':')[1]);
				@event.StartTime = (new DateTime(1999, 12, 31, startHour, startMinutes, 0));
				@event.EndTime = (new DateTime(1999, 12, 31, endHour, endMinutes, 0));
				if (@event.EventID > 0)
				{
					//Event dEvent = db.Events.Find(@event.EventID);
					//@event.StartDate = dEvent.StartDate;
					//@event.StartTime = dEvent.StartTime;
					//@event.EndDate = dEvent.EndDate;
					//@event.EndTime = dEvent.EndTime;
					//dEvent = null;
					db.Entry(@event).State = EntityState.Modified;
				}
				else
				{
					db.Events.Add(@event);
				}
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			//return View(volunteer);
		}

		// GET: Events/Delete/{id}
		public ActionResult Delete(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			Event @event = db.Events.Find(id);
			if (@event == null)
				return HttpNotFound();
			return View(@event);
		}

		// POST: Events/Delete/{id}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Event @event = db.Events.Find(id);
			db.Events.Remove(@event);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
