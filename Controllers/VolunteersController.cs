using MvcEventVolunteeringDemo.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MvcEventVolunteeringDemo.Controllers
{
	public class VolunteersController : Controller
	{
		private SrvContext db = new SrvContext();

		// GET: Volunteers
		public ActionResult Index()
		{
			return View(db.Volunteers.ToList());
		}

		// GET: Volunteers/Edit/{id}
		public ActionResult Edit(int? id)
		{
			Volunteer volunteer = db.Volunteers.Find(id);
			ViewBag.Title = "Volunteers : Add";
			ViewBag.IsEdit = false;
			if (volunteer != null)
			{
				ViewBag.Title = "Volunteers : Edit";
				ViewBag.IsEdit = true;
				return View(volunteer);
			}
			return View();
		}

		// POST: Volunteers/Edit/{id}
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "VolunteerID, FirstName, LastName, Username, Phone, DateOfBirth, IsFemale, Address, City, State, Zip, IsActive")] Volunteer volunteer)
		{
			//if (ModelState.IsValid)
			{
				if (volunteer.VolunteerID > 0)
				{
					db.Entry(volunteer).State = EntityState.Modified;
				}
				else
				{
					db.Volunteers.Add(volunteer);
				}
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			//return View(volunteer);
		}

		// GET: Volunteers/Delete/{id}
		public ActionResult Delete(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			Volunteer volunteer = db.Volunteers.Find(id);
			if (volunteer == null)
				return HttpNotFound();
			return View(volunteer);
		}

		// POST: Volunteers/Delete/{id}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Volunteer volunteer = db.Volunteers.Find(id);
			db.Volunteers.Remove(volunteer);
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
