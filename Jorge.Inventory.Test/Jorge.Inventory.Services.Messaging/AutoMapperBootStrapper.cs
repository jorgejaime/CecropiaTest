using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Jorge.Inventory.Model;
using Jorge.Inventory.Services.Messaging.ViewModels.Product;

namespace Jorge.Inventory.Services.Messaging
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
           
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<Product, ProductView>().ForMember(x => x.Image, r => r.MapFrom(i => Convert.ToBase64String(i.Image)));
                cfg.CreateMap<ProductView, Product>().ForMember(x => x.Image, r => r.MapFrom(i => Convert.FromBase64String(i.Image)));
                
   
            });
            
        }

    }
    }
