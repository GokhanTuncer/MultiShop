using MultiShop.Catalog.DTOs.CategoryDTOs;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.DTOs.ProductDTOs
{
    public class ResultProductsWithCategoryDTO
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductImageURL { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryID { get; set; }
        public ResultCategoryDTO Category { get; set; }
    }
}
