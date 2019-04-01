using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class Basket
       
    {
        
        public string User { get; set; }
      
        public List<ProductQty> Products { get; set; }
   
    }
}
