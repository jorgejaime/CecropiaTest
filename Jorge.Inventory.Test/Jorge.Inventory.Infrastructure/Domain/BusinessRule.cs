using System;
using System.Collections.Generic;
using System.Text;

namespace Jorge.Inventory.Infrastructure.Domain
{
    public class BusinessRule
    {
        public BusinessRule(string property, string rule)
        {
            Property = property;
            Rule = rule;
        }

        public string Property { get; set; }
        public string Rule { get; set; }
    }
}
