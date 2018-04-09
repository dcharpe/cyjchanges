using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CYJ.Models;

namespace CYJ.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {

            return View();
        }
    
        public ActionResult Added()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult ServiceDelivery()
        {
            return View();
        }

     
        public ActionResult CorpMemberExperience()
        {
            return View();
        }
        public ActionResult ExternalAffairs()
        {
            return View();
        }
        public ActionResult Revenue()
        {
            return View();
        }
        public ActionResult OpEx()
        {
            return View();
        }
        public ActionResult RAD()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            using (cyjEntities dc = new cyjEntities())
            {
                var events = dc.CALENDARs.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpPost]
        public JsonResult SaveEvent(CALENDAR e)
        {
            var status = false;
            using (cyjEntities dc = new cyjEntities())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = dc.CALENDARs.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.isFullDay = e.isFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    dc.CALENDARs.Add(e);
                }
                dc.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (cyjEntities dc = new cyjEntities())
            {
                var v = dc.CALENDARs.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.CALENDARs.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}