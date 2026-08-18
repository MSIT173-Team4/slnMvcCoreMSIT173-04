namespace prjMvcCore第四組.Models
{
    public partial class TProduct
{
        public string FProductStatusText => FProductStatus switch
        {
            0 => "審核中",
            1 => "架上商品",
            2 => "已售完",
            3 => "未上架",
            4 => "已違規",
            null => "未設定",
            _ => "未知狀態"
        };
    }
}
