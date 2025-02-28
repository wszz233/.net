using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using OnlineShop.Models;


namespace OnlineShop.Clients;

public class OrderClient(HttpClient httpClient)
{
  

    // 获取所有订单
    public async Task<Order[]> GetOrdersAsync()
        => await httpClient.GetFromJsonAsync<Order[]>("api/orders") ?? Array.Empty<Order>();

    // 获取单个订单
    public async Task<Order> GetOrderAsync(int id)
        => await httpClient.GetFromJsonAsync<Order>($"api/orders/{id}")
            ?? throw new Exception($"无法找到订单 (ID: {id})");

    // 创建订单 (注意：参数现在是 Order 类型)
    public async Task<Order> CreateOrderAsync(Order createOrder) //参数改为Order
    {
        var response = await httpClient.PostAsJsonAsync("api/orders", createOrder);
        response.EnsureSuccessStatusCode(); // 确保请求成功

        // 从响应中读取创建的订单
        var createdOrder = await response.Content.ReadFromJsonAsync<Order>();
        if (createdOrder == null)
        {
            throw new Exception("创建订单失败，服务器返回的数据无效。");
        }
        return createdOrder;
    }
  public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus)
{
    // 正确：使用 UpdateOrderStatusDto，只包含 status 属性
    var response = await httpClient.PatchAsJsonAsync($"api/orders/{orderId}/status",  new { status = newStatus });
    response.EnsureSuccessStatusCode();
}

   //其他方法 (示例)
    //public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus)
    //{
    //    // 注意：PATCH 请求通常需要一个表示更改的对象。
    //    // 你可能需要创建一个专门的 DTO 来表示状态更新。
    //     var response = await _httpClient.PatchAsJsonAsync($"api/orders/{orderId}/status", new { status = newStatus });
    //     response.EnsureSuccessStatusCode();
    //}

    //public async Task CancelOrderAsync(int orderId)
    //{
    //   //通常, 取消订单不是真的删除, 而是更新状态.
    //    var response = await _httpClient.DeleteAsync($"api/orders/{orderId}");
    //    response.EnsureSuccessStatusCode();
    //}
}