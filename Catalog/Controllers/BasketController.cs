using Catalog.Models;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        BasketRepository repository;

        public BasketController()
        {
            repository = new BasketRepository();
        }
     

        //  Get user basket
        //localhost:49559/api/basket/Chetan
        // RequestJSON: N/A

        // GET: api/Basket/5
        [HttpGet("{id}", Name = "GetBasket")]
        public Catalog.Models.Basket Get(string id)
        {
            return repository.GetUserBasket(id.ToString());
        }

        //  Add/Update products to basket
        //localhost:49559/api/Basket
        // RequestJSON: N/A
        //        {  
        //   "User":"Chetan",
        //   "Products":[
        //      {  
        //         "ProductId":1,
        //         "Quantity":1
        //      }
        //      ,
        //      {  
        //         "ProductId":2,
        //         "Quantity":2
        //      }

        //   ]
        //}
        // POST: api/Basket
        [HttpPost]
        public void Post(Basket basket)
        {
            foreach (var item in basket.Products)
            {
                repository.AddUpdateBasket(basket.User, item.ProductId, item.Quantity);
            }

        }




        //  clear all products from basket
        //localhost:49559/api/Basket/Chetan
        // RequestJSON: N/A
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            repository.ClearUserBasket(id.ToString());
            //    return repository.GetUserBasket(basket.User);
        }


        //  remove particular product from basket
        //localhost:49559/api/Basket
        // RequestJSON: 
        //        {  
        //   "User":"Chetan",
        //   "Products":[
        //      {  
        //         "ProductId":1,
        //         "Quantity":1
        //      }
        //   ]
        //} 
        [HttpDelete]
        public void Delete(Basket basket)
        {
            foreach (var item in basket.Products)
            {
                repository.RemoveProduct(basket.User, item.ProductId);
            }
            repository.GetUserBasket(basket.User);
        }
    }
}
