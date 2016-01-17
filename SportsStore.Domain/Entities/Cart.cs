using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Domain.Entities
{
    /// <summary>
    /// Shopping cart class.
    /// </summary>
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        /// <summary>
        /// Add new item to shopping cart.
        /// </summary>
        /// <param name="product">Shopped product.</param>
        /// <param name="quantity">Product quantity.</param>
        public void AddItem(Product product, int quantity)
        {
            var line = lineCollection.FirstOrDefault(p => p.Product.ProductID == product.ProductID);

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        /// <summary>
        /// Remove product from shopping cart.
        /// </summary>
        /// <param name="product">Removing product.</param>
        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        /// <summary>
        /// Compute total price. 
        /// </summary>
        /// <returns></returns>
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        /// <summary>
        /// Clear shopping cart.
        /// </summary>
        public void Clear()
        {
            lineCollection.Clear();
        }

        /// <summary>
        /// Returns bought products.
        /// </summary>
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    /// <summary>
    /// Shoppting position class.
    /// </summary>
    public class CartLine
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
