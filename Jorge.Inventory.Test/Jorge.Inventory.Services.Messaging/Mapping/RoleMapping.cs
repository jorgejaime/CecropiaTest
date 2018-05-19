using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Jorge.Inventory.Model;
using Jorge.Inventory.Services.Messaging.ViewModels.Product;

namespace Jorge.Inventory.Services.Messaging
{
    public static class ProductMapping
    {
       
        public static IEnumerable<Product> ToProductList(this IEnumerable<ProductView> list)
        {
            return Mapper.Map<List<Product>>(list);
        }


        public static IEnumerable<ProductView> ToProductViewList(this IEnumerable<Product> list)
        {
            return Mapper.Map<List<ProductView>>(list);
        }

        public static ProductView ToProductView(this Product model)
        {
            var modelView = Mapper.Map<ProductView>(model);
            return modelView;
        }

        public static Product ToProduct(this ProductView model)
        {
            var modelView = Mapper.Map<Product>(model);
            return modelView;
        }
    }
}
