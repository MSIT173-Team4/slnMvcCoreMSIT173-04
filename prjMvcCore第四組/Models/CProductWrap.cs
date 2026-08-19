using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace prjMvcCore第四組.Models
{
    public class CProductWrap
{
        private TProduct _product;
        public TProduct product//封裝
        {
            get { return _product; }
            set { _product = value; }
        }
        public CProductWrap()//建構子，利用建構子把全堿變數new起來
        {
            _product = new TProduct();
        }
        public int FProductId 
        {
            get { return _product.FProductId; }//右手傳出給黑框
            set { _product.FProductId = value; }//紫色左手接進來是set
         }

        [DisplayName("產品編號")]
        public string FProductNo 
        {
            get { return _product.FProductNo; }
            set { _product.FProductNo = value; }
        }

        [DisplayName("商家編號")]
        public int FSellerId {
            get { return _product.FSellerId; }
            set { _product.FSellerId = value; }
        }
        
        [DisplayName("產品類別編號")]
        public int FProductsCategoryId {
            get { return _product.FProductsCategoryId; }
            set { _product.FProductsCategoryId = value; }
        }

        public List<SelectListItem>? CategoryOptions { get; set; }

        [DisplayName("產品名稱")]
        public string FProductname {
            get { return _product.FProductname; }
            set { _product.FProductname = value; }
        }
        
        [DisplayName("產品描述")]
        public string? FDescription {
            get { return _product.FDescription; }
            set { _product.FDescription = value; }
        }
        
        [DisplayName("庫存數量")]
        public int FStock {
            get { return _product.FStock; }
            set { _product.FStock = value; }
        }
        
        [DisplayName("產品單價")]
        public decimal FPrice {
            get { return _product.FPrice; }
            set { _product.FPrice = value; }
        }
        
        [DisplayName("品牌")]
        public int? FBrandId {
            get { return _product.FBrandId; }
            set { _product.FBrandId = value; }
        }
        public List<SelectListItem>? BrandOptions { get; set; }

        [DisplayName("生產日期")]
        [DataType(DataType.Date)]
        public DateOnly FManufacturingDate {
            get { return _product.FManufacturingDate; }
            set { _product.FManufacturingDate = value; }
        }
        
        [DisplayName("有效期限")]
        [DataType(DataType.Date)]
        public DateOnly? FExpirationDate {
            get { return _product.FExpirationDate; }
            set { _product.FExpirationDate = value; }
        }
        
        [DisplayName("上架日期")]
        public DateTime FProductDate {
            get { return _product.FProductDate; }
            set { _product.FProductDate = value; }
        }
        
        [DisplayName("其他產品資訊")]
        public string? FAttributesJson {
            get { return _product.FAttributesJson; }
            set { _product.FAttributesJson = value; }
        }

        /// <summary>
        /// 商品狀態：0 審核中 / 1 架上商品 / 2 已售完 / 3 未上架 / 4 已違規
        /// </summary>
        [DisplayName("商品狀態代碼")]
        public byte? FProductStatus {
            get { return _product.FProductStatus; }
            set { _product.FProductStatus = value; }
        }

        private static readonly Dictionary<byte, string> _statusMap = new()
        {
            { 0, "審核中" },
            { 1, "架上商品" },
            { 2, "已售完" },
            { 3, "未上架" },
            { 4, "已違規" },
        };

        [DisplayName("商品狀態")]
        public string FProductStatusText => this.FProductStatus switch
        {
            null => "未設定",
            byte b when _statusMap.TryGetValue(b, out var text) => text,
            _ => "未知狀態"
        };

        public List<SelectListItem> FProductStatusOptions =>
            _statusMap
                .OrderBy(kv => kv.Key)
                .Select(kv => new SelectListItem
                {
                    Value = kv.Key.ToString(),
                    Text = $"{kv.Key} {kv.Value}"
                })
                .ToList();


        [DisplayName("被檢舉次數")]
        public int FReportCount {
            get { return _product.FReportCount; }
            set { _product.FReportCount = value; }
        }

        
    }
}
