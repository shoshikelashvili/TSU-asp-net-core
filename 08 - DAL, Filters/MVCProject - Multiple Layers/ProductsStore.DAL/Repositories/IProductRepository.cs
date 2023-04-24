using ProductsStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsStore.DAL.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
