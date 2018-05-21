using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jorge.Inventory.Web.App.Models
{
    public class  JsonResultViewModel<T> where T: class 
    {
        public bool IsValid { get; set; }
        public List<T> Data { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}
