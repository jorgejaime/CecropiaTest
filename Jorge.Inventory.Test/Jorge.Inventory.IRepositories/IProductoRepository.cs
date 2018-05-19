using Jorge.Inventory.Model;
using System;
using System.Collections.Generic;

namespace Jorge.Inventory.IRepositories
{
    public interface IProductoRepository
    {
        void Add(Product entity);
        void Update(Product entity);
        IEnumerable<Product> FindAll();
        Product FindById(int id);
        void Remove(Product entity);
    }
}
