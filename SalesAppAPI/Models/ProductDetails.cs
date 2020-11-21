namespace SalesAppAPI.Models
{
    public class ProductDetails
    {
        public string ProductDetailsID { get; set; }
        public string ProductID { get; set; }
        public string Details { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Product Product;
    }
}