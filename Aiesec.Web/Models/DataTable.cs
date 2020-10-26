using System.Collections.Generic;

namespace Aiesec.Web.Models
{
    public class DataTable<TResult>
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public string error { get; set; }
        public List<TResult> data { get; set; }
    }
}