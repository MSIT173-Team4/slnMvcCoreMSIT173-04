using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using prjMvcCore第四組.Models;
using prjMvcCore第四組.ViewModels;
using prjMvcCore第四組.Models;

namespace prjMvcCore第四組.Controllers{
    public class RestaurantController : Controller{

        
        public IActionResult Index()
        {
                
            return View(); 
        }
        public IActionResult List(CRestaurantViewModel vm)
        {
            string keyword = vm.txtkeyword;
            MidprjDb2Context db = new MidprjDb2Context();
            var datas = db.TRestaurants.Include(t => t.FCategory).AsQueryable();
            
            List<CRestaurantWrap> list = new List<CRestaurantWrap>();
            if (string.IsNullOrEmpty(keyword))
            {
                datas = from t in datas select t;
            }
            else
            {
                datas = datas.Where
                    (
                        t => t.FName.Contains(keyword) ||
                        t.FAddress.Contains(keyword)
                    );
            }
            foreach (var black in datas) 
            { 
                CRestaurantWrap blue = new CRestaurantWrap() {Restaurant = black }; 
                list.Add(blue);
            }
            return View(list);
            
        }
        public IActionResult Create() 
        {
            MidprjDb2Context db = new MidprjDb2Context();
            CRestaurantWrap cp = new CRestaurantWrap();
            cp.CategoryOptions = db.TRestaurantCategories.Select(c => new SelectListItem
            {
                Value = c.FCategoryId.ToString(),
                Text = c.FCategoryName

            }).ToList();
            return View(cp);
        }

        [HttpPost]
        public IActionResult Create(CRestaurantWrap cp)
        {
            
            if (cp.FName == null)
            {
                return View();
            }
            MidprjDb2Context db = new MidprjDb2Context();
            if (string.IsNullOrEmpty(cp.Restaurant.FGooglePlaceId))
            {
                cp.Restaurant.FGooglePlaceId = Guid.NewGuid().ToString("N");
                /* 取得或產生的有效值，例如從表單或Google API */
                ;
            }
            db.TRestaurants.Add(cp.Restaurant);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int? id) 
        {
            MidprjDb2Context db = new MidprjDb2Context();
            TRestaurant restaurant = db.TRestaurants.FirstOrDefault(t => t.FRestaurantId == id);
            if (id != null) {
                db.TRestaurants.Remove(restaurant);
                db.SaveChanges();
            }
            
            
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            MidprjDb2Context db = new MidprjDb2Context();
            TRestaurant restaurant = db.TRestaurants.FirstOrDefault(t => t.FRestaurantId == id);
            
            if (restaurant == null)
                return RedirectToAction("List");
            CRestaurantWrap cp = new CRestaurantWrap();
            cp.CategoryOptions = db.TRestaurantCategories.Select(c => new SelectListItem
            {
                Value = c.FCategoryId.ToString(),
                Text = c.FCategoryName

            }).ToList();
            cp.Restaurant = restaurant;

            return View(cp);
        }

        [HttpPost]
        public IActionResult Edit(CRestaurantWrap cp)
        {
            MidprjDb2Context db = new MidprjDb2Context();
            TRestaurant restaurant = db.TRestaurants.FirstOrDefault(t => t.FRestaurantId == cp.FRestaurantId);
            if (restaurant != null)
            {
                restaurant.FName = cp.FName;
                restaurant.FCategory = cp.FCategory;
                restaurant.FAddress = cp.FAddress;
                restaurant.FPhone = cp.FPhone;
                restaurant.FDescription = cp.FDescription;
                restaurant.FBusinessStatus = cp.FBusinessStatus;
                restaurant.FIsRecommend = cp.FIsRecommend;


               
                db.SaveChanges();
            }
                
            
            return RedirectToAction("List");
        }
    }
}

