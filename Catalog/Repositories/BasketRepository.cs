using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Repositories
{
    public class BasketRepository
    {
        private static List<Catalog.Models.Basket> baskets = null;
        public BasketRepository()
        {
            if (baskets == null)
            {
                baskets = new List<Models.Basket>();
            }
        }

        public Basket GetUserBasket(string user)
        {
            Basket basket = baskets.FirstOrDefault(item => item.User == user);
            if (basket == null)
            {
                basket= new Models.Basket { User = user, Products = new List<Models.ProductQty>() };
                baskets.Add(basket);
            }
            return basket;
        }

        public Basket AddUpdateBasket(string user, string productId, int quantity)
        {
            CatalogRepository catalogRepository = new CatalogRepository();
            Basket basket = baskets.FirstOrDefault(item => item.User == user);

            if (basket == null)
            {
                throw new Exception("Basket not available");

            }
            Catalog.Models.ProductQty product = basket.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                Catalog.Models.Catalog catalog = catalogRepository.GetCatalogs(productId);
                ProductQty p = new ProductQty();
                p.ProductId = catalog.Id;
                p.Quantity = quantity;
                basket.Products.Add(p);
           

            }
            else
            {
                basket.Products.Remove(product);
                product.ProductId = productId;
                product.Quantity = quantity;
                basket.Products.Add(product);

            }

            return basket;
        }

        public bool RemoveProduct(string user, string productId)
        {

            CatalogRepository catalogRepository = new CatalogRepository();
            Basket basket = baskets.FirstOrDefault(item => item.User == user);

            if (basket == null)
            {
                throw new Exception("Basket not available");

            }
            Catalog.Models.ProductQty product = basket.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                throw new Exception("Product not available in basket");

            }
            else
            {
                basket.Products.Remove(product);
            }
            return true;
        }

        public bool ClearUserBasket(string user)
        {
            CatalogRepository catalogRepository = new CatalogRepository();
            Basket basket = baskets.FirstOrDefault(item => item.User == user);

            if (basket == null)
            {
                throw new Exception("Basket not available");

            }
            else
            {
                basket.Products.Clear();
            }

            return true;
        }

    }
}
