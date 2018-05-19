﻿using System.Runtime.Serialization;

namespace Jorge.Inventory.Infrastructure.Messaging
{
    public class ContractRequest<T> where T : class
    {

        /// <summary>
        /// Gets or sets the information to send in the request if type BaseDTO
        /// </summary>
        public T Data { get; set; }
        
        public int? Page { get; set; }

        public int PageSize { get; set; }
      

    }
}
