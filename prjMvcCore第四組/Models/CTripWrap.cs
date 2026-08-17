using Microsoft.AspNetCore.Mvc.Rendering;
using prjMvcCore第四組.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace prjMvcCore第四組.Models
{
    public class CTripWrap
    {
        public enum TripStatus
        {
            草稿 = 0,
            已完成 = 1,
            已結束 = 2
        }

        private TTrip _trip;
        
        public TTrip Trip {
            get { return _trip; }
            set { _trip = value; }
        }
        public CTripWrap() 
        {
            _trip = new TTrip();
        }

        [Key]
        public long FTripId { get; set; }

        public int FUsersId { get; set; }
        [DisplayName("行程名稱")]
        public string FTripName { get; set; } = null!;
        [DisplayName("行程日期")]
        public DateOnly FTripDate { get; set; }
        [DisplayName("開始時間")]
        public TimeOnly? FStartTime { get; set; }
        [DisplayName("行程描述")]
        public string? FDescription { get; set; }
        [DisplayName("行程規劃狀態")]
        public string FStatus { get; set; } = null!;
        [DisplayName("新增日期")]
        public DateTime FCreatedTime { get; set; }
        [DisplayName("最後更新日期")]
        public DateTime? FUpdatedTime { get; set; }

        public virtual TUser FUsers { get; set; } 

        public virtual ICollection<TTripRestaurant> TTripRestaurants { get; set; } = new List<TTripRestaurant>();

        public TripStatus StatusEnum
        {
            get
            {
                if (Enum.TryParse<TripStatus>(FStatus, out var result))
                {
                    return result;
                }
                return TripStatus.草稿; // 預設值
            }
            set
            {
                FStatus = value.ToString(); // 自動將 Enum 名稱 (如 "草稿") 轉成字串存入 FStatus
            }
        }

        public IEnumerable<SelectListItem> StatusSelectList
        {
            get
            {
                return Enum.GetValues(typeof(TripStatus))
                           .Cast<TripStatus>()
                           .Select(e => new SelectListItem
                           {
                               Text = e.ToString(),
                               Value = e.ToString(),
                               Selected = (e.ToString() == FStatus) // 自動選取當前狀態
                           });
            }
        }

        public List<SelectListItem> Restaurants { get; set; } = new List<SelectListItem>();
        // 接收前端傳回來的餐廳選擇結果 (按排序順序傳回 RestaurantID)
        public List<long> SelectedRestaurantIds { get; set; } = new List<long>();
    }
}
