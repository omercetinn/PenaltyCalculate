using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PenaltyCalculate.Models;

namespace PenaltyCalculate.Controllers
{
    public class PenaltyCalculate : Controller
    {
        // GET: Reader
        DataContext c = new DataContext();
        public ActionResult Index()
        {
            var reader = c.UserInformations.ToList();
            return View(reader);
        }

        [HttpPost]
        public ActionResult ReaderAdd(UserInformation u)
        {
            u.Status = true;
            c.UserInformations.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReaderDelete(int id)
        {
            var urn = c.UserInformations.Find(id);
            urn.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ReaderView(int id)
        {
            var reader = c.UserInformations.Find(id);
            return View("ReaderView", reader);
        }

        public ActionResult ReaderUpdate(UserInformation u)
        {

            var r = c.UserInformations.Find(u.Id);

            var dates = Enumerable.Range(0, (int)(r.ReturnDate - r.ReceivedDate).TotalDays + 1)
                  .Select(e => new
                  {
                      Tarih = r.ReceivedDate.AddDays(e)
                  });

            var days = new DayOfWeek[] {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday
            };

            var filter = dates.Where(d => days.Contains(d.Tarih.DayOfWeek));
            r.Name = u.Name;
            r.Surname = u.Surname;
            r.ReceivedDate = u.ReceivedDate;
            r.ReturnDate = u.ReturnDate;
            r.WorkDayNumber = Convert.ToInt32(filter);
            r.DelayedTime = u.DelayedTime;
            r.PenaltyMoney = 10 * Convert.ToInt32(filter);
            r.Country = u.Country;
            r.Status = true;

            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult ReaderList()
        {
            var readers = c.UserInformations.ToList();
            return View(readers);
        }

    }

}
