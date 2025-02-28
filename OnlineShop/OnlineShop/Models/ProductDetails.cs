
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OnlineShop.Converts;




namespace OnlineShop.Models;

public class ProductDetails
{
    public int Id{get; set;}
    [Required(ErrorMessage ="请输入商品名")][StringLength(50)] public required string Name{get; set;}
    
    [Required (ErrorMessage ="请选择类型")]
    [JsonConverter(typeof(StringConverter))]
    public string? ProductTypeId{get; set;}
    [Range(0.1,1000,ErrorMessage="价格在0.1元到1000之间" )]public decimal Price{get; set;}
    [Range(0,1000,ErrorMessage="库存在01到1000之间" ) ]public int Stock{get; set;}
    [Required][StringLength(1000,ErrorMessage="图片链接长度在1元到1000之间" )]public required string PictureUrl{get; set;}


}
