using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Models;
namespace Catalog.Repositories
{
    public class CatalogRepository
    {
        private static List<Catalog.Models.Catalog> catalogs = null;
        public CatalogRepository()
        {
            if (catalogs == null)
            {
                catalogs = new List<Models.Catalog>();
                catalogs.Add(new Models.Catalog { Id = "1", Name = "Pen Drive", Description = "Sony 8GB Pen Drive", Price = 450, AvailableStock = 100 });
                catalogs.Add(new Models.Catalog { Id = "2", Name = "Hard Disk", Description = "Sony 2TB Hard Disk", Price = 4500, AvailableStock = 100 });
                catalogs.Add(new Models.Catalog { Id = "3", Name = "Pen Drive", Description = "Sony 16GB Pen Drive", Price = 800, AvailableStock = 100 });
            }
        }
        public List<Catalog.Models.Catalog> GetCatalogs()
        {
            
            return catalogs;
        }

        public Catalog.Models.Catalog GetCatalogs(string id)
        {
            return catalogs.FirstOrDefault(item => item.Id == id);
                
        }
    }
}
