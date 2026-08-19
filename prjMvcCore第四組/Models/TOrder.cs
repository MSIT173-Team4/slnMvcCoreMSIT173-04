using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models;

public partial class TOrder
{
    public long FOrderId { get; set; }

    public string FOrderNo { get; set; } = null!;

    public int FUsersId { get; set; }

    public int FSellerId { get; set; }

    public DateTime FOrderDate { get; set; }

    public decimal FShippingFee { get; set; }

    public decimal FShippingDiscount { get; set; }

    public decimal FProductDiscount { get; set; }

    public decimal FTotalAmount { get; set; }

    public string FRecipientName { get; set; } = null!;

    public string FRecipientPhone { get; set; } = null!;

    public string FShippingAddress { get; set; } = null!;

    public string FShippingMethod { get; set; } = null!;

    /// <summary>
    /// 賣家是否已確認/列印出貨單（0 未確認 1 已確認/已列印）
    /// </summary>
    public bool FIsShippingConfirmed { get; set; }

    /// <summary>
    /// 訂單狀態：0 待處理 / 1 已成立 / 2 已完成 / 3 已取消
    /// </summary>
    public int FOrderStatus { get; set; }

    /// <summary>
    /// 付款狀態：0 待付款 / 1 已付款 / 2 待退款 / 3 已退款
    /// </summary>
    public int FPaymentStatus { get; set; }

    /// <summary>
    /// 運送狀態：0 待出貨 / 1 運送中 / 2 已送達 / 3 運送失敗 / 4 退回包裹運送中 / 5 賣家已取回退件
    /// </summary>
    public int FShippingStatus { get; set; }

    /// <summary>
    /// 取消狀態：0 無取消申請 / 1 待回覆 / 2 已取消 / 3 拒絕取消
    /// </summary>
    public int FCancellationStatus { get; set; }

    /// <summary>
    /// 退貨狀態：0 無退貨 / 1 待處理 / 2 已處理
    /// </summary>
    public int FReturnStatus { get; set; }

    public virtual TSeller FSeller { get; set; } = null!;

    public virtual TUser FUsers { get; set; } = null!;

    public virtual ICollection<TOrderDetail> TOrderDetails { get; set; } = new List<TOrderDetail>();

    public virtual ICollection<TOrderDiscount> TOrderDiscounts { get; set; } = new List<TOrderDiscount>();
}
