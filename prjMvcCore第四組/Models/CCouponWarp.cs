using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace prjMvcCore第四組.Models
{
    public class CCouponWarp
    {
        private TCoupon _coupon;
        public TCoupon coupon
        {
            get { return _coupon; }
            set { _coupon = value; }
        }
        public CCouponWarp()
        {
            _coupon = new TCoupon();
        }

        [DisplayName("折價卷編號")]
        public int FCouponId
        {
            get { return _coupon.FCouponId; }
            set { _coupon.FCouponId = value; }
        }

        [DisplayName("商家編號")]
        public int? FSellerId
        {
            get { return _coupon.FSellerId; }
            set { _coupon.FSellerId = value; }
        }

        [DisplayName("活動名稱")]
        public string FName
        {
            get { return _coupon.FName; }
            set { _coupon.FName = value; }
        }

        [DisplayName("優惠碼")]
        public string? FCode
        {
            get { return _coupon.FCode; }
            set { _coupon.FCode = value; }
        }

        [DisplayName("適用範圍")]
        public string FScopeType
        {
            get { return _coupon.FScopeType; }
            set { _coupon.FScopeType = value; }
        }

        private static readonly Dictionary<string, string> _scopeTypeMap = new()
        {
            { "Shipping", "運費券" },
            { "Platform", "全站券" },
            { "Store", "賣場券" },
        };

        public List<SelectListItem> ScopeTypeOptions =>
            _scopeTypeMap.Select(kv => new SelectListItem { Value = kv.Key, Text = kv.Value }).ToList();

        [DisplayName("折抵類型")]
        public string FDiscountType
        {
            get { return _coupon.FDiscountType; }
            set { _coupon.FDiscountType = value; }
        }

        private static readonly Dictionary<string, string> _discountTypeMap = new()
        {
            { "Fixed", "固定金額" },
            { "Percentage", "比例折扣" },
        };

        public List<SelectListItem> DiscountTypeOptions =>
            _discountTypeMap.Select(kv => new SelectListItem { Value = kv.Key, Text = kv.Value }).ToList();

        [DisplayName("比例折抵值")]
        public decimal FDiscountValue
        {
            get { return _coupon.FDiscountValue; }
            set { _coupon.FDiscountValue = value; }
        }

        [DisplayName("最低消費門檻")]
        public decimal? FMinPurchaseAmount
        {
            get { return _coupon.FMinPurchaseAmount; }
            set { _coupon.FMinPurchaseAmount = value; }
        }

        [DisplayName("折抵上限")]
        public decimal? FMaxDiscountAmount
        {
            get { return _coupon.FMaxDiscountAmount; }
            set { _coupon.FMaxDiscountAmount = value; }
        }

        [DisplayName("活動開始日")]
        public DateTime FStartDate
        {
            get { return _coupon.FStartDate; }
            set { _coupon.FStartDate = value; }
        }

        [DisplayName("活動結束日")]
        public DateTime? FEndDate
        {
            get { return _coupon.FEndDate; }
            set { _coupon.FEndDate = value; }
        }

        [DisplayName("優惠卷狀態")]
        public bool? FIsActive
        {
            get { return _coupon.FIsActive; }
            set { _coupon.FIsActive = value; }
        }
    }
}