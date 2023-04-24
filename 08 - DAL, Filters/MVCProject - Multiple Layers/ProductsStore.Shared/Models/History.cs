using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsStore.Shared.Models
{
    public class History
    {
        public int Id { get; set; }

        public string EntityName { get; set; }

        public string Operation { get; set; }

        public DateTime OperationDate { get; set; }
    }
}
