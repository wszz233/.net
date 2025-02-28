using System;
using OnlineShop.Models;

namespace OnlineShop.Clients;

public class ProductClient(HttpClient httpClient)
{
    
   
    public async Task<ProductSummary[]> GetProductsAsync()
        =>await httpClient.GetFromJsonAsync<ProductSummary[]>("products")??[];

    public async Task AddProductAsync(ProductDetails product)
        =>await httpClient.PostAsJsonAsync("products",product);

    


    public async Task<ProductDetails> GetProductAsync(int id)
        => await httpClient.GetFromJsonAsync<ProductDetails>($"products/{id}")
            ??throw new Exception("不能找到商品");

    public async Task UpdateProductAsync(ProductDetails updateProduct)
        => await httpClient.PutAsJsonAsync($"products/{updateProduct.Id}",updateProduct);
    public async Task DeleteProductAsync(int id)
        =>await httpClient.DeleteAsync($"products/{id}");

    
}
