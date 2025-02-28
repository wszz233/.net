using System;
using OnlineShop.Models;

namespace OnlineShop.Clients;

public class ProductTypeClient(HttpClient httpClient)
{
    
    public async Task<ProductType[]> GetProductTypesAsync()
        =>await httpClient.GetFromJsonAsync<ProductType[]>("producttypes")??[];
}
