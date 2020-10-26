using System.Collections.Generic;

namespace Aiesec.Web.ViewModels
{
    public class DataTable<TEntity>
    {
        public int  draw { get; set; }

        public int recordsTotal { get; set; }

        public int recordsFiltered { get; set; }

        public string error { get; set; }
        
        public IEnumerable<TEntity> data {get; set; }
    }
}