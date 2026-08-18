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
        public long FTripId
        {
            get { return _trip.FTripId; }
            set { _trip.FTripId = value; }
        }

        public int FUsersId
        {
            get { return _trip.FUsersId; }
            set { _trip.FUsersId = value; }
        }
        [DisplayName("行程名稱")]
        public string FTripName
        {
            get { return _trip.FTripName; }
            set { _trip.FTripName = value; }
        }
        [DisplayName("行程日期")]
        public DateOnly FTripDate
        {
            get { return _trip.FTripDate; }
            set { _trip.FTripDate = value; }
        }
        [DisplayName("開始時間")]
        public TimeOnly? FStartTime
        {
            get { return _trip.FStartTime; }
            set { _trip.FStartTime = value; }
        }
        [DisplayName("行程描述")]
        public string? FDescription
        {
            get { return _trip.FDescription; }
            set { _trip.FDescription = value; }
        }
        [DisplayName("行程規劃狀態")]
        public string FStatus
        {
            get { return _trip.FStatus; }
            set { _trip.FStatus = value; }
        } 
        [DisplayName("新增日期")]
        public DateTime FCreatedTime
        {
            get { return _trip.FCreatedTime; }
            set { _trip.FCreatedTime = value; }
        }
        [DisplayName("最後更新日期")]
        public DateTime? FUpdatedTime
        {
            get { return _trip.FUpdatedTime; }
            set { _trip.FUpdatedTime = value; }
        }

        public virtual TUser FUsers
        {
            get { return _trip.FUsers; }
            set { _trip.FUsers = value; }
        }

        public virtual ICollection<TTripRestaurant> TTripRestaurants
        {
            get ; 
            set ; 
        } = new List<TTripRestaurant>();

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
