﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOLayer.DiscountDTOs
{
    public class GetDiscountCodeDetailByCode
    {
        public int CouponID { get; set; }
        public string Code { get; set; }
        public string Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
