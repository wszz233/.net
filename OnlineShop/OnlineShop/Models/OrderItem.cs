using System;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Converts;
using System.Text.Json.Serialization;
namespace OnlineShop.Models;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; } // 确保有这一行，并且是 public
    public string? ProductName{get;set;}
    public string? PictureUrl{get;set;}
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    

    [ForeignKey("OrderId")]
    public  Order? Order { get; set; }

    [ForeignKey("ProductId")]
    public  ProductDetails? Product { get; set; }
}
