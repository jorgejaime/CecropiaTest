using System.Collections;
using System.Collections.Generic;

namespace  Jorge.Inventory.Web.App.Models.DataTable
{
    public class DataTableResponse<T>
    {
        public int Draw { get; set; }

        public long RecordsTotal { get; set; }

        public long RecordsFiltered { get; set; }

        public IEnumerable Data { get; set; }

        public string Error { get; set; }

        public DataTableResponse()
        {
            Data = new List<T>();
        }
    }
}