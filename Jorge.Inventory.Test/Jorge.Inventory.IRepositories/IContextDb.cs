using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Jorge.Inventory.IRepositories
{
    public interface IContextDb
    {
        IDbConnection Connection { get; }
    }
}
