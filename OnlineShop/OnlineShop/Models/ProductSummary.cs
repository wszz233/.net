using System;

namespace OnlineShop.Models;

public class ProductSummary
{
    public int Id{get; set;}
    public required string Name{get; set;}
    public required string ProductType{get; set;}
    public decimal Price{get; set;}
    public int Stock{get; set;}
    public required string PictureUrl{get; set;}


    
}
