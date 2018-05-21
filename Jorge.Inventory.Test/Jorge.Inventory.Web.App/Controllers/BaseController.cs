using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jorge.Inventory.Web.App.Controllers
{
    public class BaseController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errors"></param>
        public void SetErrorMessages(List<string> errors)
        {

            if (errors != null && errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
        }

    }
}
