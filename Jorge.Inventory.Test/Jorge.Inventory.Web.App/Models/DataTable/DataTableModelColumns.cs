namespace  Jorge.Inventory.Web.App.Models.DataTable
{
    public class DataTableModelColumns
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public DataTableModelSearch search { get; set; }
        
    }
}