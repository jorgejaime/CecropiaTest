using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Jorge.Inventory.Model;
using Jorge.Inventory.Services.Messaging.ViewModels.Product;
using Jorge.Inventory.Web.App.Models.Product;

namespace Jorge.Inventory.Web.App.Services
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
           
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<ProductViewModel, ProductView>().ReverseMap();
   
            });
            
        }

    }
    }
