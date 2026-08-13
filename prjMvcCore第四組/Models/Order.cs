using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class Order
    {
        public long OrderId { get; set; }

        public string OrderNo { get; set; } = null!;

        public int UsersId { get; set; }

        public int SellerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal ShippingFee { get; set; }

        public decimal ShippingDiscount { get; set; }

        public decimal ProductDiscount { get; set; }

        public decimal TotalAmount { get; set; }

        public string RecipientName { get; set; } = null!;

        public string RecipientPhone { get; set; } = null!;

        public string ShippingAddress { get; set; } = null!;

        public string ShippingMethod { get; set; } = null!;

        /// <summary>
        /// 賣家是否已確認/列印出貨單（0 未確認 1 已確認/已列印）
        /// </summary>
        public bool IsShippingConfirmed { get; set; }

        /// <summary>
        /// 訂單狀態：0 待處理 / 1 已成立 / 2 已完成 / 3 已取消
        /// </summary>
        public int OrderStatus { get; set; }

        /// <summary>
        /// 付款狀態：0 待付款 / 1 已付款 / 2 待退款 / 3 已退款
        /// </summary>
        public int PaymentStatus { get; set; }

        /// <summary>
        /// 運送狀態：0 待出貨 / 1 運送中 / 2 已送達 / 3 運送失敗 / 4 退回包裹運送中 / 5 賣家已取回退件
        /// </summary>
        public int ShippingStatus { get; set; }

        /// <summary>
        /// 取消狀態：0 無取消申請 / 1 待回覆 / 2 已取消 / 3 拒絕取消
        /// </summary>
        public int CancellationStatus { get; set; }

        /// <summary>
        /// 退貨狀態：0 無退貨 / 1 待處理 / 2 已處理
        /// </summary>
        public int ReturnStatus { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public virtual ICollection<OrderDiscount> OrderDiscounts { get; set; } = new List<OrderDiscount>();

        public virtual TSeller Seller { get; set; } = null!;

        public virtual TUser Users { get; set; } = null!;
    }
}