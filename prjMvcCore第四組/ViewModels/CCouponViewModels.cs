namespace prjMvcCore第四組.ViewModels
{
    public class CCouponViewModels
{
        public string txtKeyword { get; set; }
        public string SearchType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public string ScopeType { get; set; }
        public string DiscountType { get; set; }
        public decimal? MinPurchaseAmountFrom { get; set; }
        public decimal? MinPurchaseAmountTo { get; set; }
        public decimal? MaxDiscountAmountFrom { get; set; }
        public decimal? MaxDiscountAmountTo { get; set; }

    }
}
