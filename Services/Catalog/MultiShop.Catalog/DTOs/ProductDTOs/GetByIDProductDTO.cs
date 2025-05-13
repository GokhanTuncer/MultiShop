namespace MultiShop.Catalog.DTOs.ProductDTOs
{
    public class GetByIDProductDTO
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductImageURL { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryID { get; set; }
    }
}
