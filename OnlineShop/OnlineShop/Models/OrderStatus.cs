using System.Text.Json.Serialization;

namespace OnlineShop.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderStatus
{
    Pending,    // 待付款
    Paid,       // 已付款
    Shipped,    // 已发货
    Delivered,  // 已送达/已收货
    Completed,  // 已完成 (交易成功)
    Cancelled,  // 已取消
    Refunded    //已退款
}
