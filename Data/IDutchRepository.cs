using System.Collections.Generic;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Data
{
  public interface IDutchRepository
  {
    IEnumerable<Product> GetAllProducts();
    IEnumerable<Product> GetProductsByCategory(string category);

    void AddEntity(object entity);
    bool SaveAll();

    IEnumerable<Order> GetAllOrders(bool includeItems);
    Order GetOrderById(int id);


  }
}