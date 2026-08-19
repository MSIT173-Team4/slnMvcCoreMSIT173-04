using Microsoft.AspNetCore.Mvc;
using prjMvcCore第四組.Models;
using prjMvcCore第四組.ViewModels;

namespace prjMvcCore第四組.Controllers
{
    public class CouponController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(CCouponViewModels vm)
        {
            MidprjDb2Context db = new MidprjDb2Context();
            IQueryable<TCoupon> query = db.TCoupons;

            if (!string.IsNullOrEmpty(vm.txtKeyword))
            {
                switch (vm.SearchType)
                {
                    case "couponId":
                        if (int.TryParse(vm.txtKeyword, out int couponId))
                            query = query.Where(c => c.FCouponId == couponId);
                        break;
                    case "sellerId":
                        if (int.TryParse(vm.txtKeyword, out int sellerId))
                            query = query.Where(c => c.FSellerId == sellerId);
                        break;
                    case "name":
                        query = query.Where(c => c.FName.Contains(vm.txtKeyword));
                        break;
                    case "code":
                        query = query.Where(c => c.FCode != null && c.FCode.Contains(vm.txtKeyword));
                        break;
                }
            }

            if (!string.IsNullOrEmpty(vm.ScopeType))
                query = query.Where(c => c.FScopeType.Contains(vm.ScopeType));

            if (!string.IsNullOrEmpty(vm.DiscountType))
                query = query.Where(c => c.FDiscountType.Contains(vm.DiscountType));

            if (vm.StartDate.HasValue)
                query = query.Where(c => c.FStartDate >= vm.StartDate.Value);

            if (vm.EndDate.HasValue)
                query = query.Where(c => c.FEndDate == null || c.FEndDate <= vm.EndDate.Value);

            if (vm.IsActive.HasValue)
                query = query.Where(c => c.FIsActive == vm.IsActive.Value);

            if (vm.MinPurchaseAmountFrom.HasValue)
                query = query.Where(c => c.FMinPurchaseAmount == null || c.FMinPurchaseAmount >= vm.MinPurchaseAmountFrom.Value);
            if (vm.MinPurchaseAmountTo.HasValue)
                query = query.Where(c => c.FMinPurchaseAmount == null || c.FMinPurchaseAmount <= vm.MinPurchaseAmountTo.Value);

            // 沒設定折抵上限（NULL，代表無上限）的優惠券一併顯示
            if (vm.MaxDiscountAmountFrom.HasValue)
                query = query.Where(c => c.FMaxDiscountAmount == null || c.FMaxDiscountAmount >= vm.MaxDiscountAmountFrom.Value);
            if (vm.MaxDiscountAmountTo.HasValue)
                query = query.Where(c => c.FMaxDiscountAmount == null || c.FMaxDiscountAmount <= vm.MaxDiscountAmountTo.Value);

            List<CCouponWarp> wrapList = query
                .ToList()
                .Select(c => new CCouponWarp { coupon = c })
                .ToList();

            return View(wrapList);
        }

        public IActionResult Create()
        {
            var cw = new CCouponWarp();
            cw.FStartDate = DateTime.Now;
            return View(cw);
        }

        [HttpPost]
        public IActionResult Create(CCouponWarp cw)
        {
            ValidateCoupon(cw);

            if (!ModelState.IsValid)
            {
                return View(cw);
            }

            MidprjDb2Context db = new MidprjDb2Context();
            db.TCoupons.Add(cw.coupon);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult ToggleStatus(int id)
        {
            using var db = new MidprjDb2Context();
            var coupon = db.TCoupons.FirstOrDefault(c => c.FCouponId == id);
            if (coupon == null)
            {
                return NotFound();
            }

            coupon.FIsActive = !(coupon.FIsActive ?? false);

            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            MidprjDb2Context db = new MidprjDb2Context();
            TCoupon x = db.TCoupons.FirstOrDefault(c => c.FCouponId == id);
            if (x == null)
                return RedirectToAction("List");
            CCouponWarp cw = new CCouponWarp();
            cw.coupon = x;
            return View(cw);
        }

        [HttpPost]
        public ActionResult Edit(CCouponWarp cw)
        {
            ValidateCoupon(cw);

            if (!ModelState.IsValid)
            {
                return View(cw);
            }

            MidprjDb2Context db = new MidprjDb2Context();
            TCoupon couponDb = db.TCoupons.FirstOrDefault(c => c.FCouponId == cw.FCouponId);
            if (couponDb == null)
                return RedirectToAction("List");

            couponDb.FSellerId = cw.FSellerId;
            couponDb.FName = cw.FName;
            couponDb.FCode = cw.FCode;
            couponDb.FScopeType = cw.FScopeType;
            couponDb.FDiscountType = cw.FDiscountType;
            couponDb.FDiscountValue = cw.FDiscountValue;
            couponDb.FMinPurchaseAmount = cw.FMinPurchaseAmount;
            couponDb.FMaxDiscountAmount = cw.FMaxDiscountAmount;
            couponDb.FStartDate = cw.FStartDate;
            couponDb.FEndDate = cw.FEndDate;
            couponDb.FIsActive = cw.FIsActive;

            db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            using var db = new MidprjDb2Context();
            var coupon = db.TCoupons.FirstOrDefault(c => c.FCouponId == id);
            if (coupon == null)
            {
                return NotFound();
            }

            db.TCoupons.Remove(coupon);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        // Create、Edit 兩個 POST 共用的防呆驗證
        private void ValidateCoupon(CCouponWarp cw)
        {
            if (string.IsNullOrEmpty(cw.FScopeType))
                ModelState.AddModelError(nameof(cw.FScopeType), "請選擇適用範圍");

            if (string.IsNullOrEmpty(cw.FDiscountType))
                ModelState.AddModelError(nameof(cw.FDiscountType), "請選擇折抵類型");

            if (cw.FDiscountType == "Percentage" && (cw.FDiscountValue <= 0 || cw.FDiscountValue > 1))
            {
                ModelState.AddModelError(nameof(cw.FDiscountValue), "比例折扣請輸入 0～1 之間的小數（例如打 85 折請輸入 0.85）");
            }
            else if (cw.FDiscountType == "Fixed" && cw.FDiscountValue <= 0)
            {
                ModelState.AddModelError(nameof(cw.FDiscountValue), "固定金額折扣請輸入大於 0 的數值");
            }
        }
    }
}