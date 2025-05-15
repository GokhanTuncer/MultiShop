namespace MultiShop.Discount.Entities
{
    public class Coupon
    {
        public int CouponID { get; set; }
        public string Code { get; set; }
        public string Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
