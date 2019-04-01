using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        CatalogRepository repository ;

        public CatalogController() {
            repository = new CatalogRepository();
        }

        //  Get All product details
        //localhost:49559/api/Catalog
        // RequestJSON: N/A

        // GET: api/Catalog
        [HttpGet]
        public List<Catalog.Models.Catalog> Get()
        {
            return repository.GetCatalogs();

        }

        //  Get product details by Id
        //localhost:49559/api/Catalog/1
        // RequestJSON: N/A

        // GET: api/Catalog/5
        [HttpGet("{id}", Name = "Get")]
        public Catalog.Models.Catalog Get(int id)
        {
            return repository.GetCatalogs(id.ToString());
        }

        
    }
}
