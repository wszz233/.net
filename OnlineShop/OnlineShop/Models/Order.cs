using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using OnlineShop.Models;
using OnlineShop.Converts; // 如果你创建了自定义转换器，请添加此 using

namespace OnlineShop.Models;

public class Order
{
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    [Required(ErrorMessage = "用户 ID 是必填项")]
    [StringLength(50, ErrorMessage = "用户 ID 的长度不能超过 50 个字符")]
    public required string UserId { get; set; }

    [Required(ErrorMessage = "订单状态是必填项")]
     public OrderStatus Status { get; set; } = OrderStatus.Pending;

    [Range(0, 1000000, ErrorMessage = "订单总金额不能为负数，且不能超过 1000000")]
    public decimal TotalAmount { get; set; }

    [Required(ErrorMessage = "收货地址是必填项")]
    [StringLength(200, ErrorMessage = "收货地址的长度不能超过 200 个字符")]
    public required string ShippingAddress { get; set; }

    [Required(ErrorMessage = "收货电话是必填项")]
    [StringLength(50, ErrorMessage = "收货电话的长度不能超过 50 个字符")]  //根据实际情况调整长度
    public required string ShippingPhone { get; set; }
    

    public List<OrderItem> Items { get; set; } = new();
}