using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using prjMvcCore第四組.Models;
using prjMvcCore第四組.Models;
using prjMvcCore第四組.ViewModels;
using System.Security.Claims;

namespace prjMvcCore第四組.Controllers
{
    public class TripController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(CRestaurantViewModel vm)
        {
            MidprjDb2Context db = new MidprjDb2Context();
            var datas = db.TTrips.Include(t => t.FUsers).ToList();
            DateTime now = DateTime.Now;
            bool isUpdated = false;
            List<CTripWrap> list = new List<CTripWrap>();
            foreach (var black in datas)
            {
                CTripWrap blue = new CTripWrap() { Trip = black };
                if (blue.StatusEnum != CTripWrap.TripStatus.已結束 && blue.FCreatedTime.AddSeconds(30) <= now)
                {
                    blue.StatusEnum = CTripWrap.TripStatus.已結束;
                    blue.Trip.FUpdatedTime = now;
                    isUpdated = true;
                }

                list.Add(blue);
            }

            if (isUpdated)
            {
                db.SaveChanges();
            }

            return View(list);
        }

        public IActionResult Create()
        {
            MidprjDb2Context db = new MidprjDb2Context();
            CTripWrap cTrip = new CTripWrap();
            cTrip.Restaurants = db.TRestaurants.Select(t => new SelectListItem
            {
                Value = t.FRestaurantId.ToString(),
                Text = t.FName
            }).ToList();
            return View(cTrip);
        }

        [HttpPost]
        public IActionResult Create(CTripWrap cTrip, string submitButton)
        {
            MidprjDb2Context db = new MidprjDb2Context();

            if (submitButton == "儲存為草稿")
            {
                cTrip.StatusEnum = CTripWrap.TripStatus.草稿;
            }
            else if (submitButton == "新增行程")
            {
                cTrip.StatusEnum = CTripWrap.TripStatus.已完成;
            }

            cTrip.Trip.FCreatedTime = DateTime.Now;

            cTrip.Trip.FUsersId = 1;
            db.TTrips.Add(cTrip.Trip);
            db.SaveChanges();
            if (cTrip.SelectedRestaurantIds != null && cTrip.SelectedRestaurantIds.Count > 0)
            {
                int sortOrder = 1;
                foreach (var restId in cTrip.SelectedRestaurantIds)
                {
                    var tripRest = new TTripRestaurant
                    {
                        FTripId = cTrip.Trip.FTripId,
                        FRestaurantId = restId,
                        FSortOrder = sortOrder++,
                        FCreatedTime = DateTime.Now
                    };
                    db.TTripRestaurants.Add(tripRest);
                }
                db.SaveChanges();
            }
            cTrip.Restaurants = db.TRestaurants
            .Select(r => new SelectListItem
            {
                Value = r.FRestaurantId.ToString(),
                Text = r.FName
            }).ToList();


            return RedirectToAction("List");

        }

        public IActionResult Delete(int? id)
        {
            MidprjDb2Context db = new MidprjDb2Context();
            TTrip trip = db.TTrips.FirstOrDefault(t => t.FTripId == id);
            if (id != null)
            {
                db.TTrips.Remove(trip);
                db.SaveChanges();
            }


            return RedirectToAction("List");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            MidprjDb2Context db = new MidprjDb2Context();
            TTrip Trip = db.TTrips.FirstOrDefault(t =>t.FTripId == id);

            if (Trip == null)
                return RedirectToAction("List");
            CTripWrap cTrip = new CTripWrap();
            cTrip.Restaurants = db.TRestaurants.Select(t => new SelectListItem
            {
                Value = t.FRestaurantId.ToString(),
                Text = t.FName
            }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Edit(CTripWrap cTrip , string submitButton)
        {
            MidprjDb2Context db = new MidprjDb2Context();

            if (submitButton == "儲存為草稿")
            {
                cTrip.StatusEnum = CTripWrap.TripStatus.草稿;
            }
            else if (submitButton == "新增行程")
            {
                cTrip.StatusEnum = CTripWrap.TripStatus.已完成;
            }

            TTrip trip = db.TTrips.FirstOrDefault(t => t.FTripId == cTrip.FTripId);
            if (trip != null)
            {
                trip.FTripName = cTrip.FTripName;
                trip.FTripDate = cTrip.FTripDate;
                trip.FDescription = cTrip.FDescription;
                trip.FStartTime = cTrip.FStartTime;
                trip.FStatus = cTrip.FStatus;
            }


            return RedirectToAction("List");
        }
    }
}

